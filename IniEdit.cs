using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

// 这个是读写INI的类

namespace Program
{
    public class IniEdit
    {
        /// <summary>
        /// ini文件路径
        /// </summary>
        string inipath;

        #region API函数声明
        [DllImport("kernel32")] private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")] private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32")] private static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, byte[] lpReturnedString, uint nSize, string lpFileName);
        #endregion

        /// <summary> 
        /// 构造方法 定义文件路径
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

}
