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
using TP3_genie_noel.Logique;

namespace TP3_genie_noel.InterfaceUtilisateur
{
    /// <summary>
    /// Logique d'interaction pour FenetreClient.xaml
    /// </summary>
    public partial class FenetreClient : Window
    {
        public FenetreClient()
        {
            InitializeComponent();

            UtilisateurConnecte utilisateurConnecte = UtilisateurConnecte.Instance;
            Login.Text = utilisateurConnecte.Identifiant;
            Role.Text = utilisateurConnecte.Role;
        }

        private void OnPreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow otherWindow = new MainWindow();
            otherWindow.Show();
            this.Close();
        }
    }
}
