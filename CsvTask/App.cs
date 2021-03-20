using System;

namespace CsvTask
{
    class App
    {
        public static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                Csv.ReadCsv(args[0], args[1]);
            }
            else
            {
                Console.WriteLine("Invalid number of arguments!");
                Console.WriteLine();

                Csv.PrintHelp();

                Console.ReadKey();
            }
        }
    }
}