using System;

namespace HashTableTask
{
    class App
    {
        static void Main(string[] args)
        {
            HashTable<int> hashTable = new HashTable<int>(10) { 1, 4, 6 };

            hashTable.Add(14);
            hashTable.Add(15);
            hashTable.Add(20);

            hashTable.Remove(15);

            foreach (var item in hashTable)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(hashTable.Contains(140));
        }
    }
}
