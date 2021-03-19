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
            DataContext = new Gestion_MedecinViewModel(this);
        }
    }
}
