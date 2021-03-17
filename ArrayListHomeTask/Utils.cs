using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHomeTask
{
    class Utils
    {
        public static List<string> GetStringsFromFileList(string fileName)
        {
            List<string> stringsFromFileList = new List<string>();

            try
            {
                using StreamReader reader = new StreamReader(fileName);

                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    stringsFromFileList.Add(currentLine);
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

            return stringsFromFileList;
        }

        public static void RemoveEvenNumbers(List<int> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                if (list[i] % 2 == 0)
                {
                    list.Remove(list[i]);
                }
            }
        }

        public static List<T> GetWithoutDuplicateItemsList<T>(List<T> list)
        {
            List<T> withoutDuplicateItemsList = new List<T>(list.Count);

            foreach (T item in list)
            {
                if (!withoutDuplicateItemsList.Contains(item))
                {
                    withoutDuplicateItemsList.Add(item);
                }
            }

            return withoutDuplicateItemsList;
        }
    }
}
