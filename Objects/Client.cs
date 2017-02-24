using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon.Objects
{
    public class Client
    {
        private int _id;
        private string _name;

        public Client(string Name, int Id = 0)
        {
            _id = Id;
            _name = Name;
        }

        public int GetID()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string newName)
        {
            _name = newName;
        }
        public static List<Client> GetAll()
        {
            List<Client> allClients = new List<Client>{};

            // SqlConnection conn = DB.Connection();
            // conn.Open();
            //
            // SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
            // SqlDataReader rdr = cmd.ExecuteReader();
            //
            // while(rdr.Read())
            // {
            //     int clientId = rdr.GetInt32(0);
            //     string clientName = rdr.GetString(1);
            //     Client newClient = new Client(clientName, clientId);
            //     allClients.Add(newClient);
            // }
            //
            // if (rdr != null)
            // {
            //     rdr.Close();
            // }
            // if (conn != null)
            // {
            //     conn.Close();
            // }

            return allClients;
        }
        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
