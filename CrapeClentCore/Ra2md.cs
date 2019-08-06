using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program;

namespace RA2.Ini
{
    class IniIO
    {
        static IniEdit ra2md = new IniEdit(AppDomain.CurrentDomain.BaseDirectory + "ra2md.ini");
        public static void I(string Section, string Key, bool Value)
        {
            if (Value)
                ra2md.IniWriteValue(Section, Key, "1");
            else ra2md.IniWriteValue(Section, Key, "0");
        }
        public static void I(string Section, string Key, Int64 Value)
        {
            ra2md.IniWriteValue(Section, Key, Value.ToString());
        }
        public static void I(string Section, string Key, double Value)
        {
            ra2md.IniWriteValue(Section, Key, Value.ToString());
        }
        public static void I(string Section, string Key, string Value)
        {
            ra2md.IniWriteValue(Section, Key, Value);
        }
        public static bool Obool(string Section, string Key)
        {
            string Value = ra2md.IniReadValue(Section, Key);
            return IniTools.BoolCheck(Value);
        }
        public static int Oint(string Section, string Key)
        {
            return Convert.ToInt32(ra2md.IniReadValue(Section, Key));
        }
        public static double Odouble(string Section, string Key)
        {
            return Convert.ToDouble(ra2md.IniReadValue(Section, Key));
        }
        public static string Ostring(string Section, string Key)
        {
            return ra2md.IniReadValue(Section, Key);
        }


    }
    public class Ra2md
    {
        public class Video //视频设置
        {
            public static void VideoBackBuffer(bool Value){
                IniIO.I("Video", "VideoBackBuffer", Value);
            }
            public static bool VideoBackBuffer(){
                return IniIO.Obool("Video", "VideoBackBuffer");
            }
            public static void AllowHiResModes(bool Value){
                IniIO.I("Video", "AllowHiResModes", Value);
            }
            public static bool AllowHiResModes(){
                return IniIO.Obool("Video", "AllowHiResModes");
            }
            public static void AllowVRAMSidebar(bool Value){
                IniIO.I("Video", "AllowVRAMSidebar", Value);
            }
            public static bool AllowVRAMSidebar(){
                return IniIO.Obool("Video", "AllowVRAMSidebar");
            }
            public static void StretchMovies(bool Value){
                IniIO.I("Video", "StretchMovies", Value);
            }
            public static bool StretchMovies(){
                return IniIO.Obool("Video", "StretchMovies");
            }
            public static void Windowed(bool Value){
                IniIO.I("Video", "Video.Windowed", Value);
            }
            public static bool Windowed(){
                return IniIO.Obool("Video", "Video.Windowed");
            }
            public static void ForceLowestDetailLevel(bool Value){
                IniIO.I("Video", "ForceLowestDetailLevel", Value);
            }
            public static bool ForceLowestDetailLevel(){
                return IniIO.Obool("Video", "ForceLowestDetailLevel");
            }
            public static void NoWindowFrame(bool Value){
                IniIO.I("Video", "NoWindowFrame", Value);
            }
            public static bool NoWindowFrame(){
                return IniIO.Obool("Video", "NoWindowFrame");
            }
            public static void ScreenWidth(int Value){
                IniIO.I("Video", "ScreenWidth", Value);
            }
            public static int ScreenWidth(){
                return IniIO.Oint("Video", "ScreenWidth");
            }
            public static void ScreenHeight(int Value){
                IniIO.I("Video", "ScreenHeight", Value);
            }
            public static int ScreenHeight(){
                return IniIO.Oint("Video", "ScreenHeight");
            }
        }
        public class MultiPlayer // 多人游戏设置
        {

