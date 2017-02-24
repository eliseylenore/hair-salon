using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon.Objects
{
    public class Client
    {
        private int _id;
        private string _name;
        private int _stylistId;

        public Client(string Name, int StylistId, int Id = 0)
        {
            _id = Id;
            _name = Name;
            _stylistId = StylistId;
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
                bool stylistEquality = (this.GetStylistId() == newClient.GetStylistId());
                return (nameEquality && idEquality && stylistEquality);
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

        public int GetStylistId()
        {
            return _stylistId;
        }

        public void SetStylistId(int newStylistId)
        {
            _stylistId = newStylistId;
        }

        public void Save()
        {
          SqlConnection conn = DB.Connection();
          conn.Open();

          SqlCommand cmd = new SqlCommand("INSERT INTO clients (name, stylist_id) OUTPUT INSERTED.id VALUES (@ClientName, @ClientStylistId);", conn);

          SqlParameter nameParameter = new SqlParameter();
          nameParameter.ParameterName = "@ClientName";
          nameParameter.Value = this.GetName();

          SqlParameter stylistIdParameter = new SqlParameter();
          stylistIdParameter.ParameterName = "@ClientStylistId";
          stylistIdParameter.Value = this.GetStylistId();

          cmd.Parameters.Add(nameParameter);
          cmd.Parameters.Add(stylistIdParameter);

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
            List<Client> AllClients = new List<Client>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientName = rdr.GetString(1);
                int clientStylistId = rdr.GetInt32(2);
                Client newClient = new Client(clientName, clientStylistId, clientId);
                AllClients.Add(newClient);
            }

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }

            return AllClients;
        }

        public static Client Find(int id)
        {
          SqlConnection conn = DB.Connection();
          conn.Open();

          SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE id = @ClientId;", conn);
          SqlParameter clientIdParameter = new SqlParameter();
          clientIdParameter.ParameterName = "@ClientId";
          clientIdParameter.Value = id.ToString();
          cmd.Parameters.Add(clientIdParameter);
          SqlDataReader rdr = cmd.ExecuteReader();

          int foundClientId = 0;
          string foundClientDescription = null;
          int foundClientStylistId = 0;

          while(rdr.Read())
          {
            foundClientId = rdr.GetInt32(0);
            foundClientDescription = rdr.GetString(1);
            foundClientStylistId = rdr.GetInt32(2);
          }
          Client foundClient = new Client(foundClientDescription, foundClientStylistId, foundClientId);

          if (rdr != null)
          {
            rdr.Close();
          }
          if (conn != null)
          {
            conn.Close();
          }

          return foundClient;
        }

        public void UpdateName(string newName)
        {
          SqlConnection conn = DB.Connection();
          conn.Open();

          SqlCommand cmd = new SqlCommand("UPDATE clients SET name = @NewName OUTPUT INSERTED.name WHERE id = @ClientId;", conn);

          SqlParameter newNameParameter = new SqlParameter();
          newNameParameter.ParameterName = "@NewName";
          newNameParameter.Value = newName;

          SqlParameter stylistIdParameter = new SqlParameter();
          stylistIdParameter.ParameterName = "@ClientStylistId";
          stylistIdParameter.Value = this.GetStylistId();


          cmd.Parameters.Add(newNameParameter);
          cmd.Parameters.Add(stylistIdParameter);


          SqlParameter clientIdParameter = new SqlParameter();
          clientIdParameter.ParameterName = "@ClientId";
          clientIdParameter.Value = this.GetId();
          cmd.Parameters.Add(clientIdParameter);
          SqlDataReader rdr = cmd.ExecuteReader();

          while(rdr.Read())
          {
            this._name = rdr.GetString(0);
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

        public void Delete()
        {
          SqlConnection conn = DB.Connection();
          conn.Open();

          SqlCommand cmd = new SqlCommand("DELETE FROM clients WHERE id = @ClientId;", conn);

          SqlParameter clientIdParameter = new SqlParameter();
          clientIdParameter.ParameterName = "@ClientId";
          clientIdParameter.Value = this.GetId();

          cmd.Parameters.Add(clientIdParameter);
          cmd.ExecuteNonQuery();

          if (conn != null)
          {
            conn.Close();
          }
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
