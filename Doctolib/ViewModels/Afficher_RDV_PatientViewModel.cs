using Doctolib.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Doctolib.ViewModels
{
    class Afficher_RDV_PatientViewModel : ViewModelBase
    {
        private Patient patient;
        private Medecin medecin;
        private ObservableCollection<Patient> patients;
        private ObservableCollection<Medecin> medecins;
        private ObservableCollection<RDV> rdvs;
        private RDV rdv;
        

        public Afficher_RDV_PatientViewModel()
        {
            Patients = new ObservableCollection<Patient>(Patient.GetAll());
            Medecins = new ObservableCollection<Medecin>(Medecin.GetListeMedecins());
            Rdvs = new ObservableCollection<RDV>();

            ModifCommand = new RelayCommand(ActionClickModifButton);
        }

        public Patient Patient { get => patient; set { patient = value; PatientChanged(); RaiseAllChanged(); } }
        public Medecin Medecin { get => medecin; set => medecin = value; }
        public RDV Rdv { get => rdv; set { rdv = value; RdvChanged(); RaiseAllChanged(); } }
        public ObservableCollection<Patient> Patients { get => patients; set => patients = value; }
        public ObservableCollection<Medecin> Medecins { get => medecins; set => medecins = value; }
        public ObservableCollection<RDV> Rdvs { get => rdvs; set => rdvs = value; }

        public string Nom { get => Patient != null ? Patient.Nom : ""; set => Patient.Nom = value; }
        public string Adresse { get => Patient != null ? Patient.Adresse : ""; set => Patient.Adresse = value; }
        public DateTime Naissance { get => Patient != null ? Patient.Naissance : DateTime.MinValue; set => Patient.Naissance = value; }
        public bool SexeM { get => Patient != null ? Patient.Sexe == "M" : false; set => Patient.Sexe = value == true ? "M" : "F"; }
        public bool SexeF { get => Patient != null ? Patient.Sexe == "F" : false; set => Patient.Sexe = value == true ? "F" : "M"; }
        public int NumeroRdv { get => Rdv != null ? Rdv.Numero : 0; set => Rdv.Numero = value; }
        public string HeureRdv { get => Rdv != null ? Rdv.Heure : ""; set => Rdv.Heure = value; }
        public DateTime DateRdv { get => Rdv != null ? Rdv.Date : DateTime.MinValue; set => Rdv.Date = value; }

        public ICommand ModifCommand { get; set; } 

        private void PatientChanged()
        {
            Rdvs = new ObservableCollection<RDV>(RDV.GetByCodePatient(Patient.Code));
        }

        private void RdvChanged()
        {
            if(Rdv != null)
            {
                foreach (Medecin m in Medecins)
                {
                    if (m.Code == Rdv.CodeMedecin)
                    {
                        medecin = m;
                        break;
                    }
                }
                RaiseAllChanged();
            }
        }

        public void ActionClickModifButton()
        {
            if(Rdv != null)
            {
                if (Rdv.Date < DateTime.Now)
                    MessageBox.Show($"Impossible de prendre un rendez vous avant le {DateTime.Now}");
                else if (medecin == null)
                    MessageBox.Show("Veuillez selectionner un medecin");
                else
                {
                    Rdv.CodeMedecin = medecin.Code;
                    Rdv.Update();
                    Rdv = null;
                    Rdvs = new ObservableCollection<RDV>(RDV.GetByCodePatient(Patient.Code));
                    RaiseAllChanged();
                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un rendez vous");
            }
        }

        private void RaiseAllChanged()
        {
            RaisePropertyChanged("Patient");
            RaisePropertyChanged("Nom");
            RaisePropertyChanged("Adresse");
            RaisePropertyChanged("Naissance");
            RaisePropertyChanged("SexeM");
            RaisePropertyChanged("SexeF");
            RaisePropertyChanged("Rdvs");
            RaisePropertyChanged("Medecin");
            RaisePropertyChanged("NumeroRdv");
            RaisePropertyChanged("DateRdv");
            RaisePropertyChanged("HeureRdv");
            RaisePropertyChanged("Rdv");
        }
    }
}
