using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using L2DLib.Core;

namespace L2DLib.Framework
{
    /// <summary>
    /// 提供与Live2D模型相关的功能。
    /// </summary>
    public class L2DModel : L2DBase, IDisposable
    {
        #region 属性
        /// <summary>
        /// 获取目的地的路径。
        /// </summary>
        public string Path
        {
            get { return _Path; }
        }
        protected string _Path;

        /// <summary>
        /// 设置或获取模型的姿势。
        /// </summary>
        public L2DPose Pose
        {
            get { return _Pose; }
            set { _Pose = value; }
        }
        private L2DPose _Pose;

        /// <summary>
        /// 设置或获取模型的运动。
        /// </summary>
        public Dictionary<string, L2DMotion[]> Motion
        {
            get { return _Motion; }
            set { _Motion = value; }
        }
        private Dictionary<string, L2DMotion[]> _Motion;

        /// <summary>
        /// 设置或获取模型的外观。
        /// </summary>
        public Dictionary<string, L2DExpression> Expression
        {
            get { return _Expression; }
            set { _Expression = value; }
        }
        private Dictionary<string, L2DExpression> _Expression;

        /// <summary>
        /// 设置或获取模型的物理特性。
        /// </summary>
        public L2DPhysics[] Physics
        {
            get { return _Physics; }
            set { _Physics = value; }
        }
        private L2DPhysics[] _Physics;

        /// <summary>
        /// 获取或设置是否启用模型的自动呼吸功能。
        /// </summary>
        public bool UseBreath
        {
            get { return _UseBreath; }
            set { _UseBreath = value; }
        }
        private bool _UseBreath = false;

        /// <summary>
        /// 获取或设置模型是否使用自动眨眼功能。
        /// </summary>
        public bool UseEyeBlink
        {
            get { return _UseEyeBlink; }
            set { _UseEyeBlink = value; }
        }
        private bool _UseEyeBlink = false;
        #endregion

        #region 对象
        private bool IsModelLoaded = false;
        private bool IsTextureLoaded = false;
        #endregion

        #region 构造函数
        /// <summary>
        /// 创建模型目标。
        /// </summary>
        /// <param name="path">模型文件的路径。</param>
        public L2DModel(string path)
        {
            _Path = path;
            HRESULT.Check(NativeMethods.LoadModel(Marshal.StringToHGlobalAnsi(path), out _Handle));
            SaveParam();
            IsModelLoaded = true;
            SetLoaded();
        }
        #endregion

        #region 析构函数
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                _IsLoaded = false;

                if (disposing)
                {
                    IsModelLoaded = false;
                    IsTextureLoaded = false;
                }

                HRESULT.Check(NativeMethods.RemoveModel(new IntPtr(Handle)));

