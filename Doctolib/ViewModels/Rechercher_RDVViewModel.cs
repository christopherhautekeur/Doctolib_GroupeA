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
    class Rechercher_RDVViewModel : ViewModelBase
    {
        private ObservableCollection<RDV> rdvs;
        private RDV rdv;
        private DateTime date;
        private Medecin medecin;
        private Patient patient;

        public Rechercher_RDVViewModel()
        {
            Date = DateTime.Now;
            rdvs = new ObservableCollection<RDV>();
            SearchCommand = new RelayCommand(ActionClickSearchButton);
        }

        public ObservableCollection<RDV> Rdvs { get => rdvs; set => rdvs = value; }
        public RDV Rdv { get => rdv; set { rdv = value; if (rdv != null) { GetInfosPatient(); GetInfosMedecin(); RaiseAllChanged(); } } }
        public DateTime Date { get => date; set => date = value; }
        
        public string NomPatient { get => patient != null ? patient.Nom : ""; set => patient.Nom = value; }
        public string NaissancePatient { get => patient != null ? patient.Naissance.ToString("dd/MM/yyyy") : ""; set => patient.Nom = value; }

        public bool SexeM { get => patient != null && patient.Sexe == "M"; set => patient.Sexe = value == true ? "M" : "F"; }
        public bool SexeF { get => patient != null && patient.Sexe == "F"; set => patient.Sexe = value == true ? "F" : "M"; }

        public string NomMedecin { get => medecin != null ? medecin.Nom : ""; set => medecin.Nom = value; }


        public ICommand SearchCommand { get; set; }

        public void ActionClickSearchButton()
        {
            if(date != default(DateTime))
            {
                rdvs = new ObservableCollection<RDV>(RDV.GetByDate(date));
                RaisePropertyChanged("Rdvs");
            }
            else
            {
                MessageBox.Show("Veuillez selectionner une date");
            }
        }

        public void GetInfosPatient()
        {
            patient = Patient.GetByCode(Rdv.CodePatient);
        }

        public void GetInfosMedecin()
        {
            medecin = Medecin.GetMedecinByCode(Rdv.CodeMedecin);
        }

        public void RaiseAllChanged()
        {
            RaisePropertyChanged("NomPatient");
            RaisePropertyChanged("NaissancePatient");
            RaisePropertyChanged("SexeM");
            RaisePropertyChanged("SexeF");
            RaisePropertyChanged("NomMedecin");
            RaisePropertyChanged("SpeMedecin");
        }
    }
}
