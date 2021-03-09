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
    /// Logique d'interaction pour Gestion_Patients.xaml
    /// </summary>
    /// 

    public partial class Gestion_Patients : Window
    {
        public Gestion_Patients()
        {
            InitializeComponent();
            Gestion_PatientsViewModel viewModel = new Gestion_PatientsViewModel();
            DataContext = viewModel;
        }
    }
}
