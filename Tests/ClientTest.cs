using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using HairSalon.Objects;

namespace HairSalon
{
    public class ClientTest : IDisposable
    {
        public void HairSalonTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void Test_DatabaseEmptyAtFirst()
        {
            //Arrange, Act
            int result = Client.GetAll().Count;

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_Equal_ReturnsTrueIfNamesAreTheSame()
        {
            //Arrange, Act
            Client firstClient = new Client("Mow the lawn");
            Client secondClient = new Client("Mow the lawn");

            //Assert
            Assert.Equal(firstClient, secondClient);
        }

        [Fact]
        public void Test_Save_SavesToDatabase()
        {
            //Arrange
            Client testClient = new Client("Betsy Ross");

            //Act
            testClient.Save();
            List<Client> result = Client.GetAll();
            List<Client> testList = new List<Client>{testClient};

            //Assert
            Assert.Equal(testList, result);
        }

        public void Dispose()
        {
            Client.DeleteAll();
        }
    }
}
