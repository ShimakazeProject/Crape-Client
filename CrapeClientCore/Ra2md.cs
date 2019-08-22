using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Crape_Client.CrapeClientCore
{
    class IniIO
    {
        [DllImport("kernel32")] private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")] private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        static void Writevalue(string Section, string Key, string value)
        {
            WritePrivateProfileString(Section, Key, value, Global.Globals.LocalPath + "ra2md.ini");
        }
        static string Readvalue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            try
            {
                int i = GetPrivateProfileString(Section, Key, "", temp, 500, Global.Globals.LocalPath + "ra2md.ini");
                return temp.ToString();
            }
            catch (FormatException) { return ""; }
        }
        public static void Writevalue(string Section, string Key, string value, string Path)
        {
            WritePrivateProfileString(Section, Key, value, Path);
        }
        public static string Readvalue(string Section, string Key, string Path)
        {
            StringBuilder temp = new StringBuilder(500);
            try
            {
                int i = GetPrivateProfileString(Section, Key, "", temp, 500, Path);
                return temp.ToString();
            }
            catch (FormatException) { return ""; }
        }
        #region
        public static void I(string Section, string Key, bool value)
        {
            if (value)
                Writevalue(Section, Key, "1");
            else Writevalue(Section, Key, "0");
        }
        public static void I(string Section, string Key, Int64 value)
        {
            Writevalue(Section, Key, value.ToString());
        }
        public static void I(string Section, string Key, double value)
        {
            Writevalue(Section, Key, value.ToString());
        }
        public static void I(string Section, string Key, string value)
        {
            Writevalue(Section, Key, value);
        }
        public static bool Obool(string Section, string Key)
        {
            try
            {
                string value = Readvalue(Section, Key);
                return IniTools.BoolCheck(value);

            }
            catch (FormatException) { return false; }
        }
        public static int Oint(string Section, string Key)
        {
            try
            {
                return Convert.ToInt32(Readvalue(Section, Key));
            }
            catch (FormatException) { return -1; }
        }
        public static double Odouble(string Section, string Key)
        {
            try
            {
                return Convert.ToDouble(Readvalue(Section, Key));
            }
            catch (FormatException) { return -1; }
        }
        public static string Ostring(string Section, string Key)
        {
            try { 
            return Readvalue(Section, Key);
            }
            catch (FormatException) { return ""; }
        }
        #endregion

    }
    public class Ra2md
    {
        public class Video //视频设置
        {
            public static bool VideoBackBuffer {
                set { IniIO.I("Video", "VideoBackBuffer", value); }
                get { return IniIO.Obool("Video", "VideoBackBuffer"); }
            }
            public static bool AllowHiResModes
            {
                set { IniIO.I("Video", "AllowHiResModes", value); }
                get { return IniIO.Obool("Video", "AllowHiResModes"); }
            }
            public static bool AllowVRAMSidebar
            {
                set { IniIO.I("Video", "AllowVRAMSidebar", value); }
                get { return IniIO.Obool("Video", "AllowVRAMSidebar"); }
            }
            public static bool StretchMovies
            {
                set { IniIO.I("Video", "StretchMovies", value); }
                get { return IniIO.Obool("Video", "StretchMovies"); }
            }
            public static bool Windowed
            {
                set
                {
                    IniIO.I("Video", "Video.Windowed", value);
                }
                get
                {
                    return IniIO.Obool("Video", "Video.Windowed");
                }
            }// 窗口化
            public static bool ForceLowestDetailLevel
            {
                set
                {
                    IniIO.I("Video", "ForceLowestDetailLevel", value);
                }
                get
                {
                    return IniIO.Obool("Video", "ForceLowestDetailLevel");
                }
            }
            public static bool NoWindowFrame
            {
                set
                {
                    IniIO.I("Video", "NoWindowFrame", value);
                }
                get
                {
                    return IniIO.Obool("Video", "NoWindowFrame");
                }
            }// 无边框
            public static int ScreenWidth
            {
                set
                {
                    IniIO.I("Video", "ScreenWidth", value);
                }
                get
                {
                    return IniIO.Oint("Video", "ScreenWidth");
                }
            }// 分辨率X长
            public static int ScreenHeight
            {
                set
                {
                    IniIO.I("Video", "ScreenHeight", value);
                }
                get
                {
                    return IniIO.Oint("Video", "ScreenHeight");
                }
            }// 分辨率Y宽
            public static string Renderer
            {
                set
                {
                    IniIO.I("Video", "Renderer", value);
                }
                get
                {
                    return IniIO.Ostring("Video", "Renderer");
                }
            }// 渲染器
        }
        public class MultiPlayer // 多人游戏设置
        {
            public static string Handle
            {
                set
                {
                    IniIO.I("MultiPlayer", "Handle", value);
                }
                get
                {
                    return IniIO.Ostring("MultiPlayer", "Handle");
                }
            }
        }
        public class Skirmish // 遭遇战 
        {
            public static void ShortGame(bool value)
            {
                IniIO.I("Skirmish", "ShortGame", value);
            }
            public static void SuperWeaponsAllowed(bool value)
            {
                IniIO.I("Skirmish", "SuperWeaponsAllowed", value);
            }
            public static void BuildOffAlly(bool value)
            {
                IniIO.I("Skirmish", "BuildOffAlly", value);
            }
            public static void MCVRepacks(bool value)
            {
                IniIO.I("Skirmish", "MCVRepacks", value);
            }
            public static void CratesAppear(bool value)
            {
                IniIO.I("Skirmish", "CratesAppear", value);
            }
            public static void GameMode(int value)
            {
                IniIO.I("Skirmish", "GameMode", value);
            }
            public static void ScenIndex(int value)
            {
                IniIO.I("Skirmish", "ScenIndex", value);
            }
            public static void GameSpeed(int value)
            {
                IniIO.I("Skirmish", "GameSpeed", value);
            }
            public static void Credits(int value)
            {
                IniIO.I("Skirmish", "Credits", value);
            }
            public static void UnitCount(int value)
            {
                IniIO.I("Skirmish", "UnitCount", value);
            }

        }
        public class Audio {
            public static bool PlayMenuMusic
            {
                get { return IniIO.Obool("Audio", "PlayMenuMusic"); }
                set { IniIO.I("Audio", "PlayMenuMusic", value); }
            }
            public static bool EnableButtonHoverSound
            {
                get { return IniIO.Obool("Audio", "EnableButtonHoverSound"); }
                set { IniIO.I("Audio", "EnableButtonHoverSound", value); }
            }
            public static bool PlayMainMenuMusic
            {
                get { return IniIO.Obool("Audio", "PlayMainMenuMusic"); }
                set { IniIO.I("Audio", "PlayMainMenuMusic", value); }
            }
            public static bool StopMusicOnMenu
            {
                get { return IniIO.Obool("Audio", "StopMusicOnMenu"); }
                set { IniIO.I("Audio", "StopMusicOnMenu", value); }
            }
            public static bool IsScoreShuffle
            {
                get { return IniIO.Obool("Audio", "IsScoreShuffle"); }
                set { IniIO.I("Audio", "IsScoreShuffle", value); }
            }
            public static bool InGameMusic
            {
                get { return IniIO.Obool("Audio", "InGameMusic"); }
                set { IniIO.I("Audio", "InGameMusic", value); }
            }
            public static bool IsScoreRepeat
            {
                get { return IniIO.Obool("Audio", "IsScoreRepeat"); }
                set { IniIO.I("Audio", "IsScoreRepeat", value); }
            }
            public static double ClientVolume
            {
                get { return IniIO.Odouble("Audio", "ClientVolume"); }
                set { IniIO.I("Audio", "ClientVolume", value); }
            }
            public static double SoundVolume
            {
                get
                {
                    return IniIO.Odouble("Audio", "SoundVolume");
                }
                set
                {
                    IniIO.I("Audio", "SoundVolume", value);
                }
            }// 音乐音量           
            public static double VoiceVolume
            {
                get { return IniIO.Odouble("Audio", "VoiceVolume"); }
                set { IniIO.I("Audio", "VoiceVolume", value); }
            }// 语音音量
            public static double ScoreVolume
            {
                set { IniIO.I("Audio", "ScoreVolume", value); }
                get { return IniIO.Odouble("Audio", "ScoreVolume"); }
            }// 音效音量
            public static int SoundLatency
            {
                set { IniIO.I("Audio", "SoundLatency", value); }
                get { return IniIO.Oint("Audio", "SoundLatency"); }
            }
        }
        public class Options {
            public static int DetailLevel
            {
                get { return IniIO.Oint("Options", "DetailLevel"); }
                set { IniIO.I("Options", "DetailLevel", value); }
            }
            public static bool UnitActionLines
            {
                get { return IniIO.Obool("Options", "UnitActionLines"); }
                set { IniIO.I("Options", "UnitActionLines", value); }
            }
            public static bool ScrollMethod
            {
                get { return IniIO.Obool("Options", "ScrollMethod"); }
                set { IniIO.I("Options", "ScrollMethod", value); }
            }
            public static bool ShowHidden
            {
                get { return IniIO.Obool("Options", "ShowHidden"); }
                set { IniIO.I("Options", "ShowHidden", value); }
            }
            public static bool ToolTips
            {
                get { return IniIO.Obool("Options", "ToolTips"); }
                set { IniIO.I("Options", "ToolTips", value); }
            }
            public static int ScrollRate
            {
                get { return IniIO.Oint("Options", "ScrollRate"); }
                set { IniIO.I("Options", "ScrollRate", value); }
            }
            public static int Difficulty
            {
                get { return IniIO.Oint("Options", "Difficulty"); }
                set { IniIO.I("Options", "Difficulty", value); }
            }// 难度
        }
    }
}
