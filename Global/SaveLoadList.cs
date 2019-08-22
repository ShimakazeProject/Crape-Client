using System.IO;

namespace Crape_Client.Global
{
    class SaveLoadList
    {
        public SaveLoadList()
        {
            DirectoryInfo folder = new DirectoryInfo(Globals.SavesDir);
            try
            {
                foreach (FileInfo file in folder.GetFiles("*.sav"))
                {
                    Globals.SaveFilesList.Add(new Cls_SaveFiles
                    {
                        Name = GameSaveFile.LoadSaveName(File.ReadAllBytes(file.FullName)),
                        Date = file.LastWriteTime.ToString(),
                        File = file.Name
                    });
                }
            }
            catch (DirectoryNotFoundException e)
            {
                Globals.LogMGR.Info(e.Message);
                Globals.SaveFilesList.Add(new Cls_SaveFiles
                {
                    Name = "没有发现可用存档",
                    Date = "",
                    File = ""
                });
            }
        }
    }
    public struct Cls_SaveFiles// 存档列表用
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string File { get; set; }
    }
}
