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

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client) otherClient;
                bool idEquality = (this.GetId() == newClient.GetId());
                bool nameEquality = (this.GetName() == newClient.GetName());
                return (nameEquality && idEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }
        public int GetId()
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

        public void Save()
        {
          SqlConnection conn = DB.Connection();
          conn.Open();

          SqlCommand cmd = new SqlCommand("INSERT INTO clients (name) OUTPUT INSERTED.id VALUES (@ClientName);", conn);

          SqlParameter nameParameter = new SqlParameter();
          nameParameter.ParameterName = "@ClientName";
          nameParameter.Value = this.GetName();
          cmd.Parameters.Add(nameParameter);
          SqlDataReader rdr = cmd.ExecuteReader();

          while(rdr.Read())
          {
            this._id = rdr.GetInt32(0);
          }
          if (rdr != null)
          {
            rdr.Close();
          }
          if (conn != null)
          {
            conn.Close();
          }
        }

        public static List<Client> GetAll()
        {
            List<Client> allClients = new List<Client>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientName = rdr.GetString(1);
                Client newClient = new Client(clientName, clientId);
                allClients.Add(newClient);
            }

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }

            return allClients;
        }

        public static Client Find(int id)
        {
        //   SqlConnection conn = DB.Connection();
        //   conn.Open();
          //
        //   SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE id = @ClientId;", conn);
        //   SqlParameter clientIdParameter = new SqlParameter();
        //   clientIdParameter.ParameterName = "@ClientId";
        //   clientIdParameter.Value = id.ToString();
        //   cmd.Parameters.Add(clientIdParameter);
        //   SqlDataReader rdr = cmd.ExecuteReader();
          //
        //   int foundClientId = 0;
        //   string foundClientDescription = null;
        //   while(rdr.Read())
        //   {
        //     foundClientId = rdr.GetInt32(0);
        //     foundClientDescription = rdr.GetString(1);
        //   }
        //   Client foundClient = new Client(foundClientDescription, foundClientId);
          //
        //   if (rdr != null)
        //   {
        //     rdr.Close();
        //   }
        //   if (conn != null)
        //   {
        //     conn.Close();
        //   }
        
          return new Client("blah");
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
