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
    /// Logique d'interaction pour RCModifierEquipements.xaml
    /// </summary>
    public partial class RCModifierEquipements : Page
    {
        public RCModifierEquipements()
        {
            DataContext = RCModifierEquipementsContext.Instance;
            InitializeComponent();
            ListBox_Disponible.ItemsSource = RCModifierEquipementsContext.Instance.ListeDispo;
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

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Non gérée pour cette version du logiciel.");
        }

        private void button12_Copy_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Non gérée pour cette version du logiciel.");
        }
    }
}
