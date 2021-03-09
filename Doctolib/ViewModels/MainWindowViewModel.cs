using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Hopital;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Doctolib.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel()
        {
            MedecinCommand = new RelayCommand(ActionMedecinCommand);
            PatientCommand = new RelayCommand(ActionPatientCommand);
            RDVCommand = new RelayCommand(ActionRDVCommand);
            AfficherCommand = new RelayCommand(ActionAfficherCommand);
        }

        public ICommand MedecinCommand { get; set; }
        public ICommand PatientCommand { get; set; }
        public ICommand RDVCommand { get; set; }
        public ICommand AfficherCommand { get; set; }

        public void ActionMedecinCommand()
        {
            Gestion_Medecin window = new Gestion_Medecin();
            window.Show();
        }

        public void ActionPatientCommand()
        {
            Gestion_Patients window = new Gestion_Patients();
            window.Show();
        }

        public void ActionRDVCommand()
        {
            Gestion_RDV window = new Gestion_RDV();
            window.Show();
        }

        public void ActionAfficherCommand()
        {
            Afficher_Tout window = new Afficher_Tout();
            window.Show();
        }
    }
}
