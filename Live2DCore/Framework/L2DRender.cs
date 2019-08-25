using System;
using L2DLib.Core;
using L2DLib.Utility;

namespace L2DLib.Framework
{
    /// <summary>
    /// 提供与Live2D渲染相关的功能。
    /// </summary>
    public class L2DRender
    {
        #region 属性
        /// <summary>
        /// 获取渲染器要显示的模型。
        /// </summary>
        public L2DModel Model
        {
            get { return _Model; }
        }
        private L2DModel _Model;
        #endregion

        #region 构造函数
        public L2DRender(L2DModel model)
        {
            _Model = model;
        }
        #endregion

        #region 用户功能
        /// <summary>
        /// 开始渲染。
        /// </summary>
        public void BeginRender()
        {
            HRESULT.Check(NativeMethods.BeginRender(new IntPtr(Model.Handle)));
        }

        /// <summary>
        /// 结束渲染。
        /// </summary>
        public void EndRender()
        {
            HRESULT.Check(NativeMethods.EndRender(new IntPtr(Model.Handle)));
        }

        /// <summary>
        /// 更新姿势渲染。
        /// 必须在 BeginRender() 和 EndRender() 函数之间调用它。
        /// </summary>
        public void UpdatePose()
        {
            if (Model != null && Model.Pose != null)
            {
                Model.Pose.UpdateParam(Model);
            }
        }

        /// <summary>
        /// 更新物理渲染。
        ///必须在 BeginRender() 和 EndRender() 函数之间调用它。
        /// </summary>
        public void UpdatePhysics()
        {
            if (Model.Physics != null && Model.Physics?.Length > 0)
            {
                foreach (L2DPhysics physics in Model.Physics)
                {
                    physics.UpdateParam(Model);
                }
            }
        }

        /// <summary>
        /// 更新动态渲染。
        ///必须在 BeginRender() 和 EndRender() 函数之间调用它。
        /// </summary>
        public bool UpdateMotion()
        {
            bool result = false;
            if (Model != null && Model.Motion?.Count > 0)
            {
                HRESULT.Check(NativeMethods.UpdateMotion(new IntPtr(Model.Handle), out result));
            }

            return result;
        }

        /// <summary>
        /// 更新面部表情渲染。
        ///必须在 BeginRender() 和 EndRender() 函数之间调用它。
        /// </summary>
        public bool UpdateExpression()
        {
            bool result = false;
            if (Model != null && Model.Expression?.Count > 0)
            {
                HRESULT.Check(NativeMethods.UpdateExpression(new IntPtr(Model.Handle), out result));
            }

            return result;
        }

        /// <summary>
        /// 更新自动呼吸渲染。
        ///必须在 BeginRender() 和 EndRender() 函数之间调用它。
        /// </summary>
        public void UpdateBreath()
        {
            if (Model != null && Model.UseBreath)
            {
                double t = (L2DUtility.GetUserTimeMSec() / 1000.0) * 2 * 3.14;
                Model.SetParamFloat("PARAM_BREATH", (float)(0.5f + 0.5f * Math.Sin(t / 3.2345)));
            }
        }

        /// <summary>
        /// 更新自动眨眼渲染。
        ///必须在 BeginRender() 和 EndRender() 函数之间调用它。
        /// </summary>
        public void UpdateEyeBlink()
        {
            if (Model != null && Model.UseEyeBlink)
            {
                HRESULT.Check(NativeMethods.EyeBlinkUpdate(new IntPtr(Model.Handle)));
            }
        }
        #endregion
    }
}
