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
using TP3_genie_noel.AccesDonnees;
using TP3_genie_noel.InterfaceUtilisateur.Context;
using TP3_genie_noel.Logique;

namespace TP3_genie_noel.InterfaceUtilisateur
{
    /// <summary>
    /// Logique d'interaction pour RCModifierClient.xaml
    /// </summary>
    public partial class RCModifierClient : Page
    {
        public RCModifierClient()
        {
            DataContext = RCModifierClientContext.Instance;
            InitializeComponent();
        }

        private void Btn_Effacer_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            else
                MessageBox.Show("Vous êtes déjà au début.");
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
                TextBox_Tel.Text.Length >= 1 &&
                TextBox_Identifiant.Text.Length >= 1 &&
                TextBox_MotDePasse.Text.Length >= 1)
            {
                Client lClient = new Client();
                lClient.ID = RCModifierClientContext.Instance.ID;
                if (TextBox_Nom.Text.Length >= 1 && TextBox_Prenom.Text.Length >= 1)
                {
                    lClient.Nom = TextBox_Nom.Text;
                    lClient.Prenom = TextBox_Prenom.Text;
                }
                else
                    lClient.Raison_sociale = TextBox_Raison.Text;
                lClient.Adresse = TextBox_Adr1.Text;
                lClient.Telephone = TextBox_Tel.Text;
                lClient.Pseudo = TextBox_Identifiant.Text;
                lClient.Mot_de_passe = TextBox_MotDePasse.Text;

                IClientMapper lClientMapper = (IClientMapper)DataMapperFactory.GetDataMapperFactory().GetClientMapper();
                lClientMapper.Update(lClient);

                MessageBox.Show("Enregistré !");
                if (NavigationService.CanGoBack)
                    NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
            }
        }
    }
}
