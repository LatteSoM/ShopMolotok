using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Laba
{
    internal class Sklad : ICrud
    {
        private static string file = "SkladInfo.json";
        public List<SkladOperations> ProductList = new List<SkladOperations>() { };
        private int ClearParam = 0;
        private int ScetPos = 0;
        public Sklad()
        {
            SkladPusk();
        }
        void SkladPusk(bool gang = true)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "SkladInfo.json";
            bool fileExist = File.Exists(path);
            if (fileExist)
            {
                ProductList = Serializator.myDeser<List<SkladOperations>>("SkladInfo.json");
                SkladOperations.Products = ProductList;
            }
            else
            {
                Serializator.mySer(ProductList, "SkladInfo.json");
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
        SkladOperations product = new SkladOperations();
        public void Create()
        {
            while (true)
            {
                Arrows.min = 2;
                Arrows.max = 5;
                Menu.DopMenuKAdrovikCreate();
                Console.SetCursorPosition(3, 2);
                Console.Write("ID:");
                Console.SetCursorPosition(3, 3);
                Console.Write("Название:");
                Console.SetCursorPosition(3, 4);
                Console.Write("Цена за штуку:");
                Console.SetCursorPosition(3, 5);
                Console.Write("Количество :");
                Arrows.Arrow();

                if (Arrows.pozition == 2)
                {
                    Console.SetCursorPosition(20, 2);
                    Console.Write("                     ");
                    Console.SetCursorPosition(19, 2);
                    product.ID = Convert.ToInt32(Console.ReadLine());
                }
                if (Arrows.pozition == 3)
                {
                    Console.SetCursorPosition(20, 3);
                    Console.Write("                     ");
                    Console.SetCursorPosition(19, 3);
                    product.ProductName = Console.ReadLine().ToString();
                }
                if (Arrows.pozition == 4)
                {
                    Console.SetCursorPosition(20, 4);
                    Console.Write("                     ");
                    Console.SetCursorPosition(19, 4);
                    product.Price = Convert.ToDouble(Console.ReadLine());
                }
                if (Arrows.pozition == 5)
                {
                    Console.SetCursorPosition(20, 5);
                    Console.Write("                     ");
                    Console.SetCursorPosition(19, 5);
                    product.Amount = Convert.ToInt32(Console.ReadLine());
                }
                if (Arrows.pozition == -1)
                {
                    ProductList.Add(product);
                    Serializator.mySer(ProductList, "SkladInfo.json");
                    SkladOperations.Products = ProductList; 
                    Menu.clear(ClearParam);
                    SkladPusk();
                    break;
                }
                if (Arrows.pozition == -2)
                {
                    Menu.clear(ClearParam);
                    SkladPusk();
                    break;
                }
            }
        }

        public void Delete(int deleteIndex)
        {
            ProductList.RemoveAt(deleteIndex);
            SkladOperations.Products = ProductList;
            Serializator.mySer(ProductList, "SkladInfo.json");
        }

        public void Read(bool read = true)
        {
            Console.SetCursorPosition(10, 3);
            Console.WriteLine("ID:");
            Console.SetCursorPosition(20, 3);
            Console.WriteLine("Название");
            Console.SetCursorPosition(45, 3);
            Console.WriteLine("Цена за штуку:");
            Console.SetCursorPosition(70, 3);
            Console.WriteLine("Количество на складе");

            int i = 0;
            if (read == true)
            {
                foreach (var item in ProductList)
                {
                    Console.SetCursorPosition(10, 4 + i);
                    Console.WriteLine(item.ID);
                    Console.SetCursorPosition(20, 4 + i);
                    Console.WriteLine(item.ProductName);
                    Console.SetCursorPosition(45, 4 + i);
                    Console.WriteLine(item.Price);
                    Console.SetCursorPosition(70, 4 + i);
                    Console.WriteLine(item.Amount);
                    i += 1;
                    ScetPos = i;
                    ClearParam += i;
                    SkladOperations.Products = ProductList;
                }
            }
            else
            {
                foreach (var item in Search)
                {
                    Console.SetCursorPosition(10, 4 + i);
                    Console.WriteLine(item.ID);
                    Console.SetCursorPosition(20, 4 + i);
                    Console.WriteLine(item.ProductName);
                    Console.SetCursorPosition(45, 4 + i);
                    Console.WriteLine(item.Price);
                    Console.SetCursorPosition(70, 4 + i);
                    Console.WriteLine(item.Amount);
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
            Console.Write("Название:");
            Console.SetCursorPosition(3, 4);
            Console.Write("Цена за штуку:");
            Console.SetCursorPosition(3, 5);
            Console.Write("Количество на складе:");
            Menu.DopMenuAdminRedact();
            if (gang)
            {
                Console.SetCursorPosition(20, 2);
                Console.Write(ProductList[changeIndex].ID);
                Console.SetCursorPosition(20, 3);
                Console.Write(ProductList[changeIndex].ProductName);
                Console.SetCursorPosition(20, 4);
                Console.Write(ProductList[changeIndex].Price);
                Console.SetCursorPosition(20, 5);
                Console.Write(ProductList[changeIndex].Amount);
            }
            else
            {
                Console.SetCursorPosition(20, 2);
                Console.Write(Search[changeIndex].ID);
                Console.SetCursorPosition(20, 3);
                Console.Write(Search[changeIndex].ProductName);
                Console.SetCursorPosition(20, 4);
                Console.Write(Search[changeIndex].Price);
                Console.SetCursorPosition(20, 5);
                Console.Write(Search[changeIndex].Amount);
            }
            while (true)
            {
                Arrows.Arrow();
                SkladOperations Change = ProductList[changeIndex];
                if (Change != null)
                {
                    if (Arrows.pozition == 2)
                    {
                        Console.SetCursorPosition(20, 2);
                        Console.Write("                     ");
                        Console.SetCursorPosition(20, 2);
                        Change.ID = Convert.ToInt32(Console.ReadLine());
                    }
                    else if (Arrows.pozition == 3)
                    {
                        Console.SetCursorPosition(20, 3);
                        Console.Write("                     ");
                        Console.SetCursorPosition(20, 3);
                        Change.ProductName = Console.ReadLine();
                    }
                    else if (Arrows.pozition == 4)
                    {
                        Console.SetCursorPosition(20, 4);
                        Console.Write("                     ");
                        Console.SetCursorPosition(20, 4);
                        Change.Price = Convert.ToDouble(Console.ReadLine());
                    }
                    else if (Arrows.pozition == 5)
                    {
                        Console.SetCursorPosition(20, 5);
                        Console.Write("                     ");
                        Console.SetCursorPosition(20, 5);
                        Change.Amount = Convert.ToInt32(Console.ReadLine());
                    }
                    else if (Arrows.pozition == -1)
                    {
                        ProductList[changeIndex] = Change;
                        Serializator.mySer(ProductList, "SkladInfo.json");
                        Menu.clear(ClearParam);
                        SkladPusk();
                        break;
                    }
                    else if (Arrows.pozition == -2)
                    {
                        Menu.clear(ClearParam);
                        SkladPusk();
                        break;
                    }
                    else if (Arrows.pozition == -5)
                    {
                        Menu.clear(ClearParam);
                        Delete(changeIndex);
                        SkladPusk();
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
                Console.Write("Наименование:");
                Console.SetCursorPosition(3, 5);
                Console.Write("Цена за штуку:");
                Console.SetCursorPosition(3, 6);
                Console.Write("Количество:");
                Arrows.Arrow();

                if (Arrows.pozition == 3)
                {
                    Console.SetCursorPosition(20, 3);
                    Console.Write("                     ");
                    int SearchID = Convert.ToInt32(Console.ReadLine());
                    SkladOperations ID = new SkladOperations() {ID = SearchID};
                    Sorted(ID.ID);
                    break;
                }
                else if (Arrows.pozition == 4)
                {
                    Console.SetCursorPosition(20, 4);
                    Console.Write("                     ");
                    Console.SetCursorPosition(20, 4);
                    string SearcName = Console.ReadLine();
                    SkladOperations Name = new SkladOperations() { ProductName = SearcName };
                    Sorted(Name.ProductName);
                    break;
                }
                else if (Arrows.pozition == 5)
                {
                    Console.SetCursorPosition(20, 5);
                    Console.Write("                     ");
                    Console.SetCursorPosition(20, 5);
                    double SearchPrice = Convert.ToDouble(Console.ReadLine());
                    SkladOperations Price = new SkladOperations() { Price = SearchPrice };
                    Sorted(Price.Price);
                    break;
                }
                else if (Arrows.pozition == 6)
                {
                    Console.SetCursorPosition(20, 6);
                    Console.Write("                     ");
                    Console.SetCursorPosition(20, 6);
                    int SearchAmount = Convert.ToInt32(Console.ReadLine());
                    SkladOperations Amount = new SkladOperations() { Amount = SearchAmount };
                    Sorted(Amount.Amount);
                    break;
                }
                else if (Arrows.pozition == -2)
                {
                    Menu.clear(ClearParam);
                    SkladPusk();
                    break;
                }
            }
        }
        public SkladOperations[] Search = new SkladOperations[] { };

        private void Sorted(string item)
        {
            Search = ProductList.Where(x => x.ProductName == item).ToArray();
            Menu.clear(ClearParam);
            SkladPusk(false);
        }
        private void Sorted(int item)
        {
            Search = ProductList.Where(x => x.ID == item || x.Amount == item).ToArray();
            Menu.clear(ClearParam);
            SkladPusk(false);
        }
        private void Sorted(double item)
        {
            Search = ProductList.Where(x => x.Price == item).ToArray();
            Menu.clear(ClearParam);
            SkladPusk(false);
        }
    }
    internal class SkladOperations
    {
        public int ID;
        public string ProductName;
        public double Price;
        public int Amount;
        public static List<SkladOperations> Products = new List<SkladOperations>();
        public static List<SkladOperations> Sort = new List<SkladOperations>();
    }

}
