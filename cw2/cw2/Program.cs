using System;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\piotr\OneDrive\Desktop\dane.csv");

            for(int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }
        }
    }
}
