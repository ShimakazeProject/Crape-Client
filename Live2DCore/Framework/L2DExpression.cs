using System;
using System.Runtime.InteropServices;
using L2DLib.Core;

namespace L2DLib.Framework
{
    /// <summary>
    /// 它提供与Live2D面部表情相关的功能。
    /// </summary>
    public class L2DExpression : L2DBase
    {
        #region 属性
        /// <summary>
        /// 获取表达式的淡入淡出时间。
        /// </summary>
        public int FadeIn
        {
            get { return _FadeIn; }
        }
        private int _FadeIn;

        /// <summary>
        /// 获取面部表情的淡出时间。
        /// </summary>
        public int FadeOut
        {
            get { return _FadeOut; }
        }
        private int _FadeOut;
        #endregion

        #region 构造函数
        /// <summary>
        /// 创建一个面部表情目标。
        /// </summary>
        public L2DExpression()
        {
            HRESULT.Check(NativeMethods.CreateExpression(out _Handle));
            _IsLoaded = true;
        }
        #endregion

        #region 用户功能
        /// <summary>
        /// 开始播放表达式。
        /// </summary>
        public void StartExpression()
        {
            HRESULT.Check(NativeMethods.StartExpression(new IntPtr(Handle)));
        }

        /// <summary>
        /// 向表达式添加标准格式参数。
        /// </summary>
        /// <param name="paramID">参数的唯一值。</param>
        /// <param name="calc">参数的计算格式。</param>
        /// <param name="value">参数的值。</param>
        /// <param name="defaultValue">参数的默认值。</param>
        public void AddParam(string paramID, string calc, float value, float defaultValue)
        {
            HRESULT.Check(NativeMethods.ExpressionAddParam(new IntPtr(Handle), Marshal.StringToHGlobalAnsi(paramID), Marshal.StringToHGlobalAnsi(calc), value, defaultValue));
        }

        /// <summary>
        /// 将旧版本的参数附加到表达式。
        /// </summary>
        /// <param name="paramID">参数的唯一值。</param>
        /// <param name="value">参数的值。</param>
        /// <param name="defaultValue">参数的默认值。</param>
        public void AddParamV09(string paramID, string calc, float value, float defaultValue)
        {
            HRESULT.Check(NativeMethods.ExpressionAddParamV09(new IntPtr(Handle), Marshal.StringToHGlobalAnsi(paramID), value, defaultValue));
        }

        /// <summary>
        /// 设置面部表情的淡入时间。
        /// </summary>
        /// <param name="msec">动画的时间（以毫秒为单位）。</param>
        public void SetFadeIn(int msec)
        {
            HRESULT.Check(NativeMethods.ExpressionSetFadeIn(new IntPtr(Handle), msec));
            _FadeIn = msec;
        }

        /// <summary>
        /// 设置面部表情的淡出时间。
        /// </summary>
        /// <param name="msec">动画的时间（以毫秒为单位）。</param>
        public void SetFadeOut(int msec)
        {
            HRESULT.Check(NativeMethods.ExpressionSetFadeOut(new IntPtr(Handle), msec));
            _FadeOut = msec;
        }
        #endregion
    }
}
