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

namespace TP3_genie_noel.InterfaceUtilisateur
{
    /// <summary>
    /// Logique d'interaction pour RCCreerCompte.xaml
    /// </summary>
    public partial class RCCreerCompte : Page
    {
        public RCCreerCompte()
        {
            DataContext = RCCreerCompteContext.Instance;
            InitializeComponent();
        }

        private void Btn_ModifService_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Non gérée pour cette version du logiciel.");
            //return;
            //RCModifierServices page = new RCModifierServices();
            //NavigationService.Navigate(page);

        }

        private void Btn_ModifEquip_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Non gérée pour cette version du logiciel.");
            //return;
            //RCModifierEquipements page = new RCModifierEquipements();
            //NavigationService.Navigate(page);
        }

        private void Btn_Annuler_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            else
                MessageBox.Show("Vous êtes déjà au début.");
        }

        private void Btn_CreerCompte_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Numero.Text.Length < 1)
            {
                MessageBox.Show("Veuillez choisir un numéro.");
                return;
            }
            if (TextBox_Solde.Text.Length < 1)
            {
                MessageBox.Show("Veuillez choisir un solde.");
                return;
            }
            ICompteMapper lCompteMapper = (ICompteMapper)DataMapperFactory.GetDataMapperFactory().GetCompteMapper();
            Compte compte = new Compte();
            compte.IDClient = RCCreerCompteContext.Instance.GuidClient.ToString();
            compte.Mode_de_facturation = ComboBox_Mode.Text;
            Random rnd = new Random();
            int numero;
            if (Int32.TryParse(TextBox_Numero.Text, out numero))
                compte.Numero = numero;
            else
                compte.Numero = rnd.Next(1, 1000);
            float solde;
            if (float.TryParse(TextBox_Solde.Text.Replace(',', '.'), out solde))
                compte.Solde = solde;
            else
                compte.Solde = 0;
            lCompteMapper.Insert(compte);

            MessageBox.Show("Compte créé avec succès.");
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }

        private void Btn_CreerCompteProg_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Numero.Text.Length < 1)
            {
                MessageBox.Show("Veuillez choisir un numéro.");
                return;
            }
            if (TextBox_Solde.Text.Length < 1)
            {
                MessageBox.Show("Veuillez choisir un solde.");
                return;
            }
            ICompteMapper lCompteMapper = (ICompteMapper)DataMapperFactory.GetDataMapperFactory().GetCompteMapper();
            Compte compte = new Compte();
            compte.IDClient = RCCreerCompteContext.Instance.GuidClient.ToString();
            compte.Mode_de_facturation = ComboBox_Mode.Text;
            Random rnd = new Random();
            int numero;
            if (Int32.TryParse(TextBox_Numero.Text, out numero))
                compte.Numero = numero;
            else
                compte.Numero = rnd.Next(1, 1000);
            float solde;
            if (float.TryParse(TextBox_Solde.Text.Replace(',', '.'), out solde))
                compte.Solde = solde;
            else
                compte.Solde = 0;
            lCompteMapper.Insert(compte);

            MessageBox.Show("Compte créé avec succès.\n\nVeuillez choisir une date d'installation.");
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            //return;
            //RCProgrammerInstallation page = new RCProgrammerInstallation();
            //NavigationService.Navigate(page);
        }
    }
}
