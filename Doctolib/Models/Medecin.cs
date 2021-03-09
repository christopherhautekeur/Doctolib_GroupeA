using System;
using System.Collections.Generic;
using System.Text;

namespace Doctolib.Models
{
    public class Medecin : AbstractModelWithNotification
    {

        private int code;
        private string nom;
        private string telephone;
        private DateTime embauche;
        private string specialite;

        public int Code { get => code; set => code = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public DateTime Embauche { get => embauche; set => embauche = value; }
        public string Specialite { get => specialite; set => specialite = value; }
    }
}
