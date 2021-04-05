using System;
using System.Collections.Generic;

namespace HashTableTask
{
    class App
    {
        static void Main(string[] args)
        {
            HashTable<int> hashTable = new HashTable<int>();

            hashTable.Add(4);
            hashTable.Add(10);
            hashTable.Add(40);
            hashTable.Add(41);
            hashTable.Add(4245);
            hashTable.Add(1);
            hashTable.Add(34);

            Console.WriteLine(hashTable);
        }
    }
}
