using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Crape_Client.CrapeClientCore
{
    class Renderer
    {
        public static void Clear()
        {
            try { 
            File.Delete(Global.LocalPath + "ddraw.dll");
            File.Delete(Global.LocalPath + "dxwnd.dll");
            File.Delete(Global.LocalPath + "ddraw2.ini");
            File.Delete(Global.LocalPath + "ddraw.ini");
            File.Delete(Global.LocalPath + "dxwnd.ini");
            File.Delete(Global.LocalPath + "wined3d.dll");
            File.Delete(Global.LocalPath + "libwine.dll");
            }
            catch (Exception e) {
                Nlog.logger.Error(e.Message);
                Nlog.logger.Error(e.Source);
                Nlog.logger.Error(e.TargetSite);
                return; }
        }
        static void Copy(string a, string b)// 封装函数
        {
            try
            {
                File.Copy(Global.DdrawDir + a, Global.LocalPath + b, true);
            }
            catch (FileNotFoundException e)
            {
                Nlog.logger.Fatal(e.Message);
                Nlog.logger.Fatal(e.Source);
                Nlog.logger.Fatal(e.TargetSite);
                Nlog.logger.Fatal(e.FileName);
                Nlog.ErrorBoxShow(e);
            }
            catch (Exception e)
            {
                Nlog.logger.Fatal(e.Message);
                Nlog.logger.Fatal(e.Source);
                Nlog.logger.Fatal(e.TargetSite);
                Nlog.ErrorBoxShow(e);
            }

        }
        static void CopyDll(string DllFileName)
        {
            Copy(DllFileName, "ddraw.dll");
        }
        static void Copy(string FileName)
        {
            Copy(FileName, FileName);
        }

        public static void RendererSet(Initialization.Config.Renderer renderer)
        {
            Clear();
            CopyDll(renderer.Dll);
            string[] files = renderer.Files.ToArray();
            for(int i = 0; i < files.Length; i++)
            {
                Copy(files[i]);
            }
        }
    }
}
/*        #region

        public static void TS_DDRAW_2()
        {
            Clear();
            Copy("ddraw2.dll", "ddraw.dll");
            Copy("ddraw2.ini", "ddraw2.ini");
        }
        public static void DXWND()
        {
            Clear();
            Copy("dxwnd.dll", "dxwnd.dll");
            Copy("dxwnd.ini", "dxwnd.ini");
            Copy("ddraw_dxwnd.dll", "ddraw.dll");
        }
        public static void TS_DDRAW()
        {
            Clear();
            Copy("ts_ddraw.dll", "ddraw.dll");
        }
        public static void DdrawCompat()
        {
            Clear();
            Copy("ddrawcompat.dll", "ddraw.dll");
        }
        public static void DDWrapper()
        {
            Clear();
            Copy("ddwrapper.dll", "ddraw.dll");
        }
        public static void IE_DDRAW()
        {
            Clear();
            Copy("ie_ddraw.dll", "ddraw.dll");
            Copy("wined3d.dll", "wined3d.dll");
            Copy("libwine.dll", "libwine.dll");
        }
        #endregion
*/
