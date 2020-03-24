using System;
using System.IO;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {

            string sciezka_czytania = @"C:\Users\piotr\OneDrive\Desktop\dane.csv";
            string sciezka_zapisu = @"C:\Users\piotr\OneDrive\Desktop\wyjscie.txt";


            bool brak_pliku = false;
            
            string[] lines = null;
            string[] dane;

            StreamWriter log = new StreamWriter(@"C:\Users\piotr\OneDrive\Desktop\log.txt");


            try
            {
                 lines = System.IO.File.ReadAllLines(sciezka_czytania);
            }catch(FileNotFoundException exc)
            {
                Console.WriteLine("NIE ODNALEZIONO PLIKU");
                log.WriteLine("NIE ODNALEZIONO PLIKU W LOKALIZACJI : " + sciezka_czytania);
                log.Close();
                brak_pliku = true;
            }catch(ArgumentException argexc)
            {
                Console.WriteLine("NIEPRAWIDLOWA SCIEZKA PLIKU");
                log.WriteLine("NIEPRAWIDLOWA SCIEZKA PLIKU : " + sciezka_czytania);
                log.Close();
            }


            if (!brak_pliku)
            {

                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine(lines[i]);
                }

                StreamWriter sw = new StreamWriter(sciezka_zapisu);

                for (int i = 0; i < lines.Length; i++)
                {
                    dane = lines[i].Split(",");
                    if(dane.Length != 9)
                    {
                        log.WriteLine("POMINIETO : " + lines[i]);
                    }
                    else
                    {
                        sw.WriteLine(lines[i]);
                    }
                }

                sw.Close();
                log.Close();
            
            }




        }
                
        
    }
  
}
    

        
