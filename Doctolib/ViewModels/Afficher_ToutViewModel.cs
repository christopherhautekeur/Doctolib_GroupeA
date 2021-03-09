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
        
        public Afficher_ToutViewModel() {
            Liste = new ObservableCollection<RDV>(RDV.GetAll());
        }

        public ObservableCollection<RDV> Liste { get; set; }
    }
}
