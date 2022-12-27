namespace _10Laba
{
    internal class Menu
    {
        static public string pass = "";
        static public string login = "";


        public static void Zpusk()
        {
            menu();
            Arrows.Arrow();
            inicial();
        }
        static void inicial()
        {
            while (Arrows.pozition == 2 || Arrows.pozition == 3 || Arrows.pozition == 4)
            {
                if (Arrows.pozition == 2)
                {
                    Console.SetCursorPosition(10, 2);
                    Console.Write("         ");
                    login = "";
                    Console.SetCursorPosition(10, 2);
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    int j = 0;
                    while (true)
                    {
                        if (key.Key != ConsoleKey.Backspace)
                        {
                            Console.SetCursorPosition(10 + j, 2);
                            Console.Write("");
                            Console.SetCursorPosition(10 + j, 2);
                            login += (key.KeyChar);
                            for (int i = 0; i < 1; i++)
                            {
                                Console.Write(key.KeyChar);
                            }
                            j += 1;
                        }
                        if (key.Key == ConsoleKey.Backspace)
                        {
                            Console.SetCursorPosition(10 + j - 1, 2);
                            Console.Write(" ");
                            var del = key.KeyChar;
                            login = login.Substring(0, login.Length - 1);
                            j -= 1;
                        }
                        if (key.Key == ConsoleKey.Enter)
                        {
                            Console.SetCursorPosition(10 + j - 1, 2);
                            Console.Write(" ");
                            var del = key.KeyChar;
                            login = login.Substring(0, login.Length - 1);
                            j -= 1;
                            break;
                        }
                        key = Console.ReadKey(true);
                    }
                }
                else if (Arrows.pozition == 3)
                {
                    Console.SetCursorPosition(10, 3);
                    Console.Write("                     ");
                    pass = "";
                    Console.SetCursorPosition(10, 3);
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    int j = 0;
                    while (true)
                    {
                        if (key.Key != ConsoleKey.Backspace)
                        {
                            Console.SetCursorPosition(10, 3);
                            Console.Write("                  ");
                            Console.SetCursorPosition(10, 3);
                            pass += (Convert.ToString(key.KeyChar));
                            for (int i = 0; i < pass.Length; i++)
                            {
                                Console.Write("*");
                            }
                            j += 1;
                        }
                        if (key.Key == ConsoleKey.Backspace)
                        {
                            Console.SetCursorPosition(10 + j - 1, 3);
                            Console.Write(" ");
                            var del = key.KeyChar;
                            pass = pass.Substring(0, pass.Length - 1);
                            j -= 1;
                        }
                        if (key.Key == ConsoleKey.Enter)
                        {
                            Console.SetCursorPosition(10 + j - 1, 3);
                            Console.Write(" ");
                            var del = key.KeyChar;
                            pass = pass.Substring(0, pass.Length - 1);
                            j -= 1;
                            break;
                        }
                        key = Console.ReadKey(true);
                    }
                }
                else if (Arrows.pozition == 4)
                {
                    if (Inizialisation.init() == true)
                    {
                        Console.WriteLine("Доступ открыт");
                        if (Inizialisation.ChoiseRole == Personal.Administrator.ToString())
                        {
                            Admin start = new Admin();
                        }
                        else if (Inizialisation.ChoiseRole == Personal.Kadrovik.ToString())
                        {
                            ManagerKadr start = new ManagerKadr();
                        }
                        else if (Inizialisation.ChoiseRole == Personal.SkladManager.ToString())
                        {
                            Sklad start = new Sklad();
                        }
                        else if (Inizialisation.ChoiseRole == Personal.Buhalter.ToString())
                        {
                            Buhgaltery start = new Buhgaltery();
                        }
                        else if (Inizialisation.ChoiseRole == Personal.Kacier.ToString())
                        {
                            Kassa start = new Kassa();
                        }
                        break;
                    }
                    if (Inizialisation.init() == false)
                    {
                        Console.WriteLine("Неправильно введены логин или пароль");
                       /* foreach (var item in login)
                        {
                            Console.WriteLine(item);
                        }
                        foreach (var item in pass)
                        {
                            Console.WriteLine(item);
                        }*/
                    }
                }
                Zpusk();
            }
        }
        static void menu()
        {
            Console.SetCursorPosition(50, 0);
            Console.WriteLine("Добро пожаловть в магазин KALATUSHKA!!!");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("Логин:");
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("Пароль:");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Авторизоваться");
        }
        public static void MainMenu()
        {
            try
            {
                List<KadrovikFunction> newMenuList = KadrovikFunction.Sotrudnuky.Where(item => item.JobTitle == Inizialisation.ChoiseRole).ToList();
                Console.Clear();
                Console.SetCursorPosition(50, 0);
                Console.WriteLine($"Добро пожаловать, {newMenuList[0].Name} ");
                Console.SetCursorPosition(90, 0);
                Console.WriteLine($"Роль: {newMenuList[0].JobTitle}");
            }
            catch
            {
                List<Data> MenuList = Inizialisation.newPersonalList.Where(item => item.Role == Inizialisation.ChoiseRole).ToList();
                Console.Clear();
                Console.SetCursorPosition(50, 0);
                Console.WriteLine($"Добро пожаловать, {MenuList[0].Login} ");
                Console.SetCursorPosition(90, 0);
                Console.WriteLine($"Роль: {MenuList[0].Role}");
            }
            finally
            {
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                Console.SetCursorPosition(93, 2);
                Console.WriteLine("|");
                Console.SetCursorPosition(93, 3);
                Console.WriteLine("|");
                Console.SetCursorPosition(93, 4);
                Console.WriteLine("|");
                Console.SetCursorPosition(93, 5);
                Console.WriteLine("|");
                Console.SetCursorPosition(93, 6);
                Console.WriteLine("|");
                Console.SetCursorPosition(93, 7);
                Console.WriteLine("|");
                Console.SetCursorPosition(93, 8);
                Console.WriteLine("|");
                Console.SetCursorPosition(93, 9);
                Console.WriteLine("|");
            }

        }
        public static void DopMenuAdminCreate()
        {
            Console.SetCursorPosition(94, 2);
            Console.WriteLine(" 0 - Администратор");
            Console.SetCursorPosition(94, 3);
            Console.WriteLine(" 1 - Kacier");
            Console.SetCursorPosition(94, 4);
            Console.WriteLine(" 2 - Kadrovik");
            Console.SetCursorPosition(94, 5);
            Console.WriteLine(" 3 - SkladManager");
            Console.SetCursorPosition(94, 6);
            Console.WriteLine(" 4 - Buhalter");
            Console.SetCursorPosition(94, 7);
            Console.WriteLine("                    ");
            Console.SetCursorPosition(94, 8);
            Console.WriteLine(" S - Сохранить запись");
            Console.SetCursorPosition(94, 9);
            Console.WriteLine(" Escape - выйти");

        }
        public static void DopMenuKAdrovikCreate()
        {
            Console.SetCursorPosition(94, 2);
            Console.WriteLine(" S - Сохранить запись");
            Console.SetCursorPosition(94, 3);
            Console.WriteLine(" Escape - выйти");
        }
        public static void DopKassa()
        {
            Console.SetCursorPosition(94, 2);
            Console.WriteLine(" + - Прибавить значение");
            Console.SetCursorPosition(94, 3);
            Console.WriteLine(" - - Убавить Значение");
            Console.SetCursorPosition(94, 4);
            Console.WriteLine(" Escape - выйти");
        }
        public static void DopMenuAdminRedact()
        {
            Console.SetCursorPosition(94, 2);
            Console.WriteLine(" 0 - Администратор");
            Console.SetCursorPosition(94, 3);
            Console.WriteLine(" 1 - Кассир");
            Console.SetCursorPosition(94, 4);
            Console.WriteLine(" 2 - Кадровик");
            Console.SetCursorPosition(94, 5);
            Console.WriteLine(" 3 - Склад - менеджер");
            Console.SetCursorPosition(94, 6);
            Console.WriteLine(" 4 - Бухгалтер");
            Console.SetCursorPosition(94, 7);
            Console.WriteLine("                    ");
            Console.SetCursorPosition(94, 8);
            Console.WriteLine("S - сохранить изменения");
            Console.SetCursorPosition(94, 9);
            Console.WriteLine("DEL - удалить запись");
            Console.SetCursorPosition(94, 10);
            Console.WriteLine("Escape - выйти");
        }
        public static void DopMenuKadrovik()
        {
            Console.SetCursorPosition(3, 2);
            Console.Write("ID:");
            Console.SetCursorPosition(3, 3);
            Console.Write("Фамилия:");
            Console.SetCursorPosition(3, 4);
            Console.Write("Имя:");
            Console.SetCursorPosition(3, 5);
            Console.Write("Отчество:");
            Console.SetCursorPosition(3, 6);
            Console.Write("Дата рождения:");
            Console.SetCursorPosition(3, 7);
            Console.Write("Серия и номер поспорта::");
            Console.SetCursorPosition(3, 8);
            Console.Write("Должность:");
            Console.SetCursorPosition(3, 9);
            Console.Write("Зарплата:");
            Console.SetCursorPosition(3, 10);
            Console.Write("акаунт сотрудника:");
        }
        public static void KAdrovikRedact()
        {
            Console.SetCursorPosition(94, 8);
            Console.WriteLine("S - сохранить изменения");
            Console.SetCursorPosition(94, 9);
            Console.WriteLine("DEL - удалить запись");
            Console.SetCursorPosition(94, 10);
            Console.WriteLine("Escape - выйти");
        }
        public static void DopMenuAdminMain()
        {
            Console.SetCursorPosition(94, 2);
            Console.WriteLine("F1 - добавить запись");
            Console.SetCursorPosition(94, 3);
            Console.WriteLine("F2 - поиск");
            Console.SetCursorPosition(94, 4);
            Console.WriteLine("Escape - выйти");
        }
        public static void clear(int param)
        {
            for (int i = 0; i <= param; i++)
            {
                Console.SetCursorPosition(0, 3 + i);
                Console.WriteLine("                                                                                             ");
                Console.SetCursorPosition(0, 4 + i);
                Console.WriteLine("                                                                                             ");
                Console.SetCursorPosition(0, 5 + i);
                Console.WriteLine("                                                                                             ");
                Console.SetCursorPosition(0, 6 + i);
                Console.WriteLine("                                                                                             ");
                Console.SetCursorPosition(94, 2 + i);
                Console.WriteLine("                        ");
                Console.SetCursorPosition(94, 3 + i);
                Console.WriteLine("                        ");
                Console.SetCursorPosition(94, 4 + i);
                Console.WriteLine("                        ");
                Console.SetCursorPosition(94, 5 + i);
                Console.WriteLine("                        ");
                Console.SetCursorPosition(94, 6 + i);
                Console.WriteLine("                        ");
                Console.SetCursorPosition(94, 7 + i);
                Console.WriteLine("                        ");
            }
        }

    }
}
