using System;

namespace HashTableTask
{
    class App
    {
        static void Main(string[] args)
        {
            HashTable<int> hashTable = new HashTable<int>();

            hashTable.Add(4245);
            hashTable.Add(1);
            hashTable.Add(34);

            Console.WriteLine(hashTable);
        }
    }
}
