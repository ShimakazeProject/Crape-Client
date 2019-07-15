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
            byte[] NameBytes = File.Skip(0x9c0).Take(0x40).ToArray();
            List<byte> Bytes = NameBytes.ToList();
            for (uint i = 0;i<0xFF;i++)
            {
                Bytes.Remove(0xFF);
            }

            string str = Encoding.Unicode.GetString(NameBytes);
            Debug.WriteLine(str);
            return str;
        }

    }
}
