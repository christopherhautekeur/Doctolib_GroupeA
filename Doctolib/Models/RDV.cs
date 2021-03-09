using System;
using System.Collections.Generic;
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

        public int Numero { get => numero; set => numero = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Heure { get => heure; set => heure = value; }
        public int CodeMedecin { get => codeMedecin; set => codeMedecin = value; }
        public int CodePatient { get => codePatient; set => codePatient = value; }

        

        public static List<RDV> GetRdvsByDate(DateTime date)
        {
            return null;
        }

        public static List<RDV> GetRdvsByCodePatient(int codePatient)
        {
            return null;
        }

        public static List<RDV> GetRdvs()
        {
            return null;
        }
    }
}
