using System;

namespace L2DLib.Utility
{
    public class NoMotionException : ApplicationException //Exception
    {
        #region 构造方法
        public NoMotionException() { }
        public NoMotionException(string message)
            : base(message) { }
        public NoMotionException(string message, Exception inner)
            : base(message, inner) { }
        #endregion
    }
}
