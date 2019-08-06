using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections;

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
            try
            {
                int i = GetPrivateProfileString(Section, Key, "", temp, 500, this.inipath);
                return temp.ToString();
            }
            catch(FormatException){ return ""; }
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
    public class IniTools
    {

        public static bool BoolCheck(string Value)
        {
            string str = StringTools.SubString(Value, 1);
            if (str == "1")
                return true;
            else if (str.ToUpper() == "T")
                return true;
            else if (str.ToUpper() == "Y")
                return true;
            else return false;
        }
    }
    /// <summary>
    /// Ini节点
    /// </summary>
    public class IniSection
    {
        private Dictionary<string, string> FDictionary;//节点值
        private String FSectionName;//节点名称
        public IniSection(String SName)
        {
            FSectionName = SName;
            FDictionary = new Dictionary<string, string>();
        }

        public string SectionName
        {
            get { return FSectionName; }
        }

        public int Count
        {
            get { return FDictionary.Count; }
        }

        public void Clear()
        {
            FDictionary.Clear();
        }

        /// <summary>
        /// 增加键值对
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void AddKeyValue(string key, string value)
        {
            if (FDictionary.ContainsKey(key))
                FDictionary[key] = value;
            else
                FDictionary.Add(key, value);
        }

        public void WriteValue(string key, string value)
        {
            AddKeyValue(key, value);
        }

        public void WriteValue(string key, bool value)
        {
            AddKeyValue(key, Convert.ToString(value));
        }

        public void WriteValue(string key, int value)
        {
            AddKeyValue(key, Convert.ToString(value));
        }

        public void WriteValue(string key, float value)
        {
            AddKeyValue(key, Convert.ToString(value));
        }

        public void WriteValue(string key, DateTime value)
        {
            AddKeyValue(key, Convert.ToString(value));
        }

        public string ReadValue(string key, string defaultv)
        {
            if (FDictionary.ContainsKey(key))
                return FDictionary[key];
            else
                return defaultv;
        }

        public bool ReadValue(string key, bool defaultv)
        {
            string rt = ReadValue(key, Convert.ToString(defaultv));
            return Convert.ToBoolean(rt);
        }

        public int ReadValue(string key, int defaultv)
        {
            string rt = ReadValue(key, Convert.ToString(defaultv));
            return Convert.ToInt32(rt);
        }

        public float ReadValue(string key, float defaultv)
        {
            string rt = ReadValue(key, Convert.ToString(defaultv));
            return Convert.ToSingle(rt);
        }

        public DateTime ReadValue(string key, DateTime defaultv)
        {
            string rt = ReadValue(key, Convert.ToString(defaultv));
            return Convert.ToDateTime(rt);
        }

        public void SaveToStream(Stream stream)
        {
            StreamWriter SW = new StreamWriter(stream);
            SaveToStream(SW);
            SW.Dispose();
        }

        public void SaveToStream(StreamWriter SW)
        {
            SW.WriteLine("[" + FSectionName + "]");
            foreach (KeyValuePair<string, string> item in FDictionary)
            {
                SW.WriteLine(item.Key + "=" + item.Value);
            }

        }
    }

    /// <summary>
    /// 内存Ini解析
    /// </summary>
    public class MemIniFile
    {
        private ArrayList List;//所有节点信息

        private bool SectionExists(string SectionName)
        {
            foreach (IniSection ISec in List)
            {
                if (ISec.SectionName.ToLower() == SectionName.ToLower())
                    return true;
            }
            return false;
        }

        public IniSection FindSection(string SectionName)
        {
            foreach (IniSection ISec in List)
            {
                if (ISec.SectionName.ToLower() == SectionName.ToLower())
                    return ISec;
            }
            return null;
        }

        public MemIniFile()
        {
            List = new ArrayList();
        }

        public void LoadFromStream(Stream stream)
        {
            StreamReader SR = new StreamReader(stream);
            List.Clear();
            string st = null;
            IniSection Section = null;//节点
            int equalSignPos;
            string key, value;
            while (true)
            {
                st = SR.ReadLine();
                if (st == null)
                    break;
                st = st.Trim();
                if (st == "")
                    continue;
                if (st != "" && st[0] == '[' && st[st.Length - 1] == ']')
                {
                    st = st.Remove(0, 1);
                    st = st.Remove(st.Length - 1, 1);
                    Section = FindSection(st);
                    if (Section == null)
                    {
                        Section = new IniSection(st);
                        List.Add(Section);
                    }
                }
                else
                {
                    if (Section == null)
                    {
                        Section = FindSection("UnDefSection");
                        if (Section == null)
                        {
                            Section = new IniSection("UnDefSection");
                            List.Add(Section);
                        }
                    }
                    //开始解析         
                    equalSignPos = st.IndexOf('=');
                    if (equalSignPos != 0)
                    {
                        key = st.Substring(0, equalSignPos);
                        value = st.Substring(equalSignPos + 1, st.Length - equalSignPos - 1);
                        Section.AddKeyValue(key, value);//增加到节点
                    }
                    else
                        Section.AddKeyValue(st, "");
                }
            }
            SR.Dispose();
        }

        public void SaveToStream(Stream stream)
        {
            StreamWriter SW = new StreamWriter(stream);
            foreach (IniSection ISec in List)
            {
                ISec.SaveToStream(SW);
            }
            SW.Dispose();
        }
        /// <summary>
        /// 读取键值
        /// </summary>
        /// <param name="SectionName">节</param>
        /// <param name="key">键</param>
        /// <param name="defaultv">默认</param>
        /// <returns>键值</returns>
        public string ReadValue(string SectionName, string key, string defaultv)
        {
            IniSection ISec = FindSection(SectionName);
            if (ISec != null)
            {
                return ISec.ReadValue(key, defaultv);
            }
            else return defaultv;
        }

        public bool ReadValue(string SectionName, string key, bool defaultv)
        {
            IniSection ISec = FindSection(SectionName);
            if (ISec != null)
            {
                return ISec.ReadValue(key, defaultv);
            }
            else return defaultv;
        }

        public int ReadValue(string SectionName, string key, int defaultv)
        {
            IniSection ISec = FindSection(SectionName);
            if (ISec != null)
            {
                return ISec.ReadValue(key, defaultv);
            }
            else return defaultv;
        }

        public float ReadValue(string SectionName, string key, float defaultv)
        {
            IniSection ISec = FindSection(SectionName);
            if (ISec != null)
            {
                return ISec.ReadValue(key, defaultv);
            }
            else return defaultv;
        }

        public DateTime ReadValue(string SectionName, string key, DateTime defaultv)
        {
            IniSection ISec = FindSection(SectionName);
            if (ISec != null)
            {
                return ISec.ReadValue(key, defaultv);
            }
            else return defaultv;
        }

        public IniSection WriteValue(string SectionName, string key, string value)
        {
            IniSection ISec = FindSection(SectionName);
            if (ISec == null)
            {
                ISec = new IniSection(SectionName);
                List.Add(ISec);
            }
            ISec.WriteValue(key, value);
            return ISec;
        }

        public IniSection WriteValue(string SectionName, string key, bool value)
        {
            IniSection ISec = FindSection(SectionName);
            if (ISec == null)
            {
                ISec = new IniSection(SectionName);
                List.Add(ISec);
            }
            ISec.WriteValue(key, value);
            return ISec;
        }

        public IniSection WriteValue(string SectionName, string key, int value)
        {
            IniSection ISec = FindSection(SectionName);
            if (ISec == null)
            {
                ISec = new IniSection(SectionName);
                List.Add(ISec);
            }
            ISec.WriteValue(key, value);
            return ISec;
        }

        public IniSection WriteValue(string SectionName, string key, float value)
        {
            IniSection ISec = FindSection(SectionName);
            if (ISec == null)
            {
                ISec = new IniSection(SectionName);
                List.Add(ISec);
            }
            ISec.WriteValue(key, value);
            return ISec;
        }

        public IniSection WriteValue(string SectionName, string key, DateTime value)
        {
            IniSection ISec = FindSection(SectionName);
            if (ISec == null)
            {
                ISec = new IniSection(SectionName);
                List.Add(ISec);
            }
            ISec.WriteValue(key, value);
            return ISec;
        }

        public void LoadFromFile(string FileName)
        {
            FileStream FS = new FileStream(System.IO.Path.GetFullPath(FileName), FileMode.Open);
            LoadFromStream(FS);
            FS.Close();
            FS.Dispose();
        }

        public void SaveToFile(string FileName)
        {
            FileStream FS = new FileStream(System.IO.Path.GetFullPath(FileName), FileMode.Create);
            SaveToStream(FS);
            FS.Close();
            FS.Dispose();
        }
    }

}
