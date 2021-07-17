using System;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;

namespace SeedConsole
{
    class Program
    {

        

     
        static void Main(string[] args)
        {
            

            var optionsBuilder = new DbContextOptionsBuilder<gamebookdbContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionStringSecureValue("MyConnectionString"));
           // context = new ApplicationDbContext(optionsBuilder.Options);


            gamebookdbContext context = new gamebookdbContext(optionsBuilder);

            PopulateDBRealQuickMethod populateDB = new(context);

            Console.WriteLine("Hello World!");

            populateDB.PopulateThatDb();
        }
    }
}
