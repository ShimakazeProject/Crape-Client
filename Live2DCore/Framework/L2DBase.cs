namespace L2DLib.Framework
{
    /// <summary>
    /// Live2D目标的顶级抽象类。
    /// </summary>
    public abstract class L2DBase
    {
        /// <summary>
        /// 获取目标的句柄。
        /// </summary>
        public long Handle
        {
            get { return _Handle; }
        }
        protected long _Handle = 0;

        /// <summary>
        /// 获取目标是否已加载。
        /// </summary>
        public bool IsLoaded
        {
            get { return _IsLoaded; }
        }
        protected bool _IsLoaded = false;
    }
}
