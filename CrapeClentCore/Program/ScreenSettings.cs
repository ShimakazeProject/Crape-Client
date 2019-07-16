using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Crape_Client;

namespace Program
{
    public partial class Screen
    {
        #region screenInfo
        static Rectangle rect = System.Windows.Forms.Screen.PrimaryScreen.Bounds;//保存当前屏幕分辨率
        static int j = rect.Width; //宽（像素）
        static int i = rect.Height; //高（像素）
        static int b = System.Windows.Forms.Screen.PrimaryScreen.BitsPerPixel;//BitsPerPixel
        #endregion
        #region dll
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]public struct DEVMODE
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public short dmOrientation;
            public short dmPaperSize;
            public short dmPaperLength;
            public short dmPaperWidth;
            public short dmScale;
            public short dmCopies;
            public short dmDefaultSource;
            public short dmPrintQuality;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]static extern int ChangeDisplaySettings([In] ref DEVMODE lpDevMode, int dwFlags);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]static extern bool EnumDisplaySettings(string lpszDeviceName, Int32 iModeNum, ref DEVMODE lpDevMode);
        #endregion
        public static void ChangeRes()
        {
            DEVMODE DevM = new DEVMODE();
            DevM.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));
            EnumDisplaySettings(null, 0, ref DevM);
            DevM.dmPelsWidth = j;
            DevM.dmPelsHeight = i;
            DevM.dmDisplayFrequency = 0;//刷新频率
            DevM.dmBitsPerPel = 16;//颜色象素
            int result = ChangeDisplaySettings(ref DevM, 0);
            if (result != 0)
            {
                Nlog.logger.Error("SetBitsPerPixel     ChangeDisplaySettings Returned:" + result.ToString() 
                    + "\r\n\t Width:" + j.ToString() 
                    + "\r\n\tHeight:" + i.ToString() 
                    + "\r\n\t  Bits:" + b.ToString());
            }
            //long result = ChangeDisplaySettings(ref DevM, 0);
        }
        public static void DisChangeRes()
        {
            DEVMODE DevM = new DEVMODE();
            DevM.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));
            EnumDisplaySettings(null, 0, ref DevM);
            DevM.dmPelsWidth = j;
            DevM.dmPelsHeight = i;
            DevM.dmDisplayFrequency = 0;//刷新频率
            DevM.dmBitsPerPel = b;//颜色象素
            long result = ChangeDisplaySettings(ref DevM, 0);
            if (result != 0)
            {
                Nlog.logger.Error("RestoreBitsPerPixel ChangeDisplaySettings Returned:" + result.ToString()
                    + "\r\n\t Width:" + j.ToString()
                    + "\r\n\tHeight:" + i.ToString()
                    + "\r\n\t  Bits:" + b.ToString());
            }
        }
    }
}