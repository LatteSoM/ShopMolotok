using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Laba
{
    internal class Kassa
    {
        private static string file = "OrderInfo.json";
        public List<KassOperations> KAssaList = new List<KassOperations>() { };
        private int ClearParam = 0;
        private int ScetPos = 0;
        private double AllFinance = 0;
        public Kassa()
        {
            KassaPusk();
        }
        void KassaPusk(bool gang = true)
        {
            if(gang)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "SkladInfo.json";
                bool fileExist = File.Exists(path);
                if (fileExist)
                {
                    KAssaList = Serializator.myDeser<List<KassOperations>>("SkladInfo.json");
                    /* BuhOperations.BuhRep = KAssaList;*/
                }
            }
            Menu.MainMenu();
            Read();
            Console.SetCursorPosition(94, 2);
            Console.WriteLine("S - Звершить заказ");
            Console.SetCursorPosition(94, 3);
            Console.WriteLine("Escape - выйти");
            Arrows.max = ScetPos + 3;
            Arrows.min = 4;
            Arrows.Arrow();
            if (Arrows.pozition == -2)
            {
                Arrows.min = 2;
                Arrows.max = 4;
                Console.Clear();
                Program.pusk();
            }
            else if (Arrows.pozition == -1)
            {
                SaveOrder();
            }
            else
            {
                Menu.clear(ClearParam);
                Create();
            }
        }
        KassOperations zakaz = new KassOperations();
        public void Create()
        {
            while (true)
            {
                Arrows.min = 5;
                Arrows.max = 5;
                Menu.DopKassa();
                Console.SetCursorPosition(3, 2);
                Console.Write("ID:");
                Console.SetCursorPosition(3, 3);
                Console.Write("Название:");
                Console.SetCursorPosition(3, 4);
                Console.Write("Цена за штуку:");
                Console.SetCursorPosition(3, 5);
                Console.Write("Количество :");
                int index = Arrows.pozition - 4;
                Console.SetCursorPosition(20, 2);
                Console.Write(KAssaList[index].ID);
                Console.SetCursorPosition(20, 3);
                Console.Write(KAssaList[index].ProductName);
                Console.SetCursorPosition(20, 4);
                Console.Write(KAssaList[index].Price);
                Console.SetCursorPosition(20, 5);
                Console.Write(KAssaList[index].SelectAmount);
                int amountMax = KAssaList[index].Amount;
                int amountMin = 0;
                Arrows.Arrow();

                if (Arrows.pozition == 5)
                {

                    ConsoleKeyInfo key = Console.ReadKey(false);
                    while (key.Key != ConsoleKey.Enter)
                    {
                        if (key.Key == ConsoleKey.OemPlus)
                        {
                            zakaz.SelectAmount++;
                            if (zakaz.SelectAmount > amountMax)
                            {
                                zakaz.SelectAmount = amountMin;
                            }
                        }
                        else if (key.Key == ConsoleKey.OemMinus)
                        {
                            zakaz.SelectAmount--;
                            if (zakaz.SelectAmount < amountMin)
                            {
                                zakaz.SelectAmount = amountMax;
                            }
                        }
                        Console.SetCursorPosition(20, 5);
                        Console.Write("                     ");
                        Console.SetCursorPosition(20, 5);
                        Console.Write(zakaz.SelectAmount);
                        key = Console.ReadKey();
                    }

                }
                KAssaList[index].SelectAmount = zakaz.SelectAmount;
                KassOperations.ZakazOnKassa.Add(KAssaList[index]);
                Menu.clear(ClearParam);
                KassaPusk(false);
                break;
            }
        }
        void SaveOrder()
        {
            SkladOperations.Products = Serializator.myDeser<List<SkladOperations>>("SkladInfo.json");
            foreach (var item in SkladOperations.Products)
            {
                foreach (var item2 in KassOperations.ZakazOnKassa)
                {
                    if (item.ID == item2.ID)
                    {
                        item.Amount -= item2.SelectAmount;
                    }
                }
            }
            Serializator.mySer(KassOperations.ZakazOnKassa, "OrderInfo.json");
            Serializator.mySer(SkladOperations.Products, "SkladInfo.json");

            BuhOperations.BuhRep = Serializator.myDeser<List<BuhOperations>>("BuhReport.json");
            foreach (var item in KassOperations.ZakazOnKassa)
            {
                int id = BuhOperations.BuhRep.Count;
                BuhOperations itemToAdd = new BuhHelp(id + 1, item.ProductName, item.Price, DateTime.Now, true);
                BuhOperations.BuhRep.Add(itemToAdd);
            }
            Serializator.mySer(BuhOperations.BuhRep, "BuhReport.json");
            Menu.clear(ClearParam);
            Console.SetCursorPosition(94, 4);
            Console.WriteLine("Успешно Сохранено!");
            KassOperations.ZakazOnKassa.Clear();
            KAssaList.Clear();
            KassaPusk();
        }
        public void Read()
        {
            Console.SetCursorPosition(10, 3);
            Console.WriteLine("ID:");
            Console.SetCursorPosition(20, 3);
            Console.WriteLine("Название");
            Console.SetCursorPosition(45, 3);
            Console.WriteLine("Цена за штуку:");
            Console.SetCursorPosition(70, 3);
            Console.WriteLine("Количество:");

            int i = 0;


            foreach (var item in KAssaList)
            {
                Console.SetCursorPosition(10, 4 + i);
                Console.WriteLine(item.ID);
                Console.SetCursorPosition(20, 4 + i);
                Console.WriteLine(item.ProductName);
                Console.SetCursorPosition(45, 4 + i);
                Console.WriteLine(item.Price);
                Console.SetCursorPosition(70, 4 + i);
                Console.WriteLine($"|     {item.SelectAmount}     |");
                i += 1;
                ScetPos = i;
                ClearParam += i;
            }
            AllFinance = 0;
            foreach (var item in KAssaList)
            {
                AllFinance = item.Price * item.SelectAmount;
            }
            Console.SetCursorPosition(0, 4 + i);
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(80, 4 + i + 1);
            Console.WriteLine($"Итог: {AllFinance}");

        }
    }
    internal class KassOperations : SkladOperations
    {
        public int SelectAmount;
        public static List<KassOperations> ZakazOnKassa = new List<KassOperations>();
    }
}
