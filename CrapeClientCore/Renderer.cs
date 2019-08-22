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
            File.Delete(Global.Globals.LocalPath + "ddraw.dll");
            File.Delete(Global.Globals.LocalPath + "dxwnd.dll");
            File.Delete(Global.Globals.LocalPath + "ddraw2.ini");
            File.Delete(Global.Globals.LocalPath + "ddraw.ini");
            File.Delete(Global.Globals.LocalPath + "dxwnd.ini");
            File.Delete(Global.Globals.LocalPath + "wined3d.dll");
            File.Delete(Global.Globals.LocalPath + "libwine.dll");
            }
            catch (Exception e) {
                Global.Globals.LogMGR.Error(e);
                return; }
        }
        static void Copy(string a, string b)// 封装函数
        {
            try
            {
                File.Copy(Global.Globals.DdrawDir + a, Global.Globals.LocalPath + b, true);
            }
            catch (FileNotFoundException e)
            {
                Global.Globals.LogMGR.Fatal(e);


            }
            catch (Exception e)
            {
                Global.Globals.LogMGR.Fatal(e);
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