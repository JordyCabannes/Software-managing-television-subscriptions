using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP3_genie_noel.AccesDonnees;
using TP3_genie_noel.AccesDonnees.MSSQL;
using TP3_genie_noel.InterfaceUtilisateur.Context;

namespace TP3_genie_noel.InterfaceUtilisateur
{
    /// <summary>
    /// Logique d'interaction pour RCModifierServices.xaml
    /// </summary>
    public partial class RCModifierServices : Page
    {
        public RCModifierServices()
        {
            DataContext = RCModifierServicesContext.Instance;
            InitializeComponent();
            ListBox_Disponible.ItemsSource = RCModifierServicesContext.Instance.ListeDispo;
            DataGrid_Disponible.ItemsSource = RCModifierServicesContext.Instance.ListeChaine;
        }

        private void Btn_Annuler_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            else
                MessageBox.Show("Vous êtes déjà au début.");
        }

        private void Btn_Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Enregistré !");
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }

        private void Btn_Exporter_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Non gérée pour cette version du logiciel.");
        }

        private void Btn_Gauche_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Non gérée pour cette version du logiciel.");
        }

        private void Btn_Droite_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Non gérée pour cette version du logiciel.");
        }
    }
}
