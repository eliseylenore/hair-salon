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
            Client firstClient = new Client("Betsy Ross", 1);
            Client secondClient = new Client("Betsy Ross", 1);

            //Assert
            Assert.Equal(firstClient, secondClient);
        }

        [Fact]
        public void Test_Save_SavesToDatabase()
        {
            //Arrange
            Client testClient = new Client("Betsy Ross", 1);

            //Act
            testClient.Save();
            List<Client> result = Client.GetAll();
            List<Client> testList = new List<Client>{testClient};

            //Assert
            Assert.Equal(testList, result);
        }

        [Fact]
        public void Test_Save_AssignsIdToObject()
        {
          //Arrange
          Client testClient = new Client("Betsy Ross", 1);

          //Act
          testClient.Save();
          Client savedClient = Client.GetAll()[0];

          int result = savedClient.GetId();
          int testId = testClient.GetId();

          //Assert
          Assert.Equal(testId, result);
        }

        [Fact]
        public void Test_Find_FindsClientInDatabase()
        {
          //Arrange
          Client testClient = new Client("Betsy Ross", 1);
          testClient.Save();

          //Act
          Client foundClient = Client.Find(testClient.GetId());

          //Assert
          Console.WriteLine("test stylist: " + testClient.GetId() + "found stylist: " + foundClient.GetId());
          Assert.Equal(testClient, foundClient);
        }

        [Fact]
        public void Test_UpdateName_UpdatesClientInDatabase()
        {
          //Arrange
          string name = "Cherry St Hilaire";
          Client testClient = new Client(name, 1);
          testClient.Save();
          string newName = "Work stuff";

          //Act
          testClient.UpdateName(newName);

          string result = testClient.GetName();

          //Assert
          Assert.Equal(newName, result);
        }

        [Fact]
        public void Test_Delete_DeletesClientFromDatabase()
        {
          //Arrange


          Client testClient1 = new Client("Betsy Ross", 1);
          testClient1.Save();
          Client testClient2 = new Client("Cherie St Hilaire", 1);
          testClient2.Save();

          //Act
          testClient1.Delete();
          List<Client> resultClients = Client.GetAll();
          List<Client> testClientList = new List<Client> {testClient2};


          //Assert
          Assert.Equal(testClientList, resultClients);
        }



        public void Dispose()
        {
            Client.DeleteAll();
        }
    }
}
