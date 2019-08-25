using System.Linq;
using System.Collections.Generic;

namespace L2DLib.Framework
{
    public class L2DPose
    {
        #region 属性
        /// <summary>
        /// 设置或获取零件组。
        /// </summary>
        public List<L2DParts>[] Groups
        {
            get { return _Groups; }
            set { _Groups = value; }
        }
        private List<L2DParts>[] _Groups;

        /// <summary>
        /// 设置或获取淡入淡出时间。
        /// </summary>
        public int FadeTime
        {
            get { return _FadeTime; }
            set { _FadeTime = value; }
        }
        private int _FadeTime = 500;
        #endregion

        #region 对象
        L2DModel lastModel;
        #endregion

        #region 内部功能
        private void InitializeParam(L2DModel model)
        {
            int offset = 0;
            for (int i = 0; i < Groups.Count(); i++)
            {
                for (int j = 0; j < Groups[i].Count(); j++)
                {
                    L2DParts parts = Groups[i][j];
                    parts.InitializeIDX(model);

                    int partsIDX = parts.PartsIDX;
                    int paramIDX = parts.ParamIDX;
                    if (partsIDX < 0) continue;

                    model.SetPartsOpacity(partsIDX, j == offset ? 1.0f : 0.0f);
                    model.SetParamFloat(paramIDX, j == offset ? 1.0f : 0.0f);

                    foreach (L2DParts link in parts.Link)
                    {
                        link.InitializeIDX(model);
                    }
                }

                offset += i;
            }
        }
        #endregion

        #region 用户功能
        public void UpdateParam(L2DModel model)
        {
            if (model != lastModel)
            {
                InitializeParam(model);
            }
            lastModel = model;

            foreach (List<L2DParts> partsList in Groups)
            {
                foreach (L2DParts parts in partsList)
                {
                    int partsIDX = parts.PartsIDX;
                    int paramIDX = parts.ParamIDX;
                    if (partsIDX < 0) continue;

                    bool visible = (model.GetParamFloat(paramIDX) != 0);
                    model.SetPartsOpacity(partsIDX, (visible ? 1.0f : 0.0f));
                    model.SetParamFloat(paramIDX, (visible ? 1.0f : 0.0f));
                }
            }
        }
        #endregion
    }
}