            public static void Handle(string Value)
            {
                IniIO.I("MultiPlayer", "Handle", Value);
            }
            public static string Handle()
            {
                return IniIO.Ostring("MultiPlayer", "Handle");
            }
        }
        public class Skirmish
        {
            public static void ShortGame(bool Value)
            {
                IniIO.I("Skirmish", "ShortGame", Value);
            }
            public static void SuperWeaponsAllowed(bool Value)
            {
                IniIO.I("Skirmish", "SuperWeaponsAllowed", Value);
            }
            public static void BuildOffAlly(bool Value)
            {
                IniIO.I("Skirmish", "BuildOffAlly", Value);
            }
            public static void MCVRepacks(bool Value)
            {
                IniIO.I("Skirmish", "MCVRepacks", Value);
            }
            public static void CratesAppear(bool Value)
            {
                IniIO.I("Skirmish", "CratesAppear", Value);
            }
            public static void GameMode(int Value)
            {
                IniIO.I("Skirmish", "GameMode", Value);
            }
            public static void ScenIndex(int Value)
            {
                IniIO.I("Skirmish", "ScenIndex", Value);
            }
            public static void GameSpeed(int Value)
            {
                IniIO.I("Skirmish", "GameSpeed", Value);
            }
            public static void Credits(int Value)
            {
                IniIO.I("Skirmish", "Credits", Value);
            }
            public static void UnitCount(int Value)
            {
                IniIO.I("Skirmish", "UnitCount", Value);
            }

        }
        public class Audio
        {
            public static void PlayMenuMusic(bool Value)
            {
                IniIO.I("Audio", "PlayMenuMusic", Value);
            }
            public static void EnableButtonHoverSound(bool Value)
            {
                IniIO.I("Audio", "EnableButtonHoverSound", Value);
            }
            public static void PlayMainMenuMusic(bool Value)
            {
                IniIO.I("Audio", "PlayMainMenuMusic", Value);
            }
            public static void StopMusicOnMenu(bool Value)
            {
                IniIO.I("Audio", "StopMusicOnMenu", Value);
            }
            public static void IsScoreRepeat(bool Value)
            {
                IniIO.I("Audio", "IsScoreRepeat", Value);
            }
            public static void IsScoreShuffle(bool Value)
            {
                IniIO.I("Audio", "IsScoreShuffle", Value);
            }
            public static void InGameMusic(bool Value)
            {
                IniIO.I("Audio", "InGameMusic", Value);
            }
            public static bool PlayMenuMusic()
            {
                return IniIO.Obool("Audio", "PlayMenuMusic");
            }
            public static bool EnableButtonHoverSound()
            {
                return IniIO.Obool("Audio", "EnableButtonHoverSound");
            }
            public static bool PlayMainMenuMusic()
            {
                return IniIO.Obool("Audio", "PlayMainMenuMusic");
            }
            public static bool StopMusicOnMenu()
            {
                return IniIO.Obool("Audio", "StopMusicOnMenu");
            }
            public static bool IsScoreRepeat()
            {
                return IniIO.Obool("Audio", "IsScoreRepeat");
            }
            public static bool IsScoreShuffle()
            {
                return IniIO.Obool("Audio", "IsScoreShuffle");
            }
            public static bool InGameMusic()
            {
                return IniIO.Obool("Audio", "InGameMusic");
            }
            public static void ClientVolume(double Value)
            {
                IniIO.I("Audio", "ClientVolume", Value);
            }
            public static void SoundVolume(double Value)
            {
                IniIO.I("Audio", "SoundVolume", Value);
            }
            public static void VoiceVolume(double Value)
            {
                IniIO.I("Audio", "VoiceVolume", Value);
            }
            public static void ScoreVolume(double Value)
            {
                IniIO.I("Audio", "ScoreVolume", Value);
            }
            public static double ClientVolume()
            {
                return IniIO.Odouble("Audio", "ClientVolume");
            }
            public static double SoundVolume()
            {
                return IniIO.Odouble("Audio", "SoundVolume");
            }
            public static double VoiceVolume()
            {
                return IniIO.Odouble("Audio", "VoiceVolume");
            }
            public static double ScoreVolume()
            {
                return IniIO.Odouble("Audio", "ScoreVolume");
            }
            public static void SoundLatency(int Value)
            {
                IniIO.I("Audio", "SoundLatency", Value);
            }
            public static int SoundLatency()
            {
                return IniIO.Oint("Audio", "SoundLatency");
            }

        }

        public class Options
        {
            public static void DetailLevel(int Value) { IniIO.I("Options", "DetailLevel", Value); }
            public static void UnitActionLines(bool Value) { IniIO.I("Options", "UnitActionLines", Value); }
            public static void ScrollMethod(bool Value) { IniIO.I("Options", "ScrollMethod", Value); }
            public static void ShowHidden(bool Value) { IniIO.I("Options", "ShowHidden", Value); }
            public static void ToolTips(bool Value) { IniIO.I("Options", "ToolTips", Value); }
            public static void ScrollRate(int Value) { IniIO.I("Options", "ScrollRate", Value); }

            public static int DetailLevel() { return IniIO.Oint("Options", "DetailLevel"); }
            public static bool UnitActionLines() { return IniIO.Obool("Options", "UnitActionLines"); }
            public static bool ScrollMethod() { return IniIO.Obool("Options", "ScrollMethod"); }
            public static bool ShowHidden() { return IniIO.Obool("Options", "ShowHidden"); }
            public static bool ToolTips() { return IniIO.Obool("Options", "ToolTips"); }
            public static int ScrollRate() { return IniIO.Oint("Options", "ScrollRate"); }
        }
    }
}
