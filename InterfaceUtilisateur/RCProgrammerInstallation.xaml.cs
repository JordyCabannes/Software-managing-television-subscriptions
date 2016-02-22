using System;
using System.Collections.Generic;
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
using TP3_genie_noel.InterfaceUtilisateur.Context;

namespace TP3_genie_noel.InterfaceUtilisateur
{
    /// <summary>
    /// Logique d'interaction pour RCProgrammerInstallation.xaml
    /// </summary>
    public partial class RCProgrammerInstallation : Page
    {
        public RCProgrammerInstallation()
        {
            DataContext = RCProgrammerInstallationContext.Instance;
            InitializeComponent();
            ListBox_Disponible.ItemsSource = RCProgrammerInstallationContext.Instance.ListeInstall;
        }

        private void Btn_Annuler_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            else
                MessageBox.Show("Vous êtes déjà au début.");
        }

        private void Btn_Programmer_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox_Disponible.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir une date.");
                return;
            }
            MessageBox.Show("Installation programmée avec succès !");
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }

        private void Btn_Exporter_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Non gérée pour cette version du logiciel.");
        }
    }
}
