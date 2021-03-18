using Doctolib.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Hopital
{
    /// <summary>
    /// Logique d'interaction pour Rechercher_RDV.xaml
    /// </summary>
    public partial class Rechercher_RDV : Window
    {
        public Rechercher_RDV()
        {
            InitializeComponent();
            Rechercher_RDVViewModel model = new Rechercher_RDVViewModel();
            DataContext = model;
        }

    }
}