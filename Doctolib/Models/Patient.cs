using Doctolib.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Doctolib.Models
{
    public class Patient : AbstractModelWithNotification
    {

        private int code;
        private string nom;
        private string adresse;
        private string telephone;
        private DateTime naissance;
        private string sexe;
        private static SqlCommand command;
        private static SqlDataReader reader;


        public int Code { get => code; set => code = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public DateTime Naissance { get => naissance; set => naissance = value; }
        public string Sexe { get => sexe; set => sexe = value; }

        public bool Save()
        {
            string request = "INSERT INTO patient (nom, adresse, telephone, naissance, sexe) OUTPUT INSERTED.id VALUES (@nom, @adresse, @telephone, @naissance, @sexe)";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@nom", Nom));
            command.Parameters.Add(new SqlParameter("@adresse", Adresse));
            command.Parameters.Add(new SqlParameter("@telephone", Telephone));
            command.Parameters.Add(new SqlParameter("@naissance", Naissance));
            command.Parameters.Add(new SqlParameter("@sexe", Sexe));
            DataBase.Connection.Open();
            Code = (int)command.ExecuteScalar();
            command.Dispose();
            DataBase.Connection.Close();
            return Code > 0;
        }

        public bool Delete()
        {
            string request = "DELETE FROM patient WHERE code = @code";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@code", Code));
            DataBase.Connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            DataBase.Connection.Close();
            return nbRow == 1;
        }

        public bool Update()
        {
            string request = "UPDATE patient SET nom = @nom, adresse = @adresse, telephone = @telephone, naissance = @naissance, sexe = @sexe WHERE code = @code";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@nom", Nom));
            command.Parameters.Add(new SqlParameter("@adresse", Adresse));
            command.Parameters.Add(new SqlParameter("@telephone", Telephone));
            command.Parameters.Add(new SqlParameter("@naissance", Naissance));
            command.Parameters.Add(new SqlParameter("@sexe", Sexe));
            DataBase.Connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            DataBase.Connection.Close();
            return nbRow == 1;
        }

        public static Patient GetByCode(int code)
        {
            // Retourne un patient à partir d'un code d'identification
            Patient patient = null;
            string request = "SELECT code, nom, adresse, telephone, naissance, sexe FROM patient INNER JOIN RDV ON code = codePatient WHERE code = @code";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@code", code));
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                patient = new Patient()
                {
                    Code = reader.GetInt32(0),
                    Nom = reader.GetString(1),
                    Adresse = reader.GetString(2),
                    Telephone = reader.GetString(3),
                    Naissance = reader.GetDateTime(4),
                    Sexe = reader.GetString(5)
                };
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return patient;
        }

        public static List<Patient> GetAll()
        {
            // Retourne l'ensemble des contacts de la base de données "patient" sous forme de liste
            List<Patient> patients = new List<Patient>();
            string request = "SELECT code, nom, adresse, telephone, naissance, sexe FROM patient";
            command = new SqlCommand(request, DataBase.Connection);
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            Patient patient = null;
            while (reader.Read())
            {
                if (patient == null || patient.Code != reader.GetInt32(0))
                {
                    patient = new Patient()
                    {
                        Code = reader.GetInt32(0),
                        Nom = reader.GetString(1),
                        Adresse = reader.GetString(2),
                        Telephone = reader.GetString(3),
                        Naissance = reader.GetDateTime(4),
                        Sexe = reader.GetString(5)
                    };
                    patients.Add(patient);
                }
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return patients;
        }

        public override string ToString()
        {
            string retour = $"Patient : Code: { Code}, Nom: { Nom}, Adresse: { Adresse}, Téléphone: { Telephone}, Date de naissance: { Naissance}, Sexe: { Sexe}\n";
            return retour;
        }
    }
}
