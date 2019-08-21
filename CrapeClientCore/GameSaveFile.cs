using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Crape_Client
{
    class GameSaveFile
    {
        public static string LoadSaveName(byte[] File)
        {
            try
            {
                byte[] NameBytes = File.Skip(0x9c0).Take(0x40).ToArray();
                string NameString = Encoding.Unicode.GetString(NameBytes);
                string ZeroString = Encoding.Unicode.GetString(new byte[] { 0x00, 0x00 });
                NameString = NameString.Replace(ZeroString, null);
                return NameString;
            }catch(Exception e)
            {
                Global.LogMGR.Error(e);
                return null;
            }
        }

    }
}
