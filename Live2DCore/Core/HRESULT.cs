using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace L2DLib.Core
{
    /// <summary>
    /// 在与L2DNative库互操作时提供返回值处理。
    /// </summary>
    public static class HRESULT
    {
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static void Check(int hr)
        {
            Marshal.ThrowExceptionForHR(hr);
        }
    }
}
