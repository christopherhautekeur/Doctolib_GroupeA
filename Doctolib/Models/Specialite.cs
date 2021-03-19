using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Doctolib.Data;

namespace Doctolib.Models
{
    class Specialite
    {
        private int id;
        private string nom;

        private static string request;
        private static SqlCommand command;
        private static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }

        #region BDD
        public bool Save()
        {
            request = "INSERT INTO Specialite (NomSpecialite) OUTPUT INSERTED.CodeMedecin VALUES (@nomSpecialite)";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@nomSpecialite", System.Data.SqlDbType.VarChar) { Value = Nom });

            DataBase.Connection.Open();
            Id = (int)command.ExecuteScalar();

            command.Dispose();
            DataBase.Connection.Close();

            return Id > 0;
        }
        public bool Update()
        {
            request = "UPDATE Specialite SET NomSpecialite = @nom WHERE IdSpecialite = @id";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@nom", System.Data.SqlDbType.VarChar) { Value = Nom });
            command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int) { Value = Id });

            DataBase.Connection.Open();
            int row = command.ExecuteNonQuery();

            command.Dispose();
            DataBase.Connection.Close();

            return row > 0;
        }
        public bool Delete()
        {
            request = "DELETE FROM Specialite WHERE IdSpecialite = @id";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int) { Value = Id });

            DataBase.Connection.Open();
            int row = command.ExecuteNonQuery();

            command.Dispose();
            DataBase.Connection.Close();

            return row > 0;
        }
        public static List<Specialite> GetListeSpecialites()
        {
            List<Specialite> specialites = new List<Specialite>();

            request = "SELECT IdSpecialite, NomSpecialite FROM Specialite";
            command = new SqlCommand(request, DataBase.Connection);

            DataBase.Connection.Open();
            reader = command.ExecuteReader();

            Specialite specialite;

            while (reader.Read())
            {
                specialite = new Specialite();
                specialite.Id = reader.GetInt32(0);
                specialite.Nom = reader.GetString(1);
                specialites.Add(specialite);
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();

            return specialites;
        }
        
        public static Specialite GetSpecialiteById(int id)
        {
            Specialite specialite = null;

            request = "SELECT IdSpecialite, NomSpecialite WHERE IdSpecialite = @id";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int) { Value = id });

            DataBase.Connection.Open();
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                specialite = new Specialite();
                specialite.Id = reader.GetInt32(0);
                specialite.Nom = reader.GetString(1);
            }

            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();

            return specialite;
        }
        #endregion
    }
}
