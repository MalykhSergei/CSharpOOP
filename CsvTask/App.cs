namespace CsvTask
{
    class App
    {
        public static void Main(string[] args)
        {
            Csv.ReadCsv(args[0], args[1]);
        }
    }
}