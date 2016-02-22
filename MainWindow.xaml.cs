using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using TP3_genie_noel.InterfaceUtilisateur;
using TP3_genie_noel.Logique;
using TP3_genie_noel.Utiles;

namespace TP3_genie_noel
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Connecter_Click(object sender, RoutedEventArgs e)
        {
            //UtilisateurConnecte utilisateurConnecte2 = UtilisateurConnecte.Instance;
            //utilisateurConnecte2.Identifiant = "login";
            //utilisateurConnecte2.Role = "role";
            //RC otherWindow2 = new RC();
            //otherWindow2.Show();
            //this.Close();
            //return;

            // on cherche si c'est un client
            IClientMapper lClientMapper = (IClientMapper)DataMapperFactory.GetDataMapperFactory().GetClientMapper();
            DataTable clients = lClientMapper.FindAll();
            foreach (DataRow row in clients.Rows)
            {
                if (TextBox_Identifiant.Text == row["pseudo"].ToString() &&
                    TextBox_Motdepasse.Password == row["mot_de_passe"].ToString())
                {
                    // un client s'est connecté
                    UtilisateurConnecte utilisateurConnecte = UtilisateurConnecte.Instance;
                    utilisateurConnecte.Identifiant = TextBox_Identifiant.Text;
                    utilisateurConnecte.Role = "Client";
                    FenetreClient otherWindow = new FenetreClient();
                    otherWindow.Show();
                    this.Close();
                    return;
                }
            }

            // on cherche si c'est un employé
            IEmployeMapper lEmployeMapper = (IEmployeMapper)DataMapperFactory.GetDataMapperFactory().GetEmployeMapper();
            DataTable employes = lEmployeMapper.FindAll();
            foreach (DataRow row in employes.Rows)
            {
                if (TextBox_Identifiant.Text == row["pseudo"].ToString() &&
                    TextBox_Motdepasse.Password == row["mot_de_passe"].ToString())
                {
                    // un employé RC s'est connecté
                    UtilisateurConnecte utilisateurConnecte = UtilisateurConnecte.Instance;
                    utilisateurConnecte.Identifiant = TextBox_Identifiant.Text;
                    utilisateurConnecte.Role = row["fonction"].ToString();
                    RC otherWindow = new RC();
                    otherWindow.Show();
                    this.Close();
                    return;
                }
            }

            MessageBox.Show("Identifiant ou mot de passe incorrect.");
        }
    }
}

