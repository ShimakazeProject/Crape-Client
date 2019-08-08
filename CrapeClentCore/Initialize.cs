using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Crape_Client.CrapeClientCore
{
    class Initialization
    {
        public static void SavesListInit()
        {
            DirectoryInfo folder = new DirectoryInfo(Global.LocalPath + Global.SavesDir);
            try
            {
                foreach (FileInfo file in folder.GetFiles("*.sav"))
                {
                    //Console.WriteLine(file.FullName);
                    Global.SaveFilesList.Add(new Cls_SaveFiles
                    {
                        Name = GameSaveFile.LoadSaveName(File.ReadAllBytes(file.FullName)),
                        Date = file.LastWriteTime.ToString(),
                        FileN = file.Name
                    });// FullName?
                }
            }
            catch (DirectoryNotFoundException)
            {
                Global.SaveFilesList.Add(new Cls_SaveFiles
                {
                    Name = "没有发现可用存档",
                    Date = "",
                    FileN = ""
                });
            }
        }
        public class NameList
        {
            public static List<string> Side0 { get; } = new List<string>();
            public static List<string> Side1 { get; } = new List<string>();
            public static List<string> Side2 { get; } = new List<string>();
            public static List<string> Side3 { get; } = new List<string>();
            public static List<string> Side4 { get; } = new List<string>();
            public static List<string> Side5 { get; } = new List<string>();
            public static List<string> Side6 { get; } = new List<string>();
            public static List<string> Side7 { get; } = new List<string>();
            public static List<string> Side8 { get; } = new List<string>();
            public static List<string> Side9 { get; } = new List<string>();
            public static void Add(int Side, string Item)
            {
                switch (Side)
                {
                    case 0:
                        Side0.Add(Item);
                        break;
                    case 1:
                        Side1.Add(Item);
                        break;
                    case 2:
                        Side2.Add(Item);
                        break;
                    case 3:
                        Side3.Add(Item);
                        break;
                    case 4:
                        Side4.Add(Item);
                        break;
                    case 5:
                        Side5.Add(Item);
                        break;
                    case 6:
                        Side6.Add(Item);
                        break;
                    case 7:
                        Side7.Add(Item);
                        break;
                    case 8:
                        Side8.Add(Item);
                        break;
                    case 9:
                        Side9.Add(Item);
                        break;
                }
            }
        }
        public class SectionNameList
        {
            public static List<string> Side0 { get; } = new List<string>();
            public static List<string> Side1 { get; } = new List<string>();
            public static List<string> Side2 { get; } = new List<string>();
            public static List<string> Side3 { get; } = new List<string>();
            public static List<string> Side4 { get; } = new List<string>();
            public static List<string> Side5 { get; } = new List<string>();
            public static List<string> Side6 { get; } = new List<string>();
            public static List<string> Side7 { get; } = new List<string>();
            public static List<string> Side8 { get; } = new List<string>();
            public static List<string> Side9 { get; } = new List<string>();
            public static void Add(int Side, string Item)
            {
                switch (Side)
                {
                    case 0:
                        Side0.Add(Item);
                        break;
                    case 1:
                        Side1.Add(Item);
                        break;
                    case 2:
                        Side2.Add(Item);
                        break;
                    case 3:
                        Side3.Add(Item);
                        break;
                    case 4:
                        Side4.Add(Item);
                        break;
                    case 5:
                        Side5.Add(Item);
                        break;
                    case 6:
                        Side6.Add(Item);
                        break;
                    case 7:
                        Side7.Add(Item);
                        break;
                    case 8:
                        Side8.Add(Item);
                        break;
                    case 9:
                        Side9.Add(Item);
                        break;
                }
            }
        }
        public static void MissionConfigAnalyze()
        {
            IniSection[] SectionList = (IniSection[])Global.MissionConfig.SectionList.ToArray(typeof(IniSection));
            if (SectionList.Length < 1) return;
            for (uint i = 0; i < SectionList.Length; i++)
            {
                #region 消除中文乱码
                Global.MissionConfig.WriteValue(
                    SectionList[i].SectionName
                    , "Name"
                    , IniIO.ReadValue(
                        SectionList[i].SectionName
                        , "Name"
                        , Global.LocalPath + Global.ConfigsDir + "Missions.ini"
                        )
                    );
                Global.MissionConfig.WriteValue(
                    SectionList[i].SectionName
                    , "Summary"
                    , IniIO.ReadValue(
                        SectionList[i].SectionName
                        , "Summary"
                        , Global.LocalPath + Global.ConfigsDir + "Missions.ini"
                        )
                    );
                #endregion
                int side = Global.MissionConfig.ReadValue(SectionList[i].SectionName, "Side", 0);
                NameList.Add(side, Global.MissionConfig.ReadValue(SectionList[i].SectionName, "Name", null));
                SectionNameList.Add(side, SectionList[i].SectionName);
            }
        }

        static void Skirmish()
        {
            MemIniFile skir = new MemIniFile();
            skir.LoadFromFile(@"Resource\Configs\Skirmish.ini");
            InitConf.TeamNum = skir.ReadValue("SKIRMISH", "TeamNum", 4);
            InitConf.ColorNum = skir.ReadValue("SKIRMISH", "Side", 8);
            InitConf.SideNum = skir.ReadValue("SKIRMISH", "Color", 12);
            SkirmishSide(skir);
            SkirmishColor(skir);


            





        }
        static void SkirmishSide(MemIniFile skir)
        {
            for (int i = 0; i <= InitConf.SideNum; i++) 
            {
                string Value = skir.ReadValue("SIDE", i.ToString(), "");
                if (RandomCheck(Value))
                {
                    string[] maxMin;
                    maxMin = Value.Split('-');
                    Format1 format = new Format1
                    {
                        Num = Convert.ToInt16(maxMin[0]),
                        Max = Convert.ToInt16(maxMin[1]),
                        Readom = true
                    };

                    SkirConf.Side.Add(format);
                }
                else
                {
                    Format1 format = new Format1
                    {
                        Num = Convert.ToInt16(Value),
                        Max = null,
                        Readom = false
                    };
                    SkirConf.Side.Add(format);
                }
            }
        }
        static void SkirmishColor(MemIniFile skir)
        {
            for (int i = 0; i <= InitConf.ColorNum; i++)
            {
                string Value = skir.ReadValue("COLOR", i.ToString(), "");
                if (RandomCheck(Value))
                {
                    string[] maxMin;
                    maxMin = Value.Split('-');
                    Format1 format = new Format1
                    {
                        Num = Convert.ToInt16(maxMin[0]),
                        Max = Convert.ToInt16(maxMin[1]),
                        Readom = true
                    };
                    SkirConf.Color.Add(format);
                }
                else
                {
                    Format1 format = new Format1
                    {
                        Num = Convert.ToInt16(Value),
                        Max = null,
                        Readom = false
                    };
                    SkirConf.Color.Add(format);
                }
            }
        }
        static bool RandomCheck(string Value)
        {
            if (Value.IndexOf("-") < 0)
                return false;
            else return true;
        }
    }
}
