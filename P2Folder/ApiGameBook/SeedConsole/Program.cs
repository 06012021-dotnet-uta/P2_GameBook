using System;
using BusinessLayer;

namespace SeedConsole
{
    class Program
    {
      
        static void Main(string[] args)
        {
            PopulateDBRealQuickMethod populateDB = new();

            Console.WriteLine("Hello World!");

            populateDB.PopulateThatDb();
        }
    }
}
