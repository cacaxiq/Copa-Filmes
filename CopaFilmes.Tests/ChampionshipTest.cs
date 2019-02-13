using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CopaFilmes.Tests
{
    [TestClass]
    public class ChampionshipTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var service = new MoviesChampionshipService();

            var list = new List<Movie> {
            new Movie("t1","ABCD",2018, 7.5),
            new Movie("t2","ABCD",2018, 6.5),
            new Movie("t3","ABCD",2018, 5.5),
            new Movie("t4","ABCD",2018, 4.5),
            new Movie("t5","ABCD",2018, 3.5),
            new Movie("t6","ABCD",2018, 2.5),
            new Movie("t7","ABCD",2018, 1.5),
            new Movie("t8","ABCD",2018, 1.0)};


            var result = service.GetResultChampionship(list.ToArray());
            Assert.AreEqual("t1", result.Champion.Id);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var service = new MoviesChampionshipService();

            var list = new List<Movie> {
            new Movie("t1","ABCD",2018, 7.5),
            new Movie("t2","bBCD",2018, 7.5),
            new Movie("t3","cBCD",2018, 7.5),
            new Movie("t4","dBCD",2018, 7.5),
            new Movie("t5","eBCD",2018, 7.5),
            new Movie("t6","fBCD",2018, 7.5),
            new Movie("t7","gBCD",2018, 7.5),
            new Movie("t8","hBCD",2018, 7.5)};


            var result = service.GetResultChampionship(list.ToArray());
            Assert.AreEqual("t1", result.Champion.Id);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var service = new MoviesChampionshipService();

            var list = new List<Movie> {
            new Movie("t1","ABCD",2018, 7.5),
            new Movie("t2","ABCD",2018, 7.5),
            new Movie("t3","ABCD",2018, 7.5),
            new Movie("t4","AACD",2018, 7.5),
            new Movie("t5","ABCD",2018, 7.5),
            new Movie("t6","ABCD",2018, 7.5),
            new Movie("t7","ABCD",2018, 7.5),
            new Movie("t8","ABCD",2018, 7.5)};


            var result = service.GetResultChampionship(list.ToArray());
            Assert.AreEqual("t4", result.Champion.Id);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var service = new MoviesChampionshipService();

            var list = new List<Movie> {
            new Movie("t1","ABCD",2018, 7.5),
            new Movie("t2","ABaD",2018, 7.5),
            new Movie("t3","ABCD",2018, 7.5),
            new Movie("t4","ABcD",2018, 7.5),
            new Movie("t5","ABCD",2018, 7.5),
            new Movie("t6","ABCD",2018, 7.5),
            new Movie("t7","ABcD",2018, 7.5),
            new Movie("t8","ABCD",2018, 7.5)};


            var result = service.GetResultChampionship(list.ToArray());
            Assert.AreEqual("t2", result.Champion.Id);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var service = new MoviesChampionshipService();

            var list = new List<Movie> {
            new Movie("t1","ABCD",2018, 7.5),
            new Movie("t2","ABCD",2018, 7.5),
            new Movie("t3","ABCD",2018, 6.5),
            new Movie("t4","ABcD",2018, 6.5),
            new Movie("t5","ABCD",2018, 9.5),
            new Movie("t6","ABCD",2018, 6.5),
            new Movie("t7","ABcD",2018, 6.5),
            new Movie("t8","ABCD",2018, 7.5)};


            var result = service.GetResultChampionship(list.ToArray());
            Assert.AreEqual("t5", result.Champion.Id);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var service = new MoviesChampionshipService();

            var list = new List<Movie> {
            new Movie("t1","ABCD",2018, 7.5),
            new Movie("t2","ABCD",2018, 6.5),
            new Movie("t3","ABCD",2018, 5.5),
            new Movie("t4","ABCD",2018, 4.5),
            new Movie("t5","ABCD",2018, 3.5),
            new Movie("t6","ABCD",2018, 2.5),
            new Movie("t7","ABCD",2018, 1.5),
            new Movie("t8","ABCD",2018, 1.0)};


            var result = service.GetResultChampionship(list.ToArray());
            Assert.AreNotEqual("t2", result.Champion.Id);
            Assert.AreNotEqual("t3", result.Champion.Id);
            Assert.AreNotEqual("t4", result.Champion.Id);
            Assert.AreNotEqual("t5", result.Champion.Id);
            Assert.AreNotEqual("t6", result.Champion.Id);
            Assert.AreNotEqual("t7", result.Champion.Id);
            Assert.AreNotEqual("t8", result.Champion.Id);
        }

        [TestMethod]
        public void TestMethod7()
        {
            var service = new MoviesChampionshipService();

            var list = new List<Movie> {
            new Movie("t1","ABCD",2018, 7.5),
            new Movie("t2","bBCD",2018, 7.5),
            new Movie("t3","cBCD",2018, 7.5),
            new Movie("t4","dBCD",2018, 7.5),
            new Movie("t5","eBCD",2018, 7.5),
            new Movie("t6","fBCD",2018, 7.5),
            new Movie("t7","gBCD",2018, 7.5),
            new Movie("t8","hBCD",2018, 7.5)};


            var result = service.GetResultChampionship(list.ToArray());
            Assert.AreNotEqual("t2", result.Champion.Id);
            Assert.AreNotEqual("t3", result.Champion.Id);
            Assert.AreNotEqual("t4", result.Champion.Id);
            Assert.AreNotEqual("t5", result.Champion.Id);
            Assert.AreNotEqual("t6", result.Champion.Id);
            Assert.AreNotEqual("t7", result.Champion.Id);
            Assert.AreNotEqual("t8", result.Champion.Id);
        }

        [TestMethod]
        public void TestMethod8()
        {
            var service = new MoviesChampionshipService();

            var list = new List<Movie> {
            new Movie("t1","ABCD",2018, 7.5),
            new Movie("t2","ABCD",2018, 7.5),
            new Movie("t3","ABCD",2018, 7.5),
            new Movie("t4","AACD",2018, 7.5),
            new Movie("t5","ABCD",2018, 7.5),
            new Movie("t6","ABCD",2018, 7.5),
            new Movie("t7","ABCD",2018, 7.5),
            new Movie("t8","ABCD",2018, 7.5)};

            var result = service.GetResultChampionship(list.ToArray());
            Assert.AreNotEqual("t2", result.Champion.Id);
            Assert.AreNotEqual("t3", result.Champion.Id);
            Assert.AreNotEqual("t1", result.Champion.Id);
            Assert.AreNotEqual("t5", result.Champion.Id);
            Assert.AreNotEqual("t6", result.Champion.Id);
            Assert.AreNotEqual("t7", result.Champion.Id);
            Assert.AreNotEqual("t8", result.Champion.Id);
        }

        [TestMethod]
        public void TestMethod9()
        {
            var service = new MoviesChampionshipService();

            var list = new List<Movie> {
            new Movie("t1","ABCD",2018, 7.5),
            new Movie("t2","ABaD",2018, 7.5),
            new Movie("t3","ABCD",2018, 7.5),
            new Movie("t4","ABcD",2018, 7.5),
            new Movie("t5","ABCD",2018, 7.5),
            new Movie("t6","ABCD",2018, 7.5),
            new Movie("t7","ABcD",2018, 7.5),
            new Movie("t8","ABCD",2018, 7.5)};

            var result = service.GetResultChampionship(list.ToArray());
            Assert.AreNotEqual("t1", result.Champion.Id);
            Assert.AreNotEqual("t3", result.Champion.Id);
            Assert.AreNotEqual("t4", result.Champion.Id);
            Assert.AreNotEqual("t5", result.Champion.Id);
            Assert.AreNotEqual("t6", result.Champion.Id);
            Assert.AreNotEqual("t7", result.Champion.Id);
            Assert.AreNotEqual("t8", result.Champion.Id);
        }

        [TestMethod]
        public void TestMethod10()
        {
            var service = new MoviesChampionshipService();

            var list = new List<Movie> {
            new Movie("t1","ABCD",2018, 7.5),
            new Movie("t2","ABCD",2018, 7.5),
            new Movie("t3","ABCD",2018, 6.5),
            new Movie("t4","ABcD",2018, 6.5),
            new Movie("t5","ABCD",2018, 9.5),
            new Movie("t6","ABCD",2018, 6.5),
            new Movie("t7","ABcD",2018, 6.5),
            new Movie("t8","ABCD",2018, 7.5)};

            var result = service.GetResultChampionship(list.ToArray());
            Assert.AreNotEqual("t2", result.Champion.Id);
            Assert.AreNotEqual("t3", result.Champion.Id);
            Assert.AreNotEqual("t4", result.Champion.Id);
            Assert.AreNotEqual("t1", result.Champion.Id);
            Assert.AreNotEqual("t6", result.Champion.Id);
            Assert.AreNotEqual("t7", result.Champion.Id);
            Assert.AreNotEqual("t8", result.Champion.Id);
        }
    }
}
