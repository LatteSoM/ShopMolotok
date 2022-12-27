namespace _10Laba
{
    internal class Program
    {
        static void Main()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "10LABA.json";
            bool fileExist = File.Exists(path);
            if (fileExist)
            {
                pusk();
            }
            else
            {
                Serializator.mySer(Inizialisation.PersonalList, "10LABA.json");
                pusk();
            }
        }
        public static void pusk()
        {
            Menu.Zpusk();
        }
    }

    
}