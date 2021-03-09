using Doctolib.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Doctolib.Models
{
    public class RDV : AbstractModelWithNotification
    {

        private int numero;
        private DateTime date;
        private string heure;
        private int codeMedecin;
        private int codePatient;
        private string nomMedecin;
        private string nomPatient;
        private static SqlCommand command;
        private static SqlDataReader reader;

        public int Numero { get => numero; set => numero = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Heure { get => heure; set => heure = value; }
        public int CodeMedecin { get => codeMedecin; set => codeMedecin = value; }
        public int CodePatient { get => codePatient; set => codePatient = value; }
        public string NomMedecin { get => nomMedecin; set => nomMedecin = value; }
        public string NomPatient { get => nomPatient; set => nomPatient = value; }

        public bool Save()
        {
            string request = "INSERT INTO RDV (DateRDv, HeureRDV, codeMedecin, codePatient) OUTPUT INSERTED.NumeroRDV VALUES (@date, @heure, @codeMedecin, @codePatient)";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@date", Date));
            command.Parameters.Add(new SqlParameter("@heure", Heure));
            command.Parameters.Add(new SqlParameter("@codeMedecin", CodeMedecin));
            command.Parameters.Add(new SqlParameter("@codePatient", CodePatient));
            DataBase.Connection.Open();
            Numero = (int)command.ExecuteScalar();
            command.Dispose();
            DataBase.Connection.Close();
            return Numero > 0;
        }

        public bool Delete()
        {
            string request = "DELETE FROM RDV WHERE NumeroRDV = @numero";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@numero", Numero));
            DataBase.Connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            DataBase.Connection.Close();
            return nbRow == 1;
        }

        public bool Update()
        {
            string request = "UPDATE patient SET DateRDV = @date, HeureRDV = @heure, codeMedecin = @codeMedecin, codePatient = @codePatient WHERE NumeroRDV = @numero";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@date", Date));
            command.Parameters.Add(new SqlParameter("@heure", Heure));
            command.Parameters.Add(new SqlParameter("@codeMedecin", CodeMedecin));
            command.Parameters.Add(new SqlParameter("@codePatient", CodePatient));
            command.Parameters.Add(new SqlParameter("@numero", Numero));
            DataBase.Connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            DataBase.Connection.Close();
            return nbRow == 1;
        }

        public static List<RDV> GetByDate(DateTime date)
        {

            List<RDV> listeRDV = new List<RDV>();
            string request = "SELECT NumeroRDV, DateRDV, HeureRDV, codeMedecin, codePatient, m.NomMedecin, p.NomPatient FROM RDV INNER JOIN Medecin AS m ON codeMedecin = m.CodeMedecin INNER JOIN Patient AS p ON codePatient = p.CodePatient WHERE DateRDV = @date ORDER BY NumeroRDV ASC";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@date", date));
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            RDV rdv = null;
            while (reader.Read())
            {
                if (rdv == null || rdv.Numero != reader.GetInt32(0))
                {
                    rdv = new RDV()
                    {
                        Numero = reader.GetInt32(0),
                        Date = reader.GetDateTime(1),
                        Heure = reader.GetString(2),
                        CodeMedecin = reader.GetInt32(3),
                        CodePatient = reader.GetInt32(4),
                        NomMedecin = reader.GetString(5),
                        NomPatient = reader.GetString(6)
                    };
                    listeRDV.Add(rdv);
                }
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return listeRDV;
        }

        public static List<RDV> GetByCodePatient(int codePatient)
        {
            List<RDV> listeRDV = new List<RDV>();
            string request = "SELECT NumeroRDV, DateRDV, HeureRDV, codeMedecin, codePatient, m.NomMedecin, p.NomPatient FROM RDV INNER JOIN Medecin AS m ON codeMedecin = m.CodeMedecin INNER JOIN Patient AS p ON codePatient = p.CodePatient WHERE NumeroRDV = @codePatient ORDER BY NumeroRDV ASC";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@codePatient", codePatient));
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            RDV rdv = null;
            while (reader.Read())
            {
                if (rdv == null || rdv.Numero != reader.GetInt32(0))
                {
                    rdv = new RDV()
                    {
                        Numero = reader.GetInt32(0),
                        Date = reader.GetDateTime(1),
                        Heure = reader.GetString(2),
                        CodeMedecin = reader.GetInt32(3),
                        CodePatient = reader.GetInt32(4),
                        NomMedecin = reader.GetString(5),
                        NomPatient = reader.GetString(6)
                    };
                    listeRDV.Add(rdv);
                }
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return listeRDV;
        }

        public static List<RDV> GetAll()
        {
            List<RDV> listeRDV = new List<RDV>();
            string request = "SELECT r.NumeroRDV, r.DateRDV, r.HeureRDV, r.codeMedecin, r.codePatient, m.NomMedecin, p.NomPatient FROM RDV r INNER JOIN Medecin AS m ON r.codeMedecin = m.CodeMedecin INNER JOIN Patient AS p ON r.codePatient = p.CodePatient ORDER BY r.numeroRDV ASC";
            command = new SqlCommand(request, DataBase.Connection);
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            RDV rdv = null;
            while (reader.Read())
            {
                if (rdv == null || rdv.Numero != reader.GetInt32(0))
                {
                    rdv = new RDV()
                    {
                        Numero = reader.GetInt32(0),
                        Date = reader.GetDateTime(1),
                        Heure = reader.GetString(2),
                        CodeMedecin = reader.GetInt32(3),
                        CodePatient = reader.GetInt32(4),
                        NomMedecin = reader.GetString(5),
                        NomPatient = reader.GetString(6)
                    };
                    listeRDV.Add(rdv);
                }
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return listeRDV;
        }

        public override string ToString()
        {
            string retour = $"RDV : Numéro: { Numero}, Date: { Date}, Horaire: { Heure}, Médecin: { NomMedecin} (code {CodeMedecin}), Patient: { NomPatient} (code {CodePatient})\n";
            return retour;
        }
    }
}