                disposedValue = true;
            }
        }

        ~L2DModel()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region 内部功能
        private void SetLoaded()
        {
            if (IsModelLoaded && IsTextureLoaded)
            {
                _IsLoaded = true;
            }
            else
            {
                _IsLoaded = false;
            }
        }

        private void CheckDispose()
        {
            if (disposedValue)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }
        #endregion

        #region 用户功能
        /// <summary>
        /// 设置纹理。
        /// </summary>
        /// <param name="path">纹理文件的路径数组。</param>
        public void SetTexture(string[] path)
        {
            CheckDispose();
            foreach (string texture in path)
            {
                HRESULT.Check(NativeMethods.SetTexture(new IntPtr(Handle), Marshal.StringToHGlobalAuto(texture)));
            }
            IsTextureLoaded = true;
            SetLoaded();
        }

        /// <summary>
        /// 设置与该键对应的参数的值。
        /// 必须在 BeginRender() 和 EndRender() 函数之间调用它。
        /// </summary>
        /// <param name="key">目标参数的索引。</param>
        /// <param name="value">要应用于目标参数的值。</param>
        public void SetParamFloat(int key, float value)
        {
            CheckDispose();
            HRESULT.Check(NativeMethods.SetParamFloatInt(new IntPtr(Handle), key, value));
        }

        /// <summary>
        /// 设置与该键对应的参数的值。
        /// 必须在 BeginRender() 和 EndRender() 函数之间调用它。
        /// </summary>
        /// <param name="key">目标参数的名称。</param>
        /// <param name="value">要应用于目标参数的值。</param>
        public void SetParamFloat(string key, float value)
        {
            CheckDispose();
            HRESULT.Check(NativeMethods.SetParamFloatString(new IntPtr(Handle), Marshal.StringToHGlobalAnsi(key), value));
        }

        /// <summary>
        /// 获取与键对应的参数的值。
        /// 必须在 BeginRender() 和 EndRender() 函数之间调用它。
        /// </summary>
        /// <param name="key">目标参数的索引。</param>
        public float GetParamFloat(int key)
        {
            CheckDispose();
            float result = 0;
            HRESULT.Check(NativeMethods.GetParamFloatInt(new IntPtr(Handle), key, out result));

            return result;
        }

        /// <summary>
        /// 获取与键对应的参数的值。
        /// 必须在 BeginRender() 和 EndRender() 函数之间调用它。
        /// </summary>
        /// <param name="key">目标参数的名称。</param>
        public float GetParamFloat(string key)
        {
            CheckDispose();
            float result = 0;
            HRESULT.Check(NativeMethods.GetParamFloatString(new IntPtr(Handle), Marshal.StringToHGlobalAnsi(key), out result));

            return result;
        }

        /// <summary>
        /// 将值添加到与键对应的参数。
        /// 必须在 BeginRender() 和 EndRender() 函数之间调用它。
        /// </summary>
        /// <param name="key">目标参数的名称。</param>
        /// <param name="value">要应用于目标参数的值。</param>
        public void AddToParamFloat(string key, float value)
        {
            CheckDispose();
            HRESULT.Check(NativeMethods.AddToParamFloat(new IntPtr(Handle), Marshal.StringToHGlobalAnsi(key), value));
        }

        /// <summary>
        /// 与该键对应的参数乘以该值。
        /// 必须在 BeginRender() 和 EndRender() 函数之间调用它。
        /// </summary>
        /// <param name="key">目标参数的名称。</param>
        /// <param name="value">要应用于目标参数的值。</param>
        public void MultParamFloat(string key, float value)
        {
            CheckDispose();
            HRESULT.Check(NativeMethods.MultParamFloat(new IntPtr(Handle), Marshal.StringToHGlobalAnsi(key), value));
        }

        /// <summary>
        /// 设置与键对应的部件的透明度。
        /// 必须在 BeginRender() 和 EndRender() 函数之间调用它。
        /// </summary>
        /// <param name="key">目标参数的索引。</param>
        /// <param name="value">要应用于目标参数的值。</param>
        public void SetPartsOpacity(int key, float value)
        {
            CheckDispose();
            HRESULT.Check(NativeMethods.SetPartsOpacityInt(new IntPtr(Handle), key, value));
        }

        /// <summary>
        /// 设置与键对应的部件的透明度。
        /// 必须在 BeginRender() 和 EndRender() 函数之间调用它。
        /// </summary>
        /// <param name="key">目标参数的名称。</param>
        /// <param name="value">要应用于目标参数的值。</param>
        public void SetPartsOpacity(string key, float value)
        {
            CheckDispose();
            HRESULT.Check(NativeMethods.SetPartsOpacityString(new IntPtr(Handle), Marshal.StringToHGlobalAnsi(key), value));
        }

        /// <summary>
        /// 获取与键对应的部件的透明度。
        /// 必须在 BeginRender() 和 EndRender() 函数之间调用它。
        /// </summary>
        /// <param name="key">目标参数的索引。</param>
        public float GetPartsOpacity(int key)
        {
            CheckDispose();
            float result = 0;
            HRESULT.Check(NativeMethods.GetPartsOpacityInt(new IntPtr(Handle), key, out result));

            return result;
        }

        /// <summary>
        /// 获取与键对应的部件的透明度。
        /// 必须在 BeginRender() 和 EndRender() 函数之间调用它。
        /// </summary>
        /// <param name="key">目标参数的名称。</param>
        public float GetPartsOpacity(string key)
        {
            CheckDispose();
            float result = 0;
            HRESULT.Check(NativeMethods.GetPartsOpacityString(new IntPtr(Handle), Marshal.StringToHGlobalAnsi(key), out result));

            return result;
        }

        /// <summary>
        /// 获取与键对应的参数的索引。
        /// 必须在 BeginRender() 和 EndRender() 函数之间调用它。
        /// </summary>
        /// <param name="key">目标参数的名称。</param>
        public int GetParamIndex(string key)
        {
            CheckDispose();
            int result = 0;
            HRESULT.Check(NativeMethods.GetParamIndex(new IntPtr(Handle), Marshal.StringToHGlobalAnsi(key), out result));

            return result;
        }

        /// <summary>
        /// 获取与密钥对应的部分的数据索引。
        /// 必须在 BeginRender() 和 EndRender() 函数之间调用它。
        /// </summary>
        /// <param name="key">目标部件的名称。</param>
        public int GetPartsDataIndex(string key)
        {
            CheckDispose();
            int result = 0;
            HRESULT.Check(NativeMethods.GetPartsDataIndex(new IntPtr(Handle), Marshal.StringToHGlobalAnsi(key), out result));

            return result;
        }

        /// <summary>
        /// 保存参数。
        /// 必须在 BeginRender() 和 EndRender() 函数之间调用它。
        /// </summary>
        public void SaveParam()
        {
            CheckDispose();
            HRESULT.Check(NativeMethods.SaveParam(new IntPtr(Handle)));
        }

        /// <summary>
        /// 加载参数。
        /// 必须在 BeginRender() 和 EndRender() 函数之间调用它。
        /// </summary>
        public void LoadParam()
        {
            CheckDispose();
            HRESULT.Check(NativeMethods.LoadParam(new IntPtr(Handle)));
        }
        #endregion
    }
}
