using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Laba
{
    internal class Admin : ICrud
    {
        private List<AdminFunction> Sotrudmiki = Serializator.myDeser<List<AdminFunction>>(Inizialisation.file);
        private int ClearParam = 0;
        private int ScetPos = 0;
        public Admin()
        {
            AdminPusk();
        }
        public void AdminPusk(bool gang = true)
        {
            Menu.MainMenu();
            if (gang)
            {
                Read();
            }
            else
            {
                Read(gang);
            }
            Menu.DopMenuAdminMain();
            Arrows.max = ScetPos + 3;
            Arrows.min = 4;
            Arrows.Arrow();
            if (Arrows.pozition == -3)
            {
                Menu.clear(ClearParam);
                Create();

            }
            else if (Arrows.pozition == -4)
            {
                Menu.clear(ClearParam);
                search();
            }
            else if (Arrows.pozition == -2)
            {
                Arrows.min = 2;
                Arrows.max = 4;
                Console.Clear();
                Program.pusk();
            }
            else
            {
                if (gang)
                {
                    Update(Arrows.pozition - 4);
                }
                else
                {
                    Update(Arrows.pozition - 4, gang);
                }
            }
        }

        AdminFunction Sotrud = new AdminFunction();
        public void Create()
        {
            while (true)
            {
                Arrows.min = 2;
                Arrows.max = 5;
                Menu.DopMenuAdminCreate();
                Console.SetCursorPosition(3, 2);
                Console.Write("ID:");
                Console.SetCursorPosition(3, 3);
                Console.Write("Логин:");
                Console.SetCursorPosition(3, 4);
                Console.Write("Пароль:");
                Console.SetCursorPosition(3, 5);
                Console.Write("Роль:");
                Arrows.Arrow();

                if (Arrows.pozition == 2)
                {
                    Console.SetCursorPosition(11, 2);
                    Console.Write("                     ");
                    Console.SetCursorPosition(10, 2);
                    Sotrud.id = Convert.ToInt32(Console.ReadLine());
                }
                if (Arrows.pozition == 3)
                {
                    Console.SetCursorPosition(11, 3);
                    Console.Write("                     ");
                    Console.SetCursorPosition(10, 3);
                    Sotrud.logg = Console.ReadLine().ToString();
                }
                if (Arrows.pozition == 4)
                {
                    Console.SetCursorPosition(11, 4);
                    Console.Write("                     ");
                    Console.SetCursorPosition(10, 4);
                    Sotrud.pass = Console.ReadLine().ToString();
                }
                if (Arrows.pozition == 5)
                {
                    Console.SetCursorPosition(11, 5);
                    Console.Write("                     ");
                    Console.SetCursorPosition(10, 5);
                    Sotrud.role = Console.ReadLine().ToString();
                }
                if (Arrows.pozition == -1)
                {
                    Inizialisation.newPersonalList.Add(new Data(Sotrud.role, Sotrud.logg, Sotrud.pass, Sotrud.id));
                    Serializator.mySer(Inizialisation.newPersonalList, "10LABA.json");
                    Sotrudmiki.Add(Sotrud);
                    Menu.clear(ClearParam);
                    AdminPusk();
                    break;
                }
                if (Arrows.pozition == -2)
                {
                    Menu.clear(ClearParam);
                    AdminPusk();
                    break;
                }
            }
        }

        public void Delete(int deleteIndex)
        {
            Inizialisation.newPersonalList.RemoveAt(deleteIndex);
            Serializator.mySer(Inizialisation.newPersonalList, "10LABA.json");
        }

        public void Read(bool read = true)
        {
            Console.SetCursorPosition(10, 3);
            Console.WriteLine("ID:");
            Console.SetCursorPosition(20, 3);
            Console.WriteLine("Логин");
            Console.SetCursorPosition(45, 3);
            Console.WriteLine("Пароль:");
            Console.SetCursorPosition(70, 3);
            Console.WriteLine("Роль");

            int i = 0;
            if (read == true)
            {
                foreach (var item in Inizialisation.newPersonalList)
                {
                    Console.SetCursorPosition(10, 4 + i);
                    Console.WriteLine(item.ID);
                    Console.SetCursorPosition(20, 4 + i);
                    Console.WriteLine(item.Login);
                    Console.SetCursorPosition(45, 4 + i);
                    Console.WriteLine(item.Password);
                    Console.SetCursorPosition(70, 4 + i);
                    Console.WriteLine(item.Role);
                    i += 1;
                    ScetPos = i;
                    ClearParam += i;
                }
            }
            else
            {
                foreach (var item in Search)
                {
                    Console.SetCursorPosition(10, 4 + i);
                    Console.WriteLine(item.ID);
                    Console.SetCursorPosition(20, 4 + i);
                    Console.WriteLine(item.Login);
                    Console.SetCursorPosition(45, 4 + i);
                    Console.WriteLine(item.Password);
                    Console.SetCursorPosition(70, 4 + i);
                    Console.WriteLine(item.Role);
                    i += 1;
                    ScetPos = i;
                }
            }
        }

        public void Update(int changeIndex, bool gang = true)
        {

            Menu.clear(ClearParam);
            Arrows.max = 5;
            Arrows.min = 2;
            Arrows.pozition = 2;
            Console.SetCursorPosition(3, 2);
            Console.Write("ID:");
            Console.SetCursorPosition(3, 3);
            Console.Write("Логин:");
            Console.SetCursorPosition(3, 4);
            Console.Write("Пароль:");
            Console.SetCursorPosition(3, 5);
            Console.Write("Роль:");
            Menu.DopMenuAdminRedact();
            if (gang)
            {
                Console.SetCursorPosition(11, 2);
                Console.Write(Inizialisation.newPersonalList[changeIndex].ID);
                Console.SetCursorPosition(11, 3);
                Console.Write(Inizialisation.newPersonalList[changeIndex].Login);
                Console.SetCursorPosition(11, 4);
                Console.Write(Inizialisation.newPersonalList[changeIndex].Password);
                Console.SetCursorPosition(11, 5);
                Console.Write(Inizialisation.newPersonalList[changeIndex].Role);
            }
            else
            {
                Console.SetCursorPosition(11, 2);
                Console.Write(Search[changeIndex].ID);
                Console.SetCursorPosition(11, 3);
                Console.Write(Search[changeIndex].Login);
                Console.SetCursorPosition(11, 4);
                Console.Write(Search[changeIndex].Password);
                Console.SetCursorPosition(11, 5);
                Console.Write(Search[changeIndex].Role);
            }
            while (true)
            {
                Arrows.Arrow();
                Data Change = Inizialisation.newPersonalList[changeIndex];
                if (Change != null)
                {
                    if (Arrows.pozition == 2)
                    {
                        Console.SetCursorPosition(11, 2);
                        Console.Write("                     ");
                        Console.SetCursorPosition(11, 2);
                        Change.ID = Convert.ToInt32(Console.ReadLine());
                    }
                    else if (Arrows.pozition == 3)
                    {
                        Console.SetCursorPosition(11, 3);
                        Console.Write("                     ");
                        Console.SetCursorPosition(11, 3);
                        Change.Login = Console.ReadLine();
                    }
                    else if (Arrows.pozition == 4)
                    {
                        Console.SetCursorPosition(11, 4);
                        Console.Write("                     ");
                        Console.SetCursorPosition(11, 4);
                        Change.Password = Console.ReadLine();
                    }
                    else if (Arrows.pozition == 5)
                    {
                        Console.SetCursorPosition(11, 5);
                        Console.Write("                     ");
                        Console.SetCursorPosition(11, 5);
                        Change.Role = Console.ReadLine();
                    }
                    else if (Arrows.pozition == -1)
                    {
                        Inizialisation.newPersonalList[changeIndex] = Change;
                        Serializator.mySer(Inizialisation.newPersonalList, "10LABA.json");
                        Menu.clear(ClearParam);
                        AdminPusk();
                        break;
                    }
                    else if (Arrows.pozition == -2)
                    {
                        Menu.clear(ClearParam);
                        AdminPusk();
                        break;
                    }
                    else if (Arrows.pozition == -5)
                    {
                        Menu.clear(ClearParam);
                        Delete(changeIndex);
                        AdminPusk();
                        break;
                    }
                }
            }
        }

        public void search()
        {
            while (true)
            {
                Arrows.max = 6;
                Arrows.min = 3;
                Console.SetCursorPosition(3, 2);
                Console.Write("Выбирете праметр, по которму хотите произвести поиск:");
                Console.SetCursorPosition(3, 3);
                Console.Write("ID:");
                Console.SetCursorPosition(3, 4);
                Console.Write("Логин:");
                Console.SetCursorPosition(3, 5);
                Console.Write("Пароль:");
                Console.SetCursorPosition(3, 6);
                Console.Write("Роль:");
                Arrows.Arrow();

                if (Arrows.pozition == 3)
                {
                    Console.SetCursorPosition(11, 3);
                    Console.Write("                     ");
                    int SearchID = Convert.ToInt32(Console.ReadLine());
                    Data ID = new Data("", "", "", SearchID);
                    Sorted(ID.ID);
                    break;
                }
                else if (Arrows.pozition == 4)
                {
                    Console.SetCursorPosition(11, 4);
                    Console.Write("                     ");
                    Console.SetCursorPosition(11, 4);
                    string SearchLogin = Console.ReadLine();
                    Data Log = new Data("", SearchLogin, "", 0);
                    Sorted(Log.Login);
                    break;
                }
                else if (Arrows.pozition == 5)
                {
                    Console.SetCursorPosition(11, 5);
                    Console.Write("                     ");
                    Console.SetCursorPosition(11, 5);
                    string SearchPassword = Console.ReadLine();
                    Data Pas = new Data("", "", SearchPassword, 0);
                    Sorted(Pas.Password);
                    break;
                }
                else if (Arrows.pozition == 6)
                {
                    Console.SetCursorPosition(11, 6);
                    Console.Write("                     ");
                    Console.SetCursorPosition(11, 6);
                    string SearchRole = Console.ReadLine();
                    Data rol = new Data(SearchRole, "", "", 0);
                    Sorted(rol.Role);
                    break;
                }
                else if(Arrows.pozition == -2)
                {
                    Menu.clear(ClearParam);
                    AdminPusk();
                    break;
                }
            }

        }

        public Data[] Search = new Data[] { };

        private void Sorted(string item)
        {
            Search = Inizialisation.newPersonalList.Where(x => x.Role == item || x.Login == item || x.Password == item).ToArray();
            Menu.clear(ClearParam);
            AdminPusk(false);
        }
        private void Sorted(int item)
        {
            Search = Inizialisation.newPersonalList.Where(x => x.ID == item).ToArray();
            Menu.clear(ClearParam);
            AdminPusk(false);
        }
    }

    internal class AdminFunction
    {
        public string logg;
        public string pass;
        public int id;
        public string role;
    }
}
