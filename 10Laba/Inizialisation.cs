using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Laba
{
    internal class Inizialisation
    {
        public static List<Data> PersonalList = new List<Data>() { new Data("Administrator", "111", "111", 0) };
        public static string ChoiseRole;
        public static bool log;
        public static string file = "10LABA.json";
        public static List<Data> newPersonalList = Serializator.myDeser<List<Data>>(file);
        public static bool init()
        {
            foreach (var item in newPersonalList)
            {

                if (Menu.pass == item.Password && item.Role == Personal.Administrator.ToString() && Menu.login == item.Login)
                {
                    ChoiseRole = Personal.Administrator.ToString();
                    log = true;
                }
                else if (Menu.pass == item.Password && item.Role == Personal.Kacier.ToString() && Menu.login == item.Login)
                {
                    ChoiseRole = Personal.Kacier.ToString();
                    log = true;
                }
                else if (Menu.pass == item.Password && item.Role == Personal.Kadrovik.ToString()  && Menu.login == item.Login)
                {
                    ChoiseRole = Personal.Kadrovik.ToString();
                    log = true;
                }
                else if (Menu.pass == item.Password && item.Role == Personal.SkladManager.ToString() && Menu.login == item.Login)
                {
                    ChoiseRole = Personal.SkladManager.ToString();
                    log =  true;
                }
                else if (Menu.pass == item.Password && item.Role == Personal.Buhalter.ToString() && Menu.login == item.Login)
                {
                    ChoiseRole = Personal.Buhalter.ToString();
                    log = true;
                }
            }
            if(log == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
