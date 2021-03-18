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
    class Gestion_PatientsViewModel : ViewModelBase
    {
        private Patient patient;

        public Gestion_PatientsViewModel()
        {
            Patients = new ObservableCollection<Patient>(Patient.GetAll());
            patient = new Patient() { Naissance = DateTime.Now };
            Patients.Add(patient);
            NewCommand = new RelayCommand(ActionClickNewButton);
            AjoutCommand = new RelayCommand(ActionClickAjoutButton);
            ModifCommand = new RelayCommand(ActionClickModifButton);
            DeleteCommand = new RelayCommand(ActionClickDeleteButton);
        }

        public ObservableCollection<Patient> Patients { get; set; }
        public Patient Patient { get => patient; set { patient = value; RaiseAllChanged(); } }

        public string Nom { get => patient.Nom; set => patient.Nom = value; }
        public string Adresse { get => patient.Adresse; set => patient.Adresse = value; }
        public string Telephone { get => patient.Telephone; set => patient.Telephone = value; }
        public DateTime Naissance { get => patient.Naissance; set => patient.Naissance = value; }
        public bool btnSexeM { get => patient.Sexe == "M"; set { patient.Sexe = value == true ? "M" : "F"; } }
        public bool btnSexeF { get => patient.Sexe == "F"; set { patient.Sexe = value == true ? "F" : "M"; } }


        public ICommand NewCommand { get; set; }
        public ICommand AjoutCommand { get; set; }
        public ICommand ModifCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        public void ActionClickNewButton()
        {
            bool trouver = false;

            foreach (Patient p in Patients)
            {
                if (p.Code == 0)
                {
                    Patient = p;
                    trouver = true;
                    break;
                }
            }

            if (!trouver)
            {
                Patient = new Patient() { Naissance = DateTime.Now };
                Patients.Add(patient);
            }
            RaiseAllChanged();
        }

        public void ActionClickAjoutButton()
        {
            if (Nom != null && Nom != "" && Adresse != null && Adresse != "" && Naissance != null && patient.Sexe != null && Telephone != null && Telephone != "")
            {
                patient.Save();
                RaiseAllChanged();
                MessageBox.Show($"Creation du patient n°{patient.Code}");
            }
            else
                MessageBox.Show("Ajout impossible :\nVeuillez remplir tout les champs avant de valider");

        }

        public void ActionClickModifButton()
        {
            if (Patient.Code != 0 && Nom != null && Nom != "" && Adresse != null && Adresse != "" && Naissance != null && patient.Sexe != null && Telephone != null && Telephone != "")
            {
                patient.Update();
                RaiseAllChanged();
                MessageBox.Show($"Mise a jour du patient n°{Patient.Code}");
            }
            else
                MessageBox.Show("Mise à jour impossilbe :\nVeuillez remplir tout les champs avant de valider");
            RaiseAllChanged();

        }

        public void ActionClickDeleteButton()
        {
            if(patient.Code != 0)
            {
                MessageBoxResult result = MessageBox.Show($"Voulez vous vraiment supprimer le patient n°{patient.Code}", "test", MessageBoxButton.YesNo);
                if(result == MessageBoxResult.Yes)
                {
                    Patient tmp = patient;
                    ActionClickNewButton();
                    Patients.Remove(tmp);
                    patient.Delete();
                    RaiseAllChanged();
                    MessageBox.Show($"Le patient n°{tmp.Code} supprimé");
                }
                else
                {
                    MessageBox.Show($"Le patient n°{patient.Code} n'a pas été supprimé");
                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un patient");
            }
            

        }

        public void RaiseAllChanged()
        {
            RaisePropertyChanged("Patient");
            RaisePropertyChanged("Patients");
            RaisePropertyChanged("Nom");
            RaisePropertyChanged("Adresse");
            RaisePropertyChanged("Telephone");
            RaisePropertyChanged("Naissance");
            RaisePropertyChanged("btnSexeM");
            RaisePropertyChanged("btnSexeF");
        }

    }
}
