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
        public void FindCountryByName_ReturnsMatchingObject()
        {
            //Arrange
            //Act
            string countryName = "Aruba";
            Country country = Country.FindCountryByName(countryName);

            //Assert
            Assert.AreEqual(country.GetName(), countryName);
        }
    }
}