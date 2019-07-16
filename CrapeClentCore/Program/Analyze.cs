using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class IniAnalyze
    {
        #region 任务分析
        public static void MissionAnalyze()
        {
            IniEdit iniEdit = new IniEdit(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Configs\Missions.ini");
            List<string> SectionList = iniEdit.ReadSections();
            string[] str = SectionList.ToArray();
            if (str.Length < 1) return;

            // System.Windows.MessageBox.Show(Convert.ToString(str.Length));
            for (uint i = 0; i < str.Length; i++)
            {

                string ret = iniEdit.IniReadValue(str[i], "Side");
                switch (Convert.ToByte(ret))
                {
                    case 0:
                        MissionSideAnalyze.side0.Add(iniEdit.IniReadValue(str[i], "Name"));
                        MissionSideName.side0.Add(str[i]);
                        break;
                    case 1:
                        MissionSideAnalyze.side1.Add(iniEdit.IniReadValue(str[i], "Name"));
                        MissionSideName.side1.Add(str[i]);
                        break;
                    case 2:
                        MissionSideAnalyze.side2.Add(iniEdit.IniReadValue(str[i], "Name"));
                        MissionSideName.side2.Add(str[i]);
                        break;
                    case 3:
                        MissionSideAnalyze.side3.Add(iniEdit.IniReadValue(str[i], "Name"));
                        MissionSideName.side3.Add(str[i]);
                        break;
                    case 4:
                        MissionSideAnalyze.side4.Add(iniEdit.IniReadValue(str[i], "Name"));
                        MissionSideName.side4.Add(str[i]);
                        break;
                    case 5:
                        MissionSideAnalyze.side5.Add(iniEdit.IniReadValue(str[i], "Name"));
                        MissionSideName.side5.Add(str[i]);
                        break;
                    case 6:
                        MissionSideAnalyze.side6.Add(iniEdit.IniReadValue(str[i], "Name"));
                        MissionSideName.side6.Add(str[i]);
                        break;
                    case 7:
                        MissionSideAnalyze.side7.Add(iniEdit.IniReadValue(str[i], "Name"));
                        MissionSideName.side7.Add(str[i]);
                        break;
                    case 8:
                        MissionSideAnalyze.side8.Add(iniEdit.IniReadValue(str[i], "Name"));
                        MissionSideName.side8.Add(str[i]);
                        break;
                    case 9:
                        MissionSideAnalyze.side9.Add(iniEdit.IniReadValue(str[i], "Name"));
                        MissionSideName.side9.Add(str[i]);
                        break;

                }
            }
        }
        public class MissionSideAnalyze
        {
            public static List<string> side0 = new List<string>();
            public static List<string> side1 = new List<string>();
            public static List<string> side2 = new List<string>();
            public static List<string> side3 = new List<string>();
            public static List<string> side4 = new List<string>();
            public static List<string> side5 = new List<string>();
            public static List<string> side6 = new List<string>();
            public static List<string> side7 = new List<string>();
            public static List<string> side8 = new List<string>();
            public static List<string> side9 = new List<string>();
            public static void Clear()
            {
                side0 = new List<string>();
                side1 = new List<string>();
                side2 = new List<string>();
                side3 = new List<string>();
                side4 = new List<string>();
                side5 = new List<string>();
                side6 = new List<string>();
                side7 = new List<string>();
                side8 = new List<string>();
                side9 = new List<string>();
            }
        }
        public class MissionSideName
        {
            public static List<string> side0 = new List<string>();
            public static List<string> side1 = new List<string>();
            public static List<string> side2 = new List<string>();
            public static List<string> side3 = new List<string>();
            public static List<string> side4 = new List<string>();
            public static List<string> side5 = new List<string>();
            public static List<string> side6 = new List<string>();
            public static List<string> side7 = new List<string>();
            public static List<string> side8 = new List<string>();
            public static List<string> side9 = new List<string>();
            public static void Clear()
            {
                side0 = new List<string>();
                side1 = new List<string>();
                side2 = new List<string>();
                side3 = new List<string>();
                side4 = new List<string>();
                side5 = new List<string>();
                side6 = new List<string>();
                side7 = new List<string>();
                side8 = new List<string>();
                side9 = new List<string>();
            }
        }

        #endregion


    }

}
