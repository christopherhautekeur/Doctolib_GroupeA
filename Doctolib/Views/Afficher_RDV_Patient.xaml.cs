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

namespace Hopital
{
    /// <summary>
    /// Logique d'interaction pour Afficher_Tout.xaml
    /// </summary>
    public partial class Afficher_RDV_Patient : UserControl
    {
        public Afficher_RDV_Patient()
        {
            InitializeComponent();
            Afficher_RDV_PatientViewModel viewModel = new Afficher_RDV_PatientViewModel();
            DataContext = viewModel;
        }

    }
}
