using System.Windows;
using System.Runtime.InteropServices;

namespace L2DLib.Core
{
    /// <summary>
    /// 提供与L2DNative库互操作的工具。
    /// </summary>
    class NativeStructure
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public POINT(Point p)
            {
                x = (int)p.X;
                y = (int)p.Y;
            }

            public int x;
            public int y;
        }
    }
}
