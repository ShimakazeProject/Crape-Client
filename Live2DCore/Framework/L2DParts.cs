namespace L2DLib.Framework
{
    public class L2DParts
    {
        #region 属性
        /// <summary>
        /// 获取零件的目标参数值。
        /// </summary>
        public string ID
        {
            get { return _ID; }
        }
        private string _ID = null;

        /// <summary>
        /// 获取零件的参数索引。
        /// </summary>
        public int ParamIDX
        {
            get { return _ParamIDX; }
        }
        private int _ParamIDX = -1;

        /// <summary>
        /// 获取零件的零件索引。
        /// </summary>
        public int PartsIDX
        {
            get { return _PartsIDX; }
        }
        private int _PartsIDX = -1;

        /// <summary>
        /// 获取与零件关联的零件列表。
        /// </summary>
        public L2DParts[] Link
        {
            get { return _Link; }
        }
        private L2DParts[] _Link = null;
        #endregion

        #region 构造函数
        public L2DParts(string ID)
        {
            _ID = ID;
        }

        public L2DParts(string ID, L2DParts[] Link)
        {
            _ID = ID;
            _Link = Link;
        }
        #endregion

        #region 用户功能
        public void InitializeIDX(L2DModel model)
        {
            _ParamIDX = model.GetParamIndex("VISIBLE:" + ID);
            _PartsIDX = model.GetPartsDataIndex(ID);
            model.SetParamFloat(ParamIDX, 1);
        }
        #endregion
    }
}
