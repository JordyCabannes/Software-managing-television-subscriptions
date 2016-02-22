using System;
using System.Collections.Generic;
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
using TP3_genie_noel.InterfaceUtilisateur.Context;
using TP3_genie_noel.Logique;
using TP3_genie_noel.Utiles;

namespace TP3_genie_noel.InterfaceUtilisateur
{
    /// <summary>
    /// Logique d'interaction pour RCAbonne.xaml
    /// </summary>
    public partial class RCAbonne : Page
    {
        public RCAbonne()
        {
            InitializeComponent();
        }

        private void Btn_Effacer_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Nom.Text.Length < 1 &&
                TextBox_Prenom.Text.Length < 1 &&
                TextBox_Adr1.Text.Length < 1 &&
                TextBox_Tel.Text.Length < 1 &&
                TextBox_Raison.Text.Length < 1)
            {

            }
            else
            {
                TextBox_Nom.Clear();
                TextBox_Prenom.Clear();
                TextBox_Adr1.Clear();
                TextBox_Tel.Clear();
                TextBox_Raison.Clear();
            }
        }

        private void Btn_Continuer_Click(object sender, RoutedEventArgs e)
        {
            if ((TextBox_Nom.Text.Length >= 1 || TextBox_Prenom.Text.Length >= 1) &&
                TextBox_Raison.Text.Length >= 1)
            {
                MessageBox.Show("Veuillez choisir entre les champs \"particulier\" et \"entreprise\".");
            }
            else if (((TextBox_Nom.Text.Length >= 1 && TextBox_Prenom.Text.Length >= 1) ||
                TextBox_Raison.Text.Length >= 1) &&
                TextBox_Adr1.Text.Length >= 1 &&
                TextBox_Tel.Text.Length >= 1)
            {
                Client lClient = new Client();
                if (TextBox_Nom.Text.Length >= 1 && TextBox_Prenom.Text.Length >= 1)
                {
                    lClient.Nom = TextBox_Nom.Text;
                    lClient.Prenom = TextBox_Prenom.Text;
                }
                else
                    lClient.Raison_sociale = TextBox_Raison.Text;
                lClient.Adresse = TextBox_Adr1.Text;
                lClient.Telephone = TextBox_Tel.Text;
                lClient.Pseudo = FonctionRandom.RandomString(6);
                lClient.Mot_de_passe = FonctionRandom.RandomString(6);

                IClientMapper lClientMapper = (IClientMapper)DataMapperFactory.GetDataMapperFactory().GetClientMapper();
                lClientMapper.Insert(lClient);
                MessageBox.Show("Le client a été ajouté. Voici ces identifiants :\n- Pseudo : " + lClient.Pseudo + "\n- Mot de passe : " + lClient.Mot_de_passe);
                //RCCreerCompte page = new RCCreerCompte();
                //NavigationService.Navigate(page);
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
            }
        }

        private void Btn_Branchement_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Non gérée pour cette version du logiciel.");
        }
    }
}
