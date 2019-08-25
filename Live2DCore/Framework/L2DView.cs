using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Interop;
using System.Windows.Controls;
using System.Windows.Threading;
using System.ComponentModel;
using L2DLib.Core;
using L2DLib.Interface;

namespace L2DLib.Framework
{
    /// <summary>
    /// Live2D 提供与图形输出相关的功能。
    /// 您可以继承此类以实现其他功能。
    /// </summary>
    public class L2DView : UserControl, IL2DRenderer
    {
        #region 属性
        /// <summary>
        /// 获取或设置要由渲染器显示的模型。
        /// </summary>
        public L2DModel Model
        {
            get { return _Model; }
            set
            {
                _Model = value;
                render = new L2DRender(value);
            }
        }
        private L2DModel _Model;

        /// <summary>
        /// 获取或设置一个值，指示呈现是否支持透明度。
        /// </summary>
        public bool AllowTransparency
        {
            get { return _AllowTransparency; }
            set
            {
                _AllowTransparency = value;
                HRESULT.Check(NativeMethods.SetAlpha(value));
            }
        }
        private bool _AllowTransparency = true;

        /// <summary>
        /// 获取或设置渲染时要使用的多重采样消除锯齿值。
        /// </summary>
        public uint DesiredSamples
        {
            get { return _DesiredSamples; }
            set
            {
                _DesiredSamples = value;
                HRESULT.Check(NativeMethods.SetNumDesiredSamples(value));
            }
        }
        private uint _DesiredSamples = 4;
        #endregion

        #region 对象
        L2DRender render;
        TimeSpan lastRender;
        DispatcherTimer adapterTimer;
        Image renderHolder = new Image();
        D3DImage renderScene = new D3DImage();
        #endregion

        #region 构造函数
        public L2DView()
        {
            if (!DesignerProperties.GetIsInDesignMode(this) && File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "L2DNative.dll")))
            {
                Initialized += L2DView_Initialized;
            }
        }

        private void L2DView_Initialized(object sender, EventArgs e)
        {
            renderHolder.Source = renderScene;
            Content = renderHolder;

            HRESULT.Check(NativeMethods.SetAlpha(AllowTransparency));
            HRESULT.Check(NativeMethods.SetNumDesiredSamples(DesiredSamples));

            Loaded += L2DView_Loaded;
            SizeChanged += L2DView_SizeChanged;
            CompositionTarget.Rendering += CompositionTarget_Rendering;

            adapterTimer = new DispatcherTimer();
            adapterTimer.Tick += AdapterTimer_Tick; ;
            adapterTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            adapterTimer.Start();
        }

        private void L2DView_Loaded(object sender, RoutedEventArgs e)
        {
            HRESULT.Check(
                NativeMethods.SetSize(
                    (uint)renderHolder.ActualWidth,
                    (uint)renderHolder.ActualHeight
                )
            );
        }
        #endregion

        #region 内部功能
        private bool IsPresented()
        {
            return PresentationSource.FromVisual(this) != null && ActualWidth > 0 && ActualHeight > 0;
        }
        #endregion

        #region 渲染事件
        public virtual void Rendering()
        {

        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            RenderingEventArgs args = (RenderingEventArgs)e;

            if (renderScene.IsFrontBufferAvailable && lastRender != args.RenderingTime)
            {
                IntPtr pSurface = IntPtr.Zero;
                HRESULT.Check(NativeMethods.GetBackBufferNoRef(out pSurface));
                if (pSurface != IntPtr.Zero)
                {
                    renderScene.Lock();
                    renderScene.SetBackBuffer(D3DResourceType.IDirect3DSurface9, pSurface);

                    if (Model != null && Model.IsLoaded)
                    {
                        render.BeginRender();

                        Model.LoadParam();
                        render.UpdateMotion();
                        render.UpdateEyeBlink();
                        Model.SaveParam();

                        render.UpdateBreath();
                        render.UpdateExpression();

                        Rendering();

                        render.UpdatePhysics();
                        render.UpdatePose();

                        render.EndRender();
                    }

                    renderScene.AddDirtyRect(new Int32Rect(0, 0, renderScene.PixelWidth, renderScene.PixelHeight));
                    renderScene.Unlock();

                    lastRender = args.RenderingTime;
                }
            }
        }

        private void L2DView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Model != null && Model.IsLoaded && IsPresented())
            {
                HRESULT.Check(
                    NativeMethods.SetSize(
                        (uint)renderHolder.ActualWidth,
                        (uint)renderHolder.ActualHeight
                    )
                );
            }
        }
        #endregion

        #region 适配器设置事件
        private void AdapterTimer_Tick(object sender, EventArgs e)
        {
            if (Model != null && Model.IsLoaded && IsPresented())
            {
                NativeStructure.POINT point = new NativeStructure.POINT(renderHolder.PointToScreen(new Point(0, 0)));
                HRESULT.Check(NativeMethods.SetAdapter(point));
            }
        }
        #endregion
    }
}
