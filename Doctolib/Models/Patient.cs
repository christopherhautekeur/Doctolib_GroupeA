using System;
using System.Collections.Generic;
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

        public int Code { get => code; set => code = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public DateTime Naissance { get => naissance; set => naissance = value; }
        public string Sexe { get => sexe; set => sexe = value; }

    }
}
