using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHomeTask
{
    class Utils
    {
        public static List<string> ReadFile(string fileName)
        {
            List<string> list = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string currentLine;

                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        list.Add(currentLine);
                    }
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

            return list;
        }

        public static void RemoveEvenNumbers(List<int> list)
        {
            list.RemoveAll(e => e % 2 == 0);
        }

        public static List<T> RemoveDuplicateItems<T>(List<T> list)
        {
            List<T> newList = new List<T>();

            foreach (T item in list)
            {
                if (!newList.Contains(item))
                {
                    newList.Add(item);
                }
            }

            return newList;
        }
    }
}
