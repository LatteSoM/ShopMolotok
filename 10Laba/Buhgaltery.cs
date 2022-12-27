using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Laba
{
    internal class Buhgaltery : ICrud
    {
        private static string file = "BuhReport.json";
        public List<BuhOperations> FinanceInfo = new List<BuhOperations>();
        private int ClearParam = 0;
        private int ScetPos = 0;
        private double AllFinance = 0;

        public Buhgaltery()
        {
            BuhaPusk();
        }
        void BuhaPusk(bool gang = true)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "BuhReport.json";
            bool fileExist = File.Exists(path);
            if (fileExist)
            {
                FinanceInfo = Serializator.myDeser<List<BuhOperations>>("BuhReport.json");
                BuhOperations.BuhRep = FinanceInfo;
            }
            else
            {
                Serializator.mySer(FinanceInfo, "BuhReport.json");
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
        BuhOperations entry = new BuhOperations();
        public void Create()
        {
            while (true)
            {
                Arrows.min = 2;
                Arrows.max = 6;
                Menu.DopMenuKAdrovikCreate();
                Console.SetCursorPosition(3, 2);
                Console.Write("ID:");
                Console.SetCursorPosition(3, 3);
                Console.Write("Название:");
                Console.SetCursorPosition(3, 4);
                Console.Write("Сумма:");
                Console.SetCursorPosition(3, 5); 
                Console.Write("Время записи:");
                Console.SetCursorPosition(3, 6);
                Console.Write("Прибавка?:");
                Arrows.Arrow();

                if (Arrows.pozition == 2)
                {
                    Console.SetCursorPosition(30, 2);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 2);
                    entry.ID = Convert.ToInt32(Console.ReadLine());
                }
                if (Arrows.pozition == 3)
                {
                    Console.SetCursorPosition(30, 3);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 3);
                    entry.Name = Console.ReadLine().ToString();
                }
                if (Arrows.pozition == 4)
                {
                    Console.SetCursorPosition(30, 4);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 4);
                    entry.Summ = Convert.ToDouble(Console.ReadLine());
                }
                if (Arrows.pozition == 5)
                {
                    Console.SetCursorPosition(30, 5);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 5);
                    entry.Date = Convert.ToDateTime(Console.ReadLine().ToString());
                }
                if (Arrows.pozition == 6)
                {
                    Console.SetCursorPosition(30, 6);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 6);
                    entry.Income = Convert.ToBoolean(Console.ReadLine());
                }
                if (Arrows.pozition == -1)
                {
                    DateTime def = new DateTime();
                    if(entry.Date == def)
                    {
                        entry.Date = DateTime.Today;
                    }
                    FinanceInfo.Add(entry);
                    BuhOperations.BuhRep = FinanceInfo;
                    Serializator.mySer(FinanceInfo, "BuhReport.json");
                    AllFinance = 0;
                    foreach(var item in FinanceInfo)
                    {
                        if (item.Income == true)
                        {
                            AllFinance += item.Summ;
                        }   
                        else if(item.Income == false)
                        {
                            AllFinance -= item.Summ;
                        }
                    }
                    Menu.clear(ClearParam);
                    BuhaPusk();
                    break;
                }
                if (Arrows.pozition == -2)
                {
                    Menu.clear(ClearParam);
                    BuhaPusk();
                    break;
                }
            }
        }

        public void Delete(int deleteIndex)
        {
            FinanceInfo.RemoveAt(deleteIndex);
            Serializator.mySer(FinanceInfo, "BuhReport.json");
            BuhOperations.BuhRep = FinanceInfo;
        }

        public void Read(bool read = true)
        {

            Console.SetCursorPosition(5, 3);
            Console.WriteLine("ID:");
            Console.SetCursorPosition(10, 3);
            Console.WriteLine("Название");
            Console.SetCursorPosition(30, 3);
            Console.WriteLine("Сумма");
            Console.SetCursorPosition(50, 3);
            Console.WriteLine("Время записи");
            Console.SetCursorPosition(70, 3);
            Console.WriteLine("Прибавка?");

            int i = 0;
            if (read == true)
            {
                if (FinanceInfo.Count != 0)
                {
                    foreach (var item in FinanceInfo)
                    {
                        Console.SetCursorPosition(5, 4 + i);
                        Console.WriteLine(item.ID);
                        Console.SetCursorPosition(10, 4 + i);
                        Console.WriteLine(item.Name);
                        Console.SetCursorPosition(30, 4 + i);
                        Console.WriteLine(item.Summ);
                        Console.SetCursorPosition(50, 4 + i);
                        Console.WriteLine(item.Date);
                        Console.SetCursorPosition(70, 4 + i);
                        Console.WriteLine(item.Income);
                        i += 1;
                        ScetPos = i;
                        ClearParam += i;
                    }
                    AllFinance = 0;
                    foreach (var item in FinanceInfo)
                    {
                        if (item.Income == true)
                        {
                            AllFinance += item.Summ;
                        }
                        else if (item.Income == false)
                        {
                            AllFinance -= item.Summ;
                        }
                    }
                }
                    Console.SetCursorPosition(0, 4+i);
                    Console.WriteLine("---------------------------------------------------------------------------------------------");
                    Console.SetCursorPosition(80, 4 + i + 1);
                    Console.WriteLine($"Итог: {Math.Round(AllFinance,2)}");
            }
            else
            {
                foreach (var item in Search)
                {
                    Console.SetCursorPosition(5, 4 + i);
                    Console.WriteLine(item.ID);
                    Console.SetCursorPosition(10, 4 + i);
                    Console.WriteLine(item.Name);
                    Console.SetCursorPosition(30, 4 + i);
                    Console.WriteLine(item.Summ);
                    Console.SetCursorPosition(50, 4 + i);
                    Console.WriteLine(item.Date);
                    Console.SetCursorPosition(70, 4 + i);
                    Console.WriteLine(item.Income);
                    i += 1;
                    ScetPos = i;
                    ClearParam += i;
                }
            }
        }

        public void Update(int changeIndex, bool gang = true)
        {
            Menu.clear(ClearParam);
            Arrows.max = 6;
            Arrows.min = 2;
            Arrows.pozition = 2;
            Console.SetCursorPosition(94, 2);
            Console.WriteLine("S - сохранить изменения");
            Console.SetCursorPosition(94, 3);
            Console.WriteLine("DEL - удалить запись");
            Console.SetCursorPosition(94, 4);
            Console.WriteLine("Escape - выйти");
            Console.SetCursorPosition(5, 2);
            Console.WriteLine("ID:");
            Console.SetCursorPosition(5, 3);
            Console.WriteLine("Название");
            Console.SetCursorPosition(5, 4);
            Console.WriteLine("Сумма");
            Console.SetCursorPosition(5, 5);
            Console.WriteLine("Время записи");
            Console.SetCursorPosition(5, 6);
            Console.WriteLine("Прибавка?");
            if (gang)
            {
                Console.SetCursorPosition(30, 2);
                Console.Write(FinanceInfo[changeIndex].ID);
                Console.SetCursorPosition(30, 3);
                Console.Write(FinanceInfo[changeIndex].Name);
                Console.SetCursorPosition(30, 4);
                Console.Write(FinanceInfo[changeIndex].Summ);
                Console.SetCursorPosition(30, 5);
                Console.Write(FinanceInfo[changeIndex].Date);
                Console.SetCursorPosition(30, 6);
                Console.Write(FinanceInfo[changeIndex].Income);
            }
            else
            {
                Console.SetCursorPosition(30, 2);
                Console.Write(Search[changeIndex].ID);
                Console.SetCursorPosition(30, 3);
                Console.Write(Search[changeIndex].Name);
                Console.SetCursorPosition(30, 4);
                Console.Write(Search[changeIndex].Summ);
                Console.SetCursorPosition(30, 5);
                Console.Write(Search[changeIndex].Date);
                Console.SetCursorPosition(30, 6);
                Console.Write(Search[changeIndex].Income);
            }
            while (true)
            {
                Arrows.Arrow();
                BuhOperations Change = FinanceInfo[changeIndex];
                if (Change != null)
                {
                    if (Arrows.pozition == 2)
                    {
                        Console.SetCursorPosition(30, 2);
                        Console.Write("                     ");
                        Console.SetCursorPosition(29, 2);
                        Change.ID = Convert.ToInt32(Console.ReadLine());
                    }
                    else if (Arrows.pozition == 3)
                    {
                        Console.SetCursorPosition(30, 3);
                        Console.Write("                     ");
                        Console.SetCursorPosition(29, 3);
                        Change.Name = Console.ReadLine();
                    }
                    else if (Arrows.pozition == 4)
                    {
                        Console.SetCursorPosition(30, 4);
                        Console.Write("                     ");
                        Console.SetCursorPosition(29, 4);
                        Change.Summ = Convert.ToDouble(Console.ReadLine());
                    }
                    else if (Arrows.pozition == 5)
                    {
                        Console.SetCursorPosition(30, 5);
                        Console.Write("                     ");
                        Console.SetCursorPosition(29, 5);
                        Change.Date = Convert.ToDateTime(Console.ReadLine());
                    }
                    else if (Arrows.pozition == 6)
                    {
                        Console.SetCursorPosition(30, 6);
                        Console.Write("                     ");
                        Console.SetCursorPosition(29, 6);
                        Change.Income = Convert.ToBoolean(Console.ReadLine());
                    }
                    else if (Arrows.pozition == -1)
                    {
                        FinanceInfo[changeIndex] = Change;
                        AllFinance = 0;
                        foreach (var item in FinanceInfo)
                        {
                            if (item.Income == true)
                            {
                                AllFinance += item.Summ;
                            }
                            else if (item.Income == false)
                            {
                                AllFinance -= item.Summ;
                            }
                        }
                        Serializator.mySer(FinanceInfo, "BuhReport.json");
                        BuhOperations.BuhRep = FinanceInfo;
                        Menu.clear(ClearParam);
                        BuhaPusk();
                        break;
                    }
                    else if (Arrows.pozition == -2)
                    {
                        Menu.clear(ClearParam);
                        BuhaPusk();
                        break;
                    }
                    else if (Arrows.pozition == -5)
                    {
                        Menu.clear(ClearParam);
                        Delete(changeIndex);
                        BuhaPusk();
                        break;
                    }
                }
            }
        }
        public void search()
        {
            while (true)
            {
                Arrows.max = 7;
                Arrows.min = 3;
                Console.SetCursorPosition(3, 2);
                Console.Write("Выбирете праметр, по которму хотите произвести поиск:");
                Console.SetCursorPosition(3, 3);
                Console.Write("ID:");
                Console.SetCursorPosition(3, 4);
                Console.Write("Название:");
                Console.SetCursorPosition(3, 5);
                Console.Write("Сумма:");
                Console.SetCursorPosition(3, 6);
                Console.Write("Дата:");
                Console.SetCursorPosition(3, 7);
                Console.Write("Прибавка?:");
                Arrows.Arrow();

                if (Arrows.pozition == 3)
                {
                    Console.SetCursorPosition(30, 3);
                    Console.Write("                     ");
                    int SearchID = Convert.ToInt32(Console.ReadLine());
                    BuhOperations ID = new BuhOperations() { ID = SearchID };
                    Sorted(ID.ID);
                    break;
                }
                else if (Arrows.pozition == 4)
                {
                    Console.SetCursorPosition(30, 4);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 4);
                    string SearchName = Console.ReadLine();
                    BuhOperations Name = new BuhOperations() { Name = SearchName };
                    Sorted(Name.Name);
                    break;
                }
                else if (Arrows.pozition == 5)
                {
                    Console.SetCursorPosition(30, 5);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 5);
                    double SearchSumm = Convert.ToDouble(Console.ReadLine());
                    BuhOperations Summ = new BuhOperations() { Summ = SearchSumm }; ;
                    Sorted(Summ.Summ);
                    break;
                }
                else if (Arrows.pozition == 6)
                {
                    Console.SetCursorPosition(30, 6);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 6);
                    DateTime SearcDate = Convert.ToDateTime(Console.ReadLine());
                    BuhOperations Date = new BuhOperations() { Date = SearcDate };
                    Sorted(Date.Date);
                    break;
                }
                else if (Arrows.pozition == 7)
                {
                    Console.SetCursorPosition(30, 7);
                    Console.Write("                     ");
                    Console.SetCursorPosition(29, 7);
                    bool SearchIncome = Convert.ToBoolean(Console.ReadLine());
                    BuhOperations entry = new BuhOperations() { Income = SearchIncome };
                    Sorted(entry.Income);
                    break;
                }
                else if (Arrows.pozition == -2)
                {
                    Menu.clear(ClearParam);
                    BuhaPusk();
                    break;
                }
            }
        }
        public BuhOperations[] Search = new BuhOperations[] { };
        private void Sorted(string item)
        {
            Search = FinanceInfo.Where(x => x.Name == item).ToArray();
            Menu.clear(ClearParam);
            BuhaPusk(false);
        }
        private void Sorted(int item)
        {
            Search = FinanceInfo.Where(x => x.ID == item).ToArray();
            Menu.clear(ClearParam);
            BuhaPusk(false);
        }
        private void Sorted(double item)
        {
            Search = FinanceInfo.Where(x => x.Summ == item).ToArray();
            Menu.clear(ClearParam);
            BuhaPusk(false);
        }
        private void Sorted(DateTime item)
        {
            Search = FinanceInfo.Where(x => x.Date == item).ToArray();
            Menu.clear(ClearParam);
            BuhaPusk(false);
        }
        private void Sorted(bool item)
        {
            Search = FinanceInfo.Where(x => x.Income == item).ToArray();
            Menu.clear(ClearParam);
            BuhaPusk(false);
        }
    }
    internal class BuhOperations
    {
        public int ID;
        public string Name;
        public double Summ;
        public DateTime Date;
        public bool Income;
        public static List<BuhOperations> BuhRep = new List<BuhOperations>();
    }
    internal class BuhHelp : BuhOperations
    {
        public BuhHelp(int iD, string name, double summ, DateTime date, bool income)
        {
            ID = iD;
            Name = name;
            Summ = summ;
            Date = date;
            Income = income;
        }
    }

}
