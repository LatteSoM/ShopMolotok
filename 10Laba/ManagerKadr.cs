using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Laba
{
    internal class ManagerKadr : ICrud
    {
        private static string file = "Sotrudniki.json";
        public List<KadrovikFunction> Sotrudniki = new List<KadrovikFunction>();
        private int ClearParam = 0;
        private int ScetPos = 0;

        public ManagerKadr()
        {
            KadroviKPusk();
        }

        void KadroviKPusk(bool gang = true)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "Sotrudniki.json";
            bool fileExist = File.Exists(path);
            if (fileExist)
            {
                Sotrudniki = Serializator.myDeser<List<KadrovikFunction>>("Sotrudniki.json");
                KadrovikFunction.Sotrudnuky = Sotrudniki;
            }
            else
            {
                Serializator.mySer(Sotrudniki, "Sotrudniki.json");
            }
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
        KadrovikFunction person = new KadrovikFunction();
        public void Create()
        {
            while (true)
            {
                Arrows.min = 2;
                Arrows.max = 10;
                Menu.DopMenuKAdrovikCreate();
                Menu.DopMenuKadrovik();
                Arrows.Arrow();

                if (Arrows.pozition == 2)
                {
                    Console.SetCursorPosition(30, 2);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 2);
                    person.id = Convert.ToInt32(Console.ReadLine());
                }
                if (Arrows.pozition == 3)
                {
                    Console.SetCursorPosition(30, 3);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 3);
                    person.Sename = Console.ReadLine().ToString();
                }
                if (Arrows.pozition == 4)
                {
                    Console.SetCursorPosition(30, 4);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 4);
                    person.Name = Console.ReadLine().ToString();
                }
                if (Arrows.pozition == 5)
                {
                    Console.SetCursorPosition(30, 5);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 5);
                    person.Patronymic = Console.ReadLine().ToString();
                }
                if (Arrows.pozition == 6)
                {
                    Console.SetCursorPosition(30, 6);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 6);
                    person.DataBorn = Console.ReadLine().ToString();
                }
                if (Arrows.pozition == 7)
                {
                    Console.SetCursorPosition(30, 7);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 7);
                    person.Pasport = Console.ReadLine().ToString();
                }
                if (Arrows.pozition == 8)
                {
                    Console.SetCursorPosition(30, 8);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 8);
                    person.JobTitle = Console.ReadLine().ToString();
                }
                if (Arrows.pozition == 9)
                {
                    Console.SetCursorPosition(30, 9);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 9);
                    person.Salary = Convert.ToInt32(Console.ReadLine());
                }
                if (Arrows.pozition == 10)
                {
                    Console.SetCursorPosition(30, 10);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 10);
                    person.AcountId = Convert.ToInt32(Console.ReadLine());
                    person.id = person.AcountId;
                }
                if (Arrows.pozition == -1)
                {
                    Sotrudniki.Add(person);
                    KadrovikFunction.Sotrudnuky = Sotrudniki;
                    changeId(person.id);
                    Serializator.mySer(Sotrudniki, "Sotrudniki.json");
                    Menu.clear(ClearParam);
                    KadroviKPusk();
                    break;
                }
                if (Arrows.pozition == -2)
                {
                    Menu.clear(ClearParam);
                    KadroviKPusk();
                    break;
                }
            }
        }
        void changeId(int idParam)
        {
            List<KadrovikFunction> fictList = KadrovikFunction.Sotrudnuky.Where(item => item.id == idParam).ToList();
            List<Data> chan = Inizialisation.newPersonalList.Where(item => item.Role == fictList[0].JobTitle).ToList();
            chan[0].ID = fictList[0].AcountId;
            int number = Inizialisation.newPersonalList.FindIndex(item => item.Role == fictList[0].JobTitle);
            Inizialisation.newPersonalList[number] = chan[0];
            Serializator.mySer(Inizialisation.newPersonalList, "10LABA.json");
        }

        public void Delete(int deleteIndex)
        {
            Sotrudniki.RemoveAt(deleteIndex);
            Serializator.mySer(Sotrudniki, "Sotrudniki.json");
            KadrovikFunction.Sotrudnuky = Sotrudniki;
        }

        public void Read(bool read = true)
        {
            Console.SetCursorPosition(5, 3);
            Console.WriteLine("ID:");
            Console.SetCursorPosition(10, 3);
            Console.WriteLine("Фамилия");
            Console.SetCursorPosition(30, 3);
            Console.WriteLine("Имя");
            Console.SetCursorPosition(50, 3);
            Console.WriteLine("Отчество");
            Console.SetCursorPosition(70, 3);
            Console.WriteLine("Должность");
            
            int i = 0;
            if (read == true)
            {
                if (Sotrudniki.Count != 0)
                {
                    foreach (var item in Sotrudniki)
                    {
                        Console.SetCursorPosition(5, 4 + i);
                        Console.WriteLine(item.id);
                        Console.SetCursorPosition(10, 4 + i);
                        Console.WriteLine(item.Sename);
                        Console.SetCursorPosition(30, 4 + i);
                        Console.WriteLine(item.Name);
                        Console.SetCursorPosition(50, 4 + i);
                        Console.WriteLine(item.Patronymic);
                        Console.SetCursorPosition(70, 4 + i);
                        Console.WriteLine(item.JobTitle);
                        i += 1;
                        ScetPos = i;
                        ClearParam += i;
                    }
                }
            }
            else
            {
                foreach (var item in Search)
                {
                    Console.SetCursorPosition(5, 4 + i);
                    Console.WriteLine(item.id);
                    Console.SetCursorPosition(10, 4 + i);
                    Console.WriteLine(item.Sename);
                    Console.SetCursorPosition(30, 4 + i);
                    Console.WriteLine(item.Name);
                    Console.SetCursorPosition(50, 4 + i);
                    Console.WriteLine(item.Patronymic);
                    Console.SetCursorPosition(70, 4 + i);
                    Console.WriteLine(item.JobTitle);
                    i += 1;
                    ScetPos = i;
                    ClearParam += i;
                }
            }
        }



        public void Update(int changeIndex, bool gang = true)
        {
            Menu.clear(ClearParam);
            Arrows.max = 10;
            Arrows.min = 2;
            Arrows.pozition = 2;
            Menu.KAdrovikRedact();
            Menu.DopMenuKadrovik();
            if (gang)
            {
                Console.SetCursorPosition(30, 2);
                Console.Write(Sotrudniki[changeIndex].id);
                Console.SetCursorPosition(30, 3);
                Console.Write(Sotrudniki[changeIndex].Sename);
                Console.SetCursorPosition(30, 4);
                Console.Write(Sotrudniki[changeIndex].Name);
                Console.SetCursorPosition(30, 5);
                Console.Write(Sotrudniki[changeIndex].Patronymic);
                Console.SetCursorPosition(30, 6);
                Console.Write(Sotrudniki[changeIndex].DataBorn);
                Console.SetCursorPosition(30, 7);
                Console.Write(Sotrudniki[changeIndex].Pasport);
                Console.SetCursorPosition(30, 8);
                Console.Write(Sotrudniki[changeIndex].JobTitle);
                Console.SetCursorPosition(30, 9);
                Console.Write(Sotrudniki[changeIndex].Salary);
                Console.SetCursorPosition(30, 10);
                Console.Write(Sotrudniki[changeIndex].AcountId);
            }
            else
            {
                Console.SetCursorPosition(30, 2);
                Console.Write(Search[changeIndex].id);
                Console.SetCursorPosition(30, 3);
                Console.Write(Search[changeIndex].Sename);
                Console.SetCursorPosition(30, 4);
                Console.Write(Search[changeIndex].Name);
                Console.SetCursorPosition(30, 5);
                Console.Write(Search[changeIndex].Patronymic);
                Console.SetCursorPosition(30, 6);
                Console.Write(Search[changeIndex].DataBorn);
                Console.SetCursorPosition(30, 7);
                Console.Write(Search[changeIndex].Pasport);
                Console.SetCursorPosition(30, 8);
                Console.Write(Search[changeIndex].JobTitle);
                Console.SetCursorPosition(30, 9);
                Console.Write(Search[changeIndex].Salary);
                Console.SetCursorPosition(30, 10);
                Console.Write(Search[changeIndex].AcountId);
            }
            while (true)
            {
                Arrows.Arrow();
                KadrovikFunction Change = Sotrudniki[changeIndex];
                if (Change != null)
                {
                    if (Arrows.pozition == 2)
                    {
                        Console.SetCursorPosition(30, 2);
                        Console.Write("                     ");
                        Console.SetCursorPosition(29, 2);
                        Change.id = Convert.ToInt32(Console.ReadLine());
                    }
                    else if (Arrows.pozition == 3)
                    {
                        Console.SetCursorPosition(30, 3);
                        Console.Write("                     ");
                        Console.SetCursorPosition(29, 3);
                        Change.Sename = Console.ReadLine();
                    }
                    else if (Arrows.pozition == 4)
                    {
                        Console.SetCursorPosition(30, 4);
                        Console.Write("                     ");
                        Console.SetCursorPosition(29, 4);
                        Change.Name = Console.ReadLine();
                    }
                    else if (Arrows.pozition == 5)
                    {
                        Console.SetCursorPosition(30, 5);
                        Console.Write("                     ");
                        Console.SetCursorPosition(29, 5);
                        Change.Patronymic = Console.ReadLine();
                    }
                    else if (Arrows.pozition == 6)
                    {
                        Console.SetCursorPosition(30, 6);
                        Console.Write("                     ");
                        Console.SetCursorPosition(29, 6);
                        Change.DataBorn = Console.ReadLine();
                    }
                    else if (Arrows.pozition == 7)
                    {
                        Console.SetCursorPosition(30, 7);
                        Console.Write("                     ");
                        Console.SetCursorPosition(29, 7);
                        Change.Pasport = Console.ReadLine();
                    }
                    else if (Arrows.pozition == 8)
                    {
                        Console.SetCursorPosition(30, 8);
                        Console.Write("                     ");
                        Console.SetCursorPosition(29, 8);
                        Change.JobTitle = Console.ReadLine();
                    }
                    else if (Arrows.pozition == 9)
                    {
                        Console.SetCursorPosition(30, 9);
                        Console.Write("                     ");
                        Console.SetCursorPosition(29, 9);
                        Change.Salary = Convert.ToInt32(Console.ReadLine());
                    }
                    else if (Arrows.pozition == 10)
                    {
                        Console.SetCursorPosition(30, 10);
                        Console.Write("                     ");
                        Console.SetCursorPosition(29, 10);
                        Change.AcountId = Convert.ToInt32(Console.ReadLine());
                    }
                    else if (Arrows.pozition == -1)
                    {
                        Sotrudniki[changeIndex] = Change;
                        changeId(Change.id);
                        Serializator.mySer(Sotrudniki, "Sotrudniki.json");
                        KadrovikFunction.Sotrudnuky = Sotrudniki;
                        Menu.clear(ClearParam);
                        KadroviKPusk();
                        break;
                    }
                    else if (Arrows.pozition == -2)
                    {
                        Menu.clear(ClearParam);
                        KadroviKPusk();
                        break;
                    }
                    else if (Arrows.pozition == -5)
                    {
                        Menu.clear(ClearParam);
                        Delete(changeIndex);
                        KadroviKPusk();
                        break;
                    }
                }
            }
        }
        public void search()
        {
            while (true)
            {
                Arrows.max = 11;
                Arrows.min = 3;
                Console.SetCursorPosition(3, 2);
                Console.Write("Выбирете праметр, по которму хотите произвести поиск:");
                Console.SetCursorPosition(3, 3);
                Console.Write("ID:");
                Console.SetCursorPosition(3, 4);
                Console.Write("Фамилия:");
                Console.SetCursorPosition(3, 5);
                Console.Write("Имя:");
                Console.SetCursorPosition(3, 6);
                Console.Write("Отчество:");
                Console.SetCursorPosition(3, 7);
                Console.Write("Дата рождения:");
                Console.SetCursorPosition(3, 8);
                Console.Write("Серия и номер поспорта::");
                Console.SetCursorPosition(3, 9);
                Console.Write("Должность:");
                Console.SetCursorPosition(3, 10);
                Console.Write("Зарплата:");
                Console.SetCursorPosition(3, 11);
                Console.Write("акаунт сотрудника:");
                Arrows.Arrow();

                if (Arrows.pozition == 3)
                {
                    Console.SetCursorPosition(30, 3);
                    Console.Write("                     ");
                    int SearchID = Convert.ToInt32(Console.ReadLine());
                    KadrovikFunction ID = new KadrovikFunction() { id = SearchID};
                    Sorted(ID.id);
                    break;
                }
                else if (Arrows.pozition == 4)
                {
                    Console.SetCursorPosition(30, 4);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 4);
                    string SearchSename = Console.ReadLine();
                    KadrovikFunction Sename = new KadrovikFunction() { Sename = SearchSename };
                    Sorted(Sename.Sename);
                    break;
                }
                else if (Arrows.pozition == 5)
                {
                    Console.SetCursorPosition(30, 5);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 5);
                    string SearchName = Console.ReadLine();
                    KadrovikFunction Name = new KadrovikFunction() { Name = SearchName }; ;
                    Sorted(Name.Name);
                    break;
                }
                else if (Arrows.pozition == 6)
                {
                    Console.SetCursorPosition(30, 6);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 6);
                    string SearcPatronymic = Console.ReadLine();
                    KadrovikFunction Patronymic = new KadrovikFunction() { Patronymic = SearcPatronymic };
                    Sorted(Patronymic.Patronymic);
                    break;
                }
                else if (Arrows.pozition == 7)
                {
                    Console.SetCursorPosition(30, 7);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 7);
                    string DataBorn = Console.ReadLine();
                    KadrovikFunction Data = new KadrovikFunction() { DataBorn = DataBorn }; 
                    Sorted(Data.DataBorn);
                    break;
                }
                else if (Arrows.pozition == 8)
                {
                    Console.SetCursorPosition(30, 8);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 8);
                    string Pasport = Console.ReadLine();
                    KadrovikFunction Pasp = new KadrovikFunction() { Pasport = Pasport };
                    Sorted(Pasp.Pasport);
                    break;
                }
                else if (Arrows.pozition == 9)
                {
                    Console.SetCursorPosition(30, 9);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 9);
                    string Job = Console.ReadLine();
                    KadrovikFunction JobLal = new KadrovikFunction() { JobTitle = Job };
                    Sorted(JobLal.JobTitle);
                    break;
                }
                else if (Arrows.pozition == 10)
                {
                    Console.SetCursorPosition(30, 10);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 10);
                    int Salo = Convert.ToInt32(Console.ReadLine());
                    KadrovikFunction Salary = new KadrovikFunction() { Salary = Salo };
                    Sorted(Salary.Salary);
                    break;
                }
                else if (Arrows.pozition == 11)
                {
                    Console.SetCursorPosition(11, 6);
                    Console.Write("                     ");
                    Console.SetCursorPosition(11, 6);
                    int Sotrudid = Convert.ToInt32(Console.ReadLine());
                    KadrovikFunction finalID = new KadrovikFunction() { AcountId = Sotrudid };
                    Sorted(finalID.AcountId);
                    break;
                }
                else if (Arrows.pozition == -2)
                {
                    Menu.clear(ClearParam);
                    KadroviKPusk();
                    break;
                }
            }
        }

        public KadrovikFunction[] Search = new KadrovikFunction[] { };

        private void Sorted(string item)
        {
            Search = Sotrudniki.Where(x => x.Sename == item || x.Name == item || x.Patronymic == item
            || x.DataBorn == item || x.Pasport == item || x.JobTitle == item).ToArray();
            Menu.clear(ClearParam);
            KadroviKPusk(false);
        }
        private void Sorted(int item)
        {
            Search = Sotrudniki.Where(x => x.id == item || x.Salary == item || x.AcountId == item).ToArray();
            Menu.clear(ClearParam);
            KadroviKPusk(false);
        }
    }
    internal class KadrovikFunction
    {
        public int id;
        public string Name;
        public string Sename;
        public string Patronymic;
        public string DataBorn;
        public string Pasport;
        public string JobTitle;
        public int Salary;
        public int AcountId;
        public static List<KadrovikFunction> Sotrudnuky = new List<KadrovikFunction>();  
    }
}
