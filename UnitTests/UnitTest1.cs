using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using System;

using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        //create in-memory DB
        DbContextOptions<gamebookdbContext> options = new DbContextOptionsBuilder<gamebookdbContext>().UseInMemoryDatabase(databaseName: "TestingDb").Options;

        [Fact]
        public void Test1()
        {

        }
    }
}
