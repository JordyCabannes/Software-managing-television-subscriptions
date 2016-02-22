using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Logique d'interaction pour RCModifierCompte.xaml
    /// </summary>
    public partial class RCModifierCompte : Page
    {
        public RCModifierCompte()
        {
            DataContext = RCModifierCompteContext.Instance;
            InitializeComponent();
        }

        private void Btn_Facturer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Facture envoyé.");
        }

        private void Btn_Cloturer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Etes vous sur?", "Confirmation de clôturation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                ICompteMapper lCompteMapper = (ICompteMapper)DataMapperFactory.GetDataMapperFactory().GetCompteMapper();
                Compte compte = new Compte();
                compte.ID = RCModifierCompteContext.Instance.GuidCompte;
                lCompteMapper.Delete(compte);

                MessageBox.Show("Facture envoyé.\n\nCompte clôturé.");
                SelectionnerCompte inputDialog = new SelectionnerCompte();
                if (inputDialog.ShowDialog() == true && !String.IsNullOrEmpty(inputDialog.NumeroStr))
                {
                    //Compte sélectionné
                    RCModifierCompteContext.Instance.Mode = inputDialog.Mode;
                    RCModifierCompteContext.Instance.Solde = inputDialog.Solde;
                    RCModifierCompteContext.Instance.GuidCompte = inputDialog.GuidCompte;
                    RCModifierCompteContext.Instance.Numero = inputDialog.Numero;
                    RCModifierCompteContext.Instance.GuidClient = inputDialog.GuidClient;
                    RCModifierCompteContext.Instance.NomRaison = inputDialog.Client;
                    RCModifierCompteContext.Instance.GridVisible = Visibility.Visible;
                    RCModifierCompteContext.Instance.Grid2Visible = Visibility.Collapsed;

                    //données du client
                    RCModifierClientContext.Instance.ID = inputDialog.GuidClient;
                    RCModifierClientContext.Instance.Nom = inputDialog.ClientNom;
                    RCModifierClientContext.Instance.Prenom = inputDialog.ClientPrenom;
                    RCModifierClientContext.Instance.RaisonSociale = inputDialog.ClientRaisonSociale;
                    RCModifierClientContext.Instance.Adresse = inputDialog.ClientAdresse;
                    RCModifierClientContext.Instance.Telephone = inputDialog.ClientTelephone;
                    RCModifierClientContext.Instance.Pseudo = inputDialog.ClientPseudo;
                    RCModifierClientContext.Instance.MotDePasse = inputDialog.ClientMotDePasse;
                }
                else
                {
                    //Compte non sélectionné
                    RCModifierCompteContext.Instance.Mode = 0;
                    RCModifierCompteContext.Instance.Solde = 0;
                    RCModifierCompteContext.Instance.GuidCompte = Guid.Empty;
                    RCModifierCompteContext.Instance.Numero = 0;
                    RCModifierCompteContext.Instance.GuidClient = Guid.Empty;
                    RCModifierCompteContext.Instance.NomRaison = "Non defini";
                    RCModifierCompteContext.Instance.GridVisible = Visibility.Collapsed;
                    RCModifierCompteContext.Instance.Grid2Visible = Visibility.Visible;
                }
            }
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
            ICompteMapper lCompteMapper = (ICompteMapper)DataMapperFactory.GetDataMapperFactory().GetCompteMapper();
            Compte compte = new Compte();
            compte.ID = RCModifierCompteContext.Instance.GuidCompte;
            compte.Numero = Int32.Parse(Label_NumCompte.Content.ToString());
            compte.IDClient = RCModifierCompteContext.Instance.GuidClient.ToString();
            compte.Mode_de_facturation = ComboBox_Mode.Text;
            compte.Total_du_mois = float.Parse(Label_Total.Content.ToString(), CultureInfo.InvariantCulture.NumberFormat);
            compte.Solde = float.Parse(TextBox_Solde.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
            lCompteMapper.Update(compte);

            MessageBox.Show("Enregistré !");
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }

        private void Btn_ModifierProfil_Click(object sender, RoutedEventArgs e)
        {
            RCModifierClient page = new RCModifierClient();
            NavigationService.Navigate(page);
        }
    }
}
