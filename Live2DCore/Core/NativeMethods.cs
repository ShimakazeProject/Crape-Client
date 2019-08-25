using System;
using System.Runtime.InteropServices;

namespace L2DLib.Core
{
    /// <summary>
    /// 提供与L2DNative库的互操作性。
    /// </summary>
    class NativeMethods
    {
        #region Live2D
        [DllImport("L2DNative.dll")]
        public static extern int LoadModel(IntPtr modelPath, out long ret);

        [DllImport("L2DNative.dll")]
        public static extern int RemoveModel(IntPtr model);

        [DllImport("L2DNative.dll")]
        public static extern int SetTexture(IntPtr model, IntPtr texturePath);

        [DllImport("L2DNative.dll")]
        public static extern int SetParamFloatInt(IntPtr model, int key, float value);

        [DllImport("L2DNative.dll")]
        public static extern int SetParamFloatString(IntPtr model, IntPtr key, float value);

        [DllImport("L2DNative.dll")]
        public static extern int GetParamFloatInt(IntPtr model, int key, out float ret);

        [DllImport("L2DNative.dll")]
        public static extern int GetParamFloatString(IntPtr model, IntPtr key, out float ret);

        [DllImport("L2DNative.dll")]
        public static extern int AddToParamFloat(IntPtr model, IntPtr key, float value);

        [DllImport("L2DNative.dll")]
        public static extern int MultParamFloat(IntPtr model, IntPtr key, float value);

        [DllImport("L2DNative.dll")]
        public static extern int SetPartsOpacityInt(IntPtr model, int key, float value);

        [DllImport("L2DNative.dll")]
        public static extern int SetPartsOpacityString(IntPtr model, IntPtr key, float value);

        [DllImport("L2DNative.dll")]
        public static extern int GetPartsOpacityInt(IntPtr model, int key, out float ret);

        [DllImport("L2DNative.dll")]
        public static extern int GetPartsOpacityString(IntPtr model, IntPtr key, out float ret);

        [DllImport("L2DNative.dll")]
        public static extern int GetParamIndex(IntPtr model, IntPtr key, out int ret);

        [DllImport("L2DNative.dll")]
        public static extern int GetPartsDataIndex(IntPtr model, IntPtr key, out int ret);

        [DllImport("L2DNative.dll")]
        public static extern int SaveParam(IntPtr model);

        [DllImport("L2DNative.dll")]
        public static extern int LoadParam(IntPtr model);

        [DllImport("L2DNative.dll")]
        public static extern int LoadMotion(IntPtr motionPath, out long ret);

        [DllImport("L2DNative.dll")]
        public static extern int UpdateMotion(IntPtr model, out bool ret);

        [DllImport("L2DNative.dll")]
        public static extern int EyeBlinkUpdate(IntPtr model);

        [DllImport("L2DNative.dll")]
        public static extern int SetFadeIn(IntPtr motion, int msec);

        [DllImport("L2DNative.dll")]
        public static extern int SetFadeOut(IntPtr motion, int msec);

        [DllImport("L2DNative.dll")]
        public static extern int SetLoop(IntPtr motion, bool loop);

        [DllImport("L2DNative.dll")]
        public static extern int StartMotion(IntPtr motion);

        [DllImport("L2DNative.dll")]
        public static extern int CreatePhysics(out long ret);

        [DllImport("L2DNative.dll")]
        public static extern int PhysicsSetup(IntPtr physicsHandler, float baseLengthM, float airRegistance, float mass);

        [DllImport("L2DNative.dll")]
        public static extern int PhysicsUpdate(IntPtr physicsHandler, IntPtr model, long time);

        [DllImport("L2DNative.dll")]
        public static extern int PhysicsAddSrcParam(IntPtr physicsHandler, IntPtr srcType, IntPtr paramID, float scale, float weight);

        [DllImport("L2DNative.dll")]
        public static extern int PhysicsAddTargetParam(IntPtr physicsHandler, IntPtr targetType, IntPtr paramID, float scale, float weight);

        [DllImport("L2DNative.dll")]
        public static extern int CreateExpression(out long ret);

        [DllImport("L2DNative.dll")]
        public static extern int StartExpression(IntPtr expression);

        [DllImport("L2DNative.dll")]
        public static extern int ExpressionSetFadeIn(IntPtr expression, int msec);

        [DllImport("L2DNative.dll")]
        public static extern int ExpressionSetFadeOut(IntPtr expression, int msec);

        [DllImport("L2DNative.dll")]
        public static extern int ExpressionAddParam(IntPtr expression, IntPtr paramID, IntPtr calc, float value, float defaultValue);

        [DllImport("L2DNative.dll")]
        public static extern int ExpressionAddParamV09(IntPtr expression, IntPtr paramID, float value, float defaultValue);

        [DllImport("L2DNative.dll")]
        public static extern int UpdateExpression(IntPtr model, out bool ret);

        [DllImport("L2DNative.dll")]
        public static extern int BeginRender(IntPtr model);

        [DllImport("L2DNative.dll")]
        public static extern int EndRender(IntPtr model);

        [DllImport("L2DNative.dll")]
        public static extern int Dispose();

        [DllImport("L2DNative.dll")]
        public static extern int GetUserTimeMSec(out long ret);
        #endregion

        #region DirectX
        /// <summary>
        /// 设置渲染区域的大小。
        /// </summary>
        [DllImport("L2DNative.dll")]
        public static extern int SetSize(uint width, uint height);

        /// <summary>
        /// 设置一个值，指示渲染时是否支持透明度。
        /// </summary>
        [DllImport("L2DNative.dll")]
        public static extern int SetAlpha(bool useAlpha);

        /// <summary>
        /// 设置渲染时要使用的多重采样消除锯齿值。
        /// </summary>
        [DllImport("L2DNative.dll")]
        public static extern int SetNumDesiredSamples(uint numSamples);

        /// <summary>
        /// 获取当前渲染表面而不添加引用。
        /// </summary>
        [DllImport("L2DNative.dll")]
        public static extern int GetBackBufferNoRef(out IntPtr pSurface);

        /// <summary>
        /// 设置用于呈现的适配器。
        /// </summary>
        [DllImport("L2DNative.dll")]
        public static extern int SetAdapter(NativeStructure.POINT screenSpacePoint);

        /// <summary>
        /// 调用目标的析构函数。
        /// </summary>
        [DllImport("L2DNative.dll")]
        public static extern int Destroy();
        #endregion
    }
}
