using System;

namespace TrimCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            var sheet = new Trimsheet(4096, 4, 16);
            foreach (var trim in sheet.Trims)
            {
                Console.WriteLine(trim.Id);
                Console.WriteLine(trim.Corner);
                Console.WriteLine(trim.Size);
                Console.WriteLine("\n");
            }
        }
    }
}
