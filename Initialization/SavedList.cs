using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows;
using System.Drawing;
using Crape_Client.CrapeClientCore;
using Crape_Client.CrapeClientCore.Config;

namespace Crape_Client.Initialization
{
    class SavedList
    {
        #region 存档
        public static void SavesListInit()
        {
            DirectoryInfo folder = new DirectoryInfo(Global.SavesDir);
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
            catch (DirectoryNotFoundException e)
            {
                Nlog.logger.Info(e.Message);
                Global.SaveFilesList.Add(new Cls_SaveFiles
                {
                    Name = "没有发现可用存档",
                    Date = "",
                    FileN = ""
                });
            }
        }
        #endregion

    }
}
