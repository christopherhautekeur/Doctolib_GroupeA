using Doctolib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Doctolib
{
    /// <summary>
    /// Logique d'interaction pour Gestion_Medecin.xaml
    /// </summary>
    public partial class Gestion_Medecin : Window
    {
        public Gestion_Medecin()
        {
            InitializeComponent();
            Gestion_MedecinViewModel mVM = new Gestion_MedecinViewModel(this);
            DataContext = mVM;            
            if (mVM.CloseAction == null)
                mVM.CloseAction = new Action(this.Close);
        }
    }
}
