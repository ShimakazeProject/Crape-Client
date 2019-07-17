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
        public static bool oBool(string Section, string Key)
        {
            string Value = ra2md.IniReadValue(Section, Key);
            return IniTools.BoolCheck(Value);
        }
        public static int oInt(string Section, string Key)
        {
            return Convert.ToInt32(ra2md.IniReadValue(Section, Key));
        }
        public static string oString(string Section, string Key)
        {
            return ra2md.IniReadValue(Section, Key);
        }


    }
    public class Ra2md
    {
        public class Video
        {
            public static void VideoBackBuffer(bool Value){
                IniIO.I("Video", "VideoBackBuffer", Value);
            }
            public static void AllowHiResModes(bool Value){
                IniIO.I("Video", "AllowHiResModes", Value);
            }
            public static void AllowVRAMSidebar(bool Value){
                IniIO.I("Video", "AllowVRAMSidebar", Value);
            }
            public static void StretchMovies(bool Value){
                IniIO.I("Video", "StretchMovies", Value);
            }
            public static void Windowed(bool Value){
                IniIO.I("Video", "Video.Windowed", Value);
            }
            public static void ForceLowestDetailLevel(bool Value)
            {
                IniIO.I("Video", "ForceLowestDetailLevel", Value);
            }
            public static void NoWindowFrame(bool Value){
                IniIO.I("Video", "NoWindowFrame", Value);
            }
            public static void ScreenWidth(int Value){
                IniIO.I("Video", "ScreenWidth", Value);
            }
            public static void ScreenHeight(int Value){
                IniIO.I("Video", "ScreenHeight", Value);
            }
        }
        public class MultiPlayer
        {

            public static void Handle(string Value)
            {
                IniIO.I("MultiPlayer", "Handle", Value);
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
            public static void SoundLatency(int Value)
            {
                IniIO.I("Audio", "SoundLatency", Value);
            }

        }

    }
}
