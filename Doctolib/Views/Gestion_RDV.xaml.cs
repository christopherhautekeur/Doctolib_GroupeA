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
    /// Logique d'interaction pour Gestion_RDV.xaml
    /// </summary>
    public partial class Gestion_RDV : Window
    {
        public Gestion_RDV()
        {
            InitializeComponent();
            Gestion_RDVViewModel viewModel = new Gestion_RDVViewModel();
            DataContext = viewModel;
        }
    }
}
