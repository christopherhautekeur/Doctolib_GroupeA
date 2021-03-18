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
    class Afficher_ToutViewModel : ViewModelBase
    {
        
        public bool radioBtnMedecins { get; set; }
        public bool radioBtnPatients { get; set; }
        public bool radioBtnRdvs { get; set; }
        public ObservableCollection<Medecin> ListeMedecins { get; set; }
        public ObservableCollection<Patient> ListePatients { get; set; }
        public ObservableCollection<RDV> ListeRdvs { get; set; }
        public Visibility ListeMedecinsVisibility { get { return radioBtnMedecins ? Visibility.Visible : Visibility.Collapsed; }}
        public Visibility ListePatientsVisibility { get { return radioBtnPatients ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility ListeRdvsVisibility { get { return radioBtnRdvs ? Visibility.Visible : Visibility.Collapsed; } }
        public ICommand RadioBtnCommand { get; set; }

        public Afficher_ToutViewModel() {
            ListeMedecins = new ObservableCollection<Medecin>(Medecin.GetListeMedecins());
            ListePatients = new ObservableCollection<Patient>(Patient.GetAll());
            ListeRdvs = new ObservableCollection<RDV>(RDV.GetAll());
            RadioBtnCommand = new RelayCommand(ActionRadioBtnChanged);
        }

        public void ActionRadioBtnChanged()
        {
            if(radioBtnMedecins)
                ListeMedecins = new ObservableCollection<Medecin>(Medecin.GetListeMedecins());
            else if(radioBtnPatients)
                ListePatients = new ObservableCollection<Patient>(Patient.GetAll());
            else
                ListeRdvs = new ObservableCollection<RDV>(RDV.GetAll());

            RaiseAllChanged();
        }

        private void RaiseAllChanged()
        {
            RaisePropertyChanged("ListeMedecinsVisibility");
            RaisePropertyChanged("ListePatientsVisibility");
            RaisePropertyChanged("ListeRdvsVisibility");
        }
    }
}
