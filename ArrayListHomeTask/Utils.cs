using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHomeTask
{
    class Utils
    {
        public static List<string> GetStringsListFromFile(string fileName)
        {
            List<string> strings = new List<string>();

            try
            {
                using StreamReader reader = new StreamReader(fileName);

                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    strings.Add(currentLine);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File is not found!");
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }

            return strings;
        }

        public static void RemoveEvenNumbers(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }
        }

        public static List<T> GetItemsListWithoutDuplicates<T>(List<T> listWithDuplicates)
        {
            List<T> listWithoutDuplicates = new List<T>(listWithDuplicates.Count);

            foreach (T item in listWithDuplicates)
            {
                if (!listWithoutDuplicates.Contains(item))
                {
                    listWithoutDuplicates.Add(item);
                }
            }

            return listWithoutDuplicates;
        }
    }
}
