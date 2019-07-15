using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Program
{
    public class IniEdit
    {
        /// <summary>
        /// ini文件路径
        /// </summary>
        public string inipath;
        //声明API函数
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(
            string section, 
            string key, 
            string def, 
            StringBuilder retVal, 
            int size, 
            string filePath);
        [DllImport("kernel32")]
        private static extern uint GetPrivateProfileString(
            string lpAppName, // points to section name
            string lpKeyName, // points to key name
            string lpDefault, // points to default string
            byte[] lpReturnedString, // points to destination buffer
            uint nSize, // size of destination buffer
            string lpFileName  // points to initialization filename
        ); 

        /// <summary> 
        /// 构造方法 
        /// </summary> 
        /// <param name="INIPath">文件路径</param> 
        public IniEdit(string INIPath)
        {
            inipath = INIPath;
        }
        #region 方法
        /// <summary> 
        /// 写入INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        /// <param name="Value">值</param> 
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.inipath);
        }
        /// <summary> 
        /// 读出INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", temp, 500, this.inipath);
            return temp.ToString();
        }
        /// <summary>
        /// 读取section
        /// </summary>
        /// <returns></returns>
        public List<string> ReadSections()
        {
            List<string> result = new List<string>();
            byte[] buf = new byte[65536];
            uint len = GetPrivateProfileString(null, null, null, buf, (uint)buf.Length, inipath);
            int j = 0;
            for (int i = 0; i < len; i++)
                if (buf[i] == 0)
                {
                    result.Add(Encoding.Default.GetString(buf, j, i - j));
                    j = i + 1;
                }
            return result;
        }
        /// <summary>
        /// 读取指定区域Keys列表。
        /// </summary>
        /// <param name="Section"></param>
        /// <returns></returns>
        public List<string> ReadSingleSection(string Section)
        {
            List<string> result = new List<string>();
            byte[] buf = new byte[65536];
            uint lenf = GetPrivateProfileString(Section, null, null, buf, (uint)buf.Length, inipath);
            int j = 0;
            for (int i = 0; i < lenf; i++)
                if (buf[i] == 0)
                {
                    result.Add(Encoding.Default.GetString(buf, j, i - j));
                    j = i + 1;
                }
            return result;
        }

        #endregion
    }
    public class IniAnalyze
    {
        #region 任务分析
        public static void MessionAnalyze()
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
    public class Program
    {
        public static string SummaryInit(string str)// 处理字符串
        {
            str = str.Replace(@"\[n]", "\r\n");// 换行符号
            str = str.Replace(@"\[t]", "\t");// 横向制表符号
            str = str.Replace(@"\[v]", "\v");// 纵向制表符号
            return str;
        }
    }
}
