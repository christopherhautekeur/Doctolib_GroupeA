using Doctolib.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Hopital;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Doctolib.ViewModels
{
    class Gestion_RDVViewModel : ViewModelBase
    {

        private Patient patient;
        private Medecin medecin;
        private RDV rdv;
        private ObservableCollection<Patient> patients;
        private ObservableCollection<Medecin> medecins;

        public Gestion_RDVViewModel()
        {
            Patients = new ObservableCollection<Patient>(Patient.GetAll());
            Medecins = new ObservableCollection<Medecin>(Medecin.GetListeMedecins());
            rdv = new RDV() { Date = DateTime.Now };
            AjoutCommand = new RelayCommand(ActionClickAjoutButton);
        }

        public Patient Patient { get => patient; set { patient = value; RaiseAllChanged(); } }
        public Medecin Medecin { get => medecin; set { medecin = value; RaiseAllChanged(); } }
        public ObservableCollection<Patient> Patients { get => patients; set => patients = value; }
        public ObservableCollection<Medecin> Medecins { get => medecins; set => medecins = value; }

        public string NomPatient { get => Patient != null ? Patient.Nom : ""; set => Patient.Nom = value; }
        public string NomMedecin { get => Medecin != null ? Medecin.Nom : ""; set => Medecin.Nom = value; }
        public string SpeMedecin { get => Medecin != null ? Medecin.Specialite : ""; set => Medecin.Specialite = value; }
        public bool SexeM { get => Patient != null ? Patient.Sexe == "M" : false; set { patient.Sexe = value == true ? "M" : "F"; } }
        public bool SexeF { get => Patient != null ? Patient.Sexe == "F" : false; set { patient.Sexe = value == true ? "F" : "M"; } }

        public DateTime Date { get => rdv.Date; set => rdv.Date = value; }
        public string Heure { get => rdv.Heure; set => rdv.Heure = value; }

        public ICommand AjoutCommand { get; set; }

        public void ActionClickAjoutButton()
        {
            if (patient == null)
                MessageBox.Show("Veuillez selectionner un patient");
            else if (medecin == null)
                MessageBox.Show("Veuillez selectionner un medecin");
            else if (Date < DateTime.Now)
                MessageBox.Show("Impossible de prendre rendez-vous a la date indiqué");
            else if (Heure == null || Heure == "")
                MessageBox.Show("Veuillez indiquer une heure pour le rendez vous");
            else
            {
                rdv.CodeMedecin = medecin.Code;
                rdv.CodePatient = patient.Code;
                rdv.Save();
                rdv = new RDV() { Date = DateTime.Now };
                RaiseAllChanged();
                MessageBox.Show("Le rendez vous a bien été enregistré");
            }
        }

        private void RaiseAllChanged()
        {
            RaisePropertyChanged("Patient");
            RaisePropertyChanged("Medecin");
            RaisePropertyChanged("NomPatient");
            RaisePropertyChanged("NomMedecin");
            RaisePropertyChanged("SpeMedecin");
            RaisePropertyChanged("SexeM");
            RaisePropertyChanged("SexeF");
            RaisePropertyChanged("Date");
            RaisePropertyChanged("Heure");
        }
    }
}
