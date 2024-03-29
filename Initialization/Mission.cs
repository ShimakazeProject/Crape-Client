﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crape_Client.CrapeClientCore;
using Crape_Client.Global;

namespace Crape_Client.Initialization
{
    class Mission
    {
        #region 任务
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
        public Mission()
        {
            IniSection[] SectionList = (IniSection[])Globals.MissionConfig.SectionList.ToArray(typeof(IniSection));
            if (SectionList.Length < 1) return;
            for (uint i = 0; i < SectionList.Length; i++)
            {
                #region 消除中文乱码
                Globals.MissionConfig.WriteValue(
                    SectionList[i].SectionName
                    , "Name"
                    , IniIO.Readvalue(
                        SectionList[i].SectionName
                        , "Name"
                        , Globals.ConfigsDir + "Missions.ini"
                        )
                    );
                Globals.MissionConfig.WriteValue(
                    SectionList[i].SectionName
                    , "Summary"
                    , IniIO.Readvalue(
                        SectionList[i].SectionName
                        , "Summary"
                        , Globals.ConfigsDir + "Missions.ini"
                        )
                    );
                #endregion
                int side = Globals.MissionConfig.ReadValue(SectionList[i].SectionName, "Side", 0);
                NameList.Add(side, Globals.MissionConfig.ReadValue(SectionList[i].SectionName, "Name", null));
                SectionNameList.Add(side, SectionList[i].SectionName);
            }
        }
        #endregion

    }
}
