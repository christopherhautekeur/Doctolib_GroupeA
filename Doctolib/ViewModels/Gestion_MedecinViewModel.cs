using Doctolib.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Hopital;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
namespace Doctolib.ViewModels
{
    class Gestion_MedecinViewModel : ViewModelBase
    {
        private Medecin medecin;
        private Medecin medTmp;
        private Specialite specialite;
        private Gestion_Medecin _medecinWindow;

        public Medecin Medecin { get => medecin; set { if (value != null) { medecin = value; RaiseMedecinChanged(); } } }
        public Medecin MedTmp { get => medTmp; set => medTmp = value; }
        public int Code { get => Medecin.Code; set { Medecin.Code = value; RaisePropertyChanged(); } }
        public string Nom { get => Medecin.Nom; set { Medecin.Nom = value; RaisePropertyChanged(); } }
        public string Telephone { get => Medecin.Telephone; set { Medecin.Telephone = value; RaisePropertyChanged(); } }
        public DateTime Embauche { get => Medecin.Embauche; set { Medecin.Embauche = value; RaisePropertyChanged(); } }
        public int IdSpecialite { get => Medecin.IdSpecialite; set { Medecin.IdSpecialite = value; RaisePropertyChanged(); } }

        public Specialite Specialite { get => Specialites.FirstOrDefault(x => x.Id == Medecin.IdSpecialite); set { if (value != null) { RaiseSpecialiteChanged(); Medecin.IdSpecialite = value.Id; } } }
        public int Id { get => Specialite.Id; set { Specialite.Id = value; RaisePropertyChanged(); } }
        public string NomSpe { get => Specialite.Nom; set { Specialite.Nom = value; RaisePropertyChanged(); } }

        public ObservableCollection<Specialite> Specialites { get; set; }
        public ObservableCollection<Medecin> Medecins { get; set; }

        public ICommand SelectionChangedCommand { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand ModCommand { get; set; }
        public ICommand DelCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        

        public Gestion_MedecinViewModel(Gestion_Medecin medecinWindow)
        {
            Medecin = new Medecin();
            MedTmp = new Medecin();
            NewCommand = new RelayCommand(ActionNewCommand);
            AddCommand = new RelayCommand(ActionAddCommand);
            ModCommand = new RelayCommand(ActionModCommand);
            DelCommand = new RelayCommand(ActionDelCommand);
            ExitCommand = new RelayCommand(ActionExitCommand);
            Specialites = new ObservableCollection<Specialite>(Specialite.GetListeSpecialites());
            Medecins = new ObservableCollection<Medecin>(Medecin.GetListeMedecins());
            Medecins.Add(Medecin);
            _medecinWindow = medecinWindow;
        }

        public void ActionSelectionChangedCommand()
        {
            MedTmp = Medecins.FirstOrDefault(x => x.Code == Medecin.Code);
        }

        public void ActionNewCommand()
        {
            Medecin = Medecins.FirstOrDefault(x => x.Code == 0);
            if (Medecin != null)
                Medecins.Add(Medecin);
            Specialite = null;
            RaiseAllChanged();
        }

        public void ActionAddCommand()
        {
            if (Nom != default(string) && Telephone != default(string) && NomSpe != default(string))
            {

                if (Code == 0)
                {
                    IdSpecialite = Id;
                    if (Medecin.Save())
                    {
                        MessageBox.Show("Médecin enregistré");
                        Medecin = new Medecin();
                        Specialite = new Specialite();
                        RaiseAllChanged();
                    }
                    else
                    {
                        MessageBox.Show("Il y a eu une erreur dans l'enregistrement de ce médecin, merci de recommencer");
                        Medecin = Medecins.FirstOrDefault(x => x.Code == 0);
                    }
                }
                else
                {
                    MessageBox.Show("Ce code médecin existe déjà, merci de sélectionner 0");
                }
            }
            else
            {
                MessageBox.Show("Merci de remplir tous les champs");
            }
        }

        public void ActionModCommand()
        {
            if (Medecin.Code > 0 && Nom != default(string) && Telephone != default(string) && NomSpe != default(string))
            {                
                if (MedTmp.Nom != Medecin.Nom || MedTmp.Telephone != Medecin.Telephone || MedTmp.Embauche != Medecin.Embauche || MedTmp.IdSpecialite != Medecin.IdSpecialite)
                {
                    if (Medecin.Update())
                    {
                        MessageBox.Show("Mise à jour du médecin effectuée");
                        RaiseAllChanged();
                        Medecin = new Medecin();
                    }
                    else
                        MessageBox.Show("Erreur lors de la mise à jour du médecin");
                }
                else
                    MessageBox.Show("Aucune modification n'a été apportée à ce médecin");
            }
            else
                MessageBox.Show("Merci de remplir tous les champs");
        }

        public void ActionDelCommand()
        {

        }

        public void ActionExitCommand()
        {

        }

        private void RaiseMedecinChanged()
        {
            RaisePropertyChanged("Medecin");
            RaisePropertyChanged("Code");
            RaisePropertyChanged("Nom");
            RaisePropertyChanged("Telephone");
            RaisePropertyChanged("Embauche");
            RaisePropertyChanged("Specialite");
        }

        private void RaiseSpecialiteChanged()
        {
            RaisePropertyChanged("Id");
            RaisePropertyChanged("NomSpe");
        }

        private void RaiseAllChanged()
        {
            RaiseMedecinChanged();
            RaiseSpecialiteChanged();
            RaisePropertyChanged("Specialites");
            RaisePropertyChanged("Medecins");
        }
    }
}
