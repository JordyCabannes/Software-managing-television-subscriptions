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
    /// Logique d'interaction pour SelectionnerCompte.xaml
    /// </summary>
    public partial class SelectionnerCompte : Window
    {
        private SelectionnerCompteContext context = new SelectionnerCompteContext();
        public string Client
        {
            get
            {
                CompteSelection compte = (ComboBox_Compte.SelectedItem as CompteSelection);
                if (compte == null)
                    return "";
                return compte.NomRaison;
            }
        }
        public Guid GuidClient
        {
            get
            {
                CompteSelection compte = (ComboBox_Compte.SelectedItem as CompteSelection);
                if (compte == null)
                    return Guid.Empty;
                return compte.GuidClient;
            }
        }
        public int Numero
        {
            get
            {
                CompteSelection compte = (ComboBox_Compte.SelectedItem as CompteSelection);
                if (compte == null)
                    return 0;
                return compte.Numero;
            }
        }
        public string NumeroStr
        {
            get
            {
                CompteSelection compte = (ComboBox_Compte.SelectedItem as CompteSelection);
                if (compte == null)
                    return "";
                return compte.NumeroStr;
            }
        }
        public Guid GuidCompte
        {
            get
            {
                CompteSelection compte = (ComboBox_Compte.SelectedItem as CompteSelection);
                if (compte == null)
                    return Guid.Empty;
                return compte.GuidCompte;
            }
        }
        public float Solde
        {
            get
            {
                CompteSelection compte = (ComboBox_Compte.SelectedItem as CompteSelection);
                if (compte == null)
                    return 0;
                return compte.Solde;
            }
        }
        public int Mode
        {
            get
            {
                CompteSelection compte = (ComboBox_Compte.SelectedItem as CompteSelection);
                if (compte == null)
                    return 0;
                return compte.Mode;
            }
        }

        public string ClientNom
        {
            get
            {
                CompteSelection compte = (ComboBox_Compte.SelectedItem as CompteSelection);
                if (compte == null)
                    return "";
                return compte.Client.Nom;
            }
        }
        public string ClientPrenom
        {
            get
            {
                CompteSelection compte = (ComboBox_Compte.SelectedItem as CompteSelection);
                if (compte == null)
                    return "";
                return compte.Client.Prenom;
            }
        }
        public string ClientRaisonSociale
        {
            get
            {
                CompteSelection compte = (ComboBox_Compte.SelectedItem as CompteSelection);
                if (compte == null)
                    return "";
                return compte.Client.Raison_sociale;
            }
        }
        public string ClientAdresse
        {
            get
            {
                CompteSelection compte = (ComboBox_Compte.SelectedItem as CompteSelection);
                if (compte == null)
                    return "";
                return compte.Client.Adresse;
            }
        }
        public string ClientTelephone
        {
            get
            {
                CompteSelection compte = (ComboBox_Compte.SelectedItem as CompteSelection);
                if (compte == null)
                    return "";
                return compte.Client.Telephone;
            }
        }
        public string ClientPseudo
        {
            get
            {
                CompteSelection compte = (ComboBox_Compte.SelectedItem as CompteSelection);
                if (compte == null)
                    return "";
                return compte.Client.Pseudo;
            }
        }
        public string ClientMotDePasse
        {
            get
            {
                CompteSelection compte = (ComboBox_Compte.SelectedItem as CompteSelection);
                if (compte == null)
                    return "";
                return compte.Client.Mot_de_passe;
            }
        }

        public SelectionnerCompte()
        {
            InitializeComponent();
            DataContext = context;
            ComboBox_Compte.ItemsSource = context.ListeCompte;
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
