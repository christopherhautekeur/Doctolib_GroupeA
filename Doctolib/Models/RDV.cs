using System;
using System.Collections.Generic;
using System.Text;

namespace Doctolib.Models
{
    class RDV : AbstractModelWithNotification
    {

        private int numero;
        private DateTime date;
        private string heure;
        private Medecin medecin;
        private Patient patient;

        public int Numero { get => numero; set => numero = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Heure { get => heure; set => heure = value; }
        public Medecin Medecin { get => medecin; set => medecin = value; }
        public Patient Patient { get => patient; set => patient = value; }
    }
}
