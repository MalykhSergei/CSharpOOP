using System;

namespace HashTableTask
{
    class App
    {
        static void Main(string[] args)
        {
            HashTable<int> hashTable = null;

            hashTable.Remove(3);

            //hashTable.Add(4245);
            //hashTable.Add(1);
            //hashTable.Add(342);
            //hashTable.Add(424556);
            //hashTable.Add(10);

            Console.WriteLine(hashTable);
        }
    }
}
