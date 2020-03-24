using System;
using System.IO;
using System.Collections;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {

            string sciezka_czytania = @"C:\Users\piotr\OneDrive\Desktop\dane.csv";
            string sciezka_zapisu = @"C:\Users\piotr\OneDrive\Desktop\wyjscie.txt";

            ArrayList lista = new ArrayList();

            bool brak_pliku = false;
            bool powtorka = false;
            bool puste_pole = false;

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
                        
                       foreach(string[] d in lista)
                        {
                            if(dane[0] == d[0] && dane[1] == d[1] && dane[4] == d[2])
                            {
                                Console.WriteLine("POWTORKA");
                                powtorka = true;
                                log.WriteLine("POWTORKA DANYCH DLA : " + lines[i]);

                            }
                        }


                        foreach (string pojedyncze in dane)
                        {
                            if (pojedyncze.Length == 0)
                            {
                                puste_pole = true;
                                log.WriteLine("BRAKUJACE DANE DLA : " + lines[i]);
                            }
                        }


                        if (powtorka == false && puste_pole == false)
                        {

                            sw.WriteLine(lines[i]);
                            string[] dane_osobiste = new string[3];
                            dane_osobiste[0] = dane[0];
                            dane_osobiste[1] = dane[1];
                            dane_osobiste[2] = dane[4];
                            lista.Add(dane_osobiste);
                        }
                        powtorka = false;
                        puste_pole = false;

                    }
                }

                sw.Close();
                log.Close();
            
            }




        }
               
        

        
        
    }
  
}
    

        
