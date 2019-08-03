using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Program
{
    class Init
    {

        public static void Initialize()
        {

        }
        static void Skirmish()
        {
            MemIniFile skir = new MemIniFile();
            skir.LoadFromFile(@"Resource\Configs\Skirmish.ini");
            InitConf.TeamNum = skir.ReadValue("SKIRMISH", "TeamNum", 4);
            InitConf.ColorNum = skir.ReadValue("SKIRMISH", "Side", 8);
            InitConf.SideNum = skir.ReadValue("SKIRMISH", "Color", 12);
            SkirmishSide(skir);
            SkirmishColor(skir);


            





        }
        static void SkirmishSide(MemIniFile skir)
        {
            for (int i = 0; i <= InitConf.SideNum; i++) 
            {
                string Value = skir.ReadValue("SIDE", i.ToString(), "");
                if (RandomCheck(Value))
                {
                    string[] maxMin;
                    maxMin = Value.Split('-');
                    Format1 format = new Format1();
                    format.Num = Convert.ToInt16(maxMin[0]);
                    format.Max = Convert.ToInt16(maxMin[1]);
                    format.Readom = true;
                    
                    SkirConf.Side.Add(format);
                }
                else
                {
                    Format1 format = new Format1();
                    format.Num = Convert.ToInt16(Value);
                    format.Max = null;
                    format.Readom = false;
                    SkirConf.Side.Add(format);
                }
            }
        }
        static void SkirmishColor(MemIniFile skir)
        {
            for (int i = 0; i <= InitConf.ColorNum; i++)
            {
                string Value = skir.ReadValue("COLOR", i.ToString(), "");
                if (RandomCheck(Value))
                {
                    string[] maxMin;
                    maxMin = Value.Split('-');
                    Format1 format = new Format1();
                    format.Num = Convert.ToInt16(maxMin[0]);
                    format.Max = Convert.ToInt16(maxMin[1]);
                    format.Readom = true;
                    SkirConf.Color.Add(format);
                }
                else
                {
                    Format1 format = new Format1();
                    format.Num = Convert.ToInt16(Value);
                    format.Max = null;
                    format.Readom = false;
                    SkirConf.Color.Add(format);
                }
            }
        }
        static bool RandomCheck(string Value)
        {
            if (Value.IndexOf("-") < 0)
                return false;
            else return true;
        }
    }
}
