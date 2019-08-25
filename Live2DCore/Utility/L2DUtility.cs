using L2DLib.Core;

namespace L2DLib.Utility
{
    /// <summary>
    /// Live2D 提供与面板相关的功能。
    /// </summary>
    public class L2DUtility
    {
        /// <summary>
        /// 释放所有获得的资源。
        /// </summary>
        public static void Dispose()
        {
            HRESULT.Check(NativeMethods.Dispose());
        }

        /// <summary>
        /// 从渲染器获取用户时间。
        /// </summary>
        /// <returns>渲染器获取用户时间</returns>
        public static long GetUserTimeMSec()
        {
            long result = 0;
            HRESULT.Check(NativeMethods.GetUserTimeMSec(out result));

            return result;
        }
    }
}
