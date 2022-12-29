using BookListMVC.Controllers;
using BookListMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;
using System;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;

namespace BookListMVC.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var connectionstring = "Data Source=DESKTOP-LSQNGKO;Initial Catalog=BookListMVC;Trusted_Connection=True;";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (var db = new ApplicationDbContext(optionsBuilder.Options))
            {
                var booksController = new BooksController(db);

                Assert.AreEqual(1, booksController.GetBookById(1).Id);
            }
            
        }

        [TestMethod]
        public void TestMethod2()
        {
            var connectionstring = "Data Source=DESKTOP-LSQNGKO;Initial Catalog=BookListMVC;Trusted_Connection=True;";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (var db = new ApplicationDbContext(optionsBuilder.Options))
            {
                var booksController = new BooksController(db);

                Assert.AreEqual("Amintiri din Copilarie", booksController.GetBookByName("Amintiri din Copilarie").Name);
            }

        }

        [TestMethod]
        public void TestMethod3()
        {
            var connectionstring = "Data Source=DESKTOP-LSQNGKO;Initial Catalog=BookListMVC;Trusted_Connection=True;";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (var db = new ApplicationDbContext(optionsBuilder.Options))
            {
                var booksController = new BooksController(db);

                Assert.AreEqual(true, booksController.GetBookByAuthor("Ion Creanga").Author.Equals("Ion Creanga"));
            } 

        }
    }
}
