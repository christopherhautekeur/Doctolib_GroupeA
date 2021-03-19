using Doctolib.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Doctolib.Models
{
    public class Medecin : AbstractModelWithNotification
    {

        private int code;
        private string nom;
        private string telephone;
        private DateTime embauche;
        private int idSpecialite;

        private static string request;
        private static SqlCommand command;
        private static SqlDataReader reader;


        public int Code { get => code; set => code = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public DateTime Embauche { get => embauche; set => embauche = value; }
        public int IdSpecialite { get => idSpecialite; set => idSpecialite = value; }

        public Medecin()
        {
            embauche = DateTime.Now;
        }


        #region BDD
        public bool Save()
        {
            request = "INSERT INTO Medecin (NomMedecin, TelMedecin, DateEmbauche, IdSpecialiteMedecin) OUTPUT INSERTED.CodeMedecin VALUES " +
                "(@nom, @tel, @embauche, @spe)";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@nom", System.Data.SqlDbType.VarChar) { Value = Nom });
            command.Parameters.Add(new SqlParameter("@tel", System.Data.SqlDbType.VarChar) { Value = Telephone });
            command.Parameters.Add(new SqlParameter("@embauche", System.Data.SqlDbType.Date) { Value = Embauche });
            command.Parameters.Add(new SqlParameter("@spe", System.Data.SqlDbType.Int) { Value = IdSpecialite });

            DataBase.Connection.Open();
            Code = (int)command.ExecuteScalar();

            command.Dispose();
            DataBase.Connection.Close();

            return Code > 0;
        }
        public bool Update()
        {
            request = "UPDATE Medecin SET NomMedecin = @nom, TelMedecin = @tel, DateEmbauche = @embauche, IdSpecialiteMedecin = @spe WHERE CodeMedecin = @code";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@nom", System.Data.SqlDbType.VarChar) { Value = Nom });
            command.Parameters.Add(new SqlParameter("@tel", System.Data.SqlDbType.VarChar) { Value = Telephone });
            command.Parameters.Add(new SqlParameter("@embauche", System.Data.SqlDbType.Date) { Value = Embauche });
            command.Parameters.Add(new SqlParameter("@spe", System.Data.SqlDbType.Int) { Value = IdSpecialite });
            command.Parameters.Add(new SqlParameter("@code", System.Data.SqlDbType.Int) { Value = Code });

            DataBase.Connection.Open();
            int row = command.ExecuteNonQuery();

            command.Dispose();
            DataBase.Connection.Close();

            return row > 0;
        }
        public bool Delete()
        {
            request = "DELETE FROM Medecin WHERE CodeMedecin = @code";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@code", System.Data.SqlDbType.Int) { Value = Code });

            DataBase.Connection.Open();
            int row = command.ExecuteNonQuery();

            command.Dispose();
            DataBase.Connection.Close();

            return row > 0;
        }
        public static List<Medecin> GetListeMedecins()
        {
            List<Medecin> medecins = new List<Medecin>();

            // LEFT JOIN pour recuperer la liste des rdv en meme temps que le medecin (moins de requete)
            request = "SELECT CodeMedecin, NomMedecin, TelMedecin, DateEmbauche, IdSpecialiteMedecin "+
                "FROM Medecin";
            command = new SqlCommand(request, DataBase.Connection);

            DataBase.Connection.Open();
            reader = command.ExecuteReader();

            Medecin medecin = new Medecin();

            while (reader.Read())
            {
                medecin = new Medecin();
                medecin.Code = reader.GetInt32(0);
                medecin.Nom = reader.GetString(1);
                medecin.Telephone = reader.GetString(2);
                medecin.Embauche = reader.GetDateTime(3);
                medecin.IdSpecialite = reader.GetInt32(4);

                medecins.Add(medecin);
            }
            

            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();

            return medecins;
        }
        public static List<Medecin> GetListeMedecinsBySpecialite(int specialite)
        {
            List<Medecin> medecins = new List<Medecin>();

            request = "SELECT CodeMedecin, NomMedecin, TelMedecin, DateEmbauche, IdSpecialiteMedecin "  
                + "FROM Medecin "
                + "WHERE ISpecialiteMedecin like @spe";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@spe", System.Data.SqlDbType.Int) { Value = specialite });

            DataBase.Connection.Open();
            reader = command.ExecuteReader();

            Medecin medecin = new Medecin();

            while (reader.Read())
            {
                medecin = new Medecin();
                medecin.Code = reader.GetInt32(0);
                medecin.Nom = reader.GetString(1);
                medecin.Telephone = reader.GetString(2);
                medecin.Embauche = reader.GetDateTime(3);
                medecin.IdSpecialite = reader.GetInt32(4);

                medecins.Add(medecin);
            }

            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();

            return medecins;
        }
        public static Medecin GetMedecinByCode(int code)
        {
            Medecin medecin = null;

            request = "SELECT CodeMedecin, NomMedecin, TelMedecin, DateEmbauche, IdSpecialiteMedecin "
                + "WHERE CodeMedecin = @code";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@code", System.Data.SqlDbType.Int) { Value = code });

            DataBase.Connection.Open();
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                medecin = new Medecin();
                medecin.Code = reader.GetInt32(0);
                medecin.Nom = reader.GetString(1);
                medecin.Telephone = reader.GetString(2);
                medecin.Embauche = reader.GetDateTime(3);
                medecin.IdSpecialite = reader.GetInt32(4);
            }

            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();

            return medecin;
        }
        #endregion
    }
}
