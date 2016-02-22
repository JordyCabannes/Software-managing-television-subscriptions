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
using System.Windows.Shapes;
using TP3_genie_noel.InterfaceUtilisateur.Context;
using TP3_genie_noel.Logique;

namespace TP3_genie_noel.InterfaceUtilisateur
{
    /// <summary>
    /// Logique d'interaction pour SelectionnerClient.xaml
    /// </summary>
    public partial class SelectionnerClient : Window
    {
        private SelectionnerClientContext context = new SelectionnerClientContext();
        public string Client
        {
            get
            {
                ClientSelection client = (ComboBox_Client.SelectedItem as ClientSelection);
                if (client == null)
                    return "";
                return client.NomRaison;
            }
        }
        public Guid GuidClient
        {
            get
            {
                ClientSelection client = (ComboBox_Client.SelectedItem as ClientSelection);
                if (client == null)
                    return Guid.Empty;
                return client.GuidClient;
            }
        }


        public SelectionnerClient()
        {
            InitializeComponent();
            DataContext = context;
            ComboBox_Client.ItemsSource = context.ListeClient;
        }

        private void Btn_OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Btn_Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
