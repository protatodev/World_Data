using Microsoft.VisualStudio.TestTools.UnitTesting;
using World_Data.Models;
using System;
using System.Collections.Generic;

namespace World_Data.Tests
{

    [TestClass]
    public class World_DataTest : IDisposable
    {
        public void Dispose()
        {
            //ListMaker.DeleteAll();
        }

        public World_DataTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=world_test;";
        }

        [TestMethod]
        public void GetAll_DbStartsEmpty_0()
        {
            //Arrange
            //Act
            //int result = ListMaker.GetAll().Count;

            //Assert
            //Assert.AreEqual(0, result);
        }
    }
}