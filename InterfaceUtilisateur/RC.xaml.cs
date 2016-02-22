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
using TP3_genie_noel.InterfaceUtilisateur.Context;
using TP3_genie_noel.Logique;

namespace TP3_genie_noel.InterfaceUtilisateur
{
    /// <summary>
    /// Logique d'interaction pour RC.xaml
    /// </summary>
    public partial class RC : Window
    {
        public RC()
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

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tab_Abonne.IsSelected && MenuPosition.Instance.Position != 1)
            {
                MenuPosition.Instance.Position = 1;
            }
            else if (Tab_CreerCompte.IsSelected && MenuPosition.Instance.Position != 2)
            {
                MenuPosition.Instance.Position = 2;
                SelectionnerClient inputDialog = new SelectionnerClient();
                if (inputDialog.ShowDialog() == true && !String.IsNullOrEmpty(inputDialog.Client))
                {
                    //Client sélectionné
                    RCCreerCompteContext.Instance.GuidClient = inputDialog.GuidClient;
                    RCCreerCompteContext.Instance.NomRaison = inputDialog.Client;
                    RCCreerCompteContext.Instance.GridVisible = Visibility.Visible;
                    RCCreerCompteContext.Instance.Grid2Visible = Visibility.Collapsed;
                }
                else
                {
                    //Client non sélectionné
                    RCCreerCompteContext.Instance.GuidClient = Guid.Empty;
                    RCCreerCompteContext.Instance.NomRaison = "Non defini";
                    RCCreerCompteContext.Instance.GridVisible = Visibility.Collapsed;
                    RCCreerCompteContext.Instance.Grid2Visible = Visibility.Visible;
                }
            }
            else if (Tab_ModifierServices.IsSelected && MenuPosition.Instance.Position != 3)
            {
                MenuPosition.Instance.Position = 3;
                SelectionnerCompte inputDialog = new SelectionnerCompte();
                if (inputDialog.ShowDialog() == true && !String.IsNullOrEmpty(inputDialog.NumeroStr))
                {
                    //Compte sélectionné
                    RCModifierServicesContext.Instance.ChercherServiceDispo();
                    RCModifierServicesContext.Instance.ChercherChaineDispo();
                    RCModifierServicesContext.Instance.GuidCompte = inputDialog.GuidCompte;
                    RCModifierServicesContext.Instance.Numero = inputDialog.Numero;
                    RCModifierServicesContext.Instance.GuidClient = inputDialog.GuidClient;
                    RCModifierServicesContext.Instance.NomRaison = inputDialog.Client;
                    RCModifierServicesContext.Instance.GridVisible = Visibility.Visible;
                    RCModifierServicesContext.Instance.Grid2Visible = Visibility.Collapsed;

                }
                else
                {
                    //Compte non sélectionné
                    RCModifierServicesContext.Instance.GuidCompte = Guid.Empty;
                    RCModifierServicesContext.Instance.Numero = 0;
                    RCModifierServicesContext.Instance.GuidClient = Guid.Empty;
                    RCModifierServicesContext.Instance.NomRaison = "Non defini";
                    RCModifierServicesContext.Instance.GridVisible = Visibility.Collapsed;
                    RCModifierServicesContext.Instance.Grid2Visible = Visibility.Visible;
                }
            }
            else if (Tab_ModifierEquipements.IsSelected && MenuPosition.Instance.Position != 4)
            {
                MenuPosition.Instance.Position = 4;
                SelectionnerCompte inputDialog = new SelectionnerCompte();
                if (inputDialog.ShowDialog() == true && !String.IsNullOrEmpty(inputDialog.NumeroStr))
                {
                    //Compte sélectionné
                    RCModifierEquipementsContext.Instance.ChercherEquipDispo();
                    RCModifierEquipementsContext.Instance.GuidCompte = inputDialog.GuidCompte;
                    RCModifierEquipementsContext.Instance.Numero = inputDialog.Numero;
                    RCModifierEquipementsContext.Instance.GuidClient = inputDialog.GuidClient;
                    RCModifierEquipementsContext.Instance.NomRaison = inputDialog.Client;
                    RCModifierEquipementsContext.Instance.GridVisible = Visibility.Visible;
                    RCModifierEquipementsContext.Instance.Grid2Visible = Visibility.Collapsed;
                }
                else
                {
                    //Compte non sélectionné
                    RCModifierEquipementsContext.Instance.GuidCompte = Guid.Empty;
                    RCModifierEquipementsContext.Instance.Numero = 0;
                    RCModifierEquipementsContext.Instance.GuidClient = Guid.Empty;
                    RCModifierEquipementsContext.Instance.NomRaison = "Non defini";
                    RCModifierEquipementsContext.Instance.GridVisible = Visibility.Collapsed;
                    RCModifierEquipementsContext.Instance.Grid2Visible = Visibility.Visible;
                }
            }
            else if (Tab_ProgrammerInstallation.IsSelected && MenuPosition.Instance.Position != 5)
            {
                MenuPosition.Instance.Position = 5;
                SelectionnerClient inputDialog = new SelectionnerClient();
                if (inputDialog.ShowDialog() == true && !String.IsNullOrEmpty(inputDialog.Client))
                {
                    //Client sélectionné
                    RCProgrammerInstallationContext.Instance.ChercherInstall();
                    RCProgrammerInstallationContext.Instance.GuidClient = inputDialog.GuidClient;
                    RCProgrammerInstallationContext.Instance.NomRaison = inputDialog.Client;
                    RCProgrammerInstallationContext.Instance.GridVisible = Visibility.Visible;
                    RCProgrammerInstallationContext.Instance.Grid2Visible = Visibility.Collapsed;
                }
                else
                {
                    //Client non sélectionné
                    RCProgrammerInstallationContext.Instance.GuidClient = Guid.Empty;
                    RCProgrammerInstallationContext.Instance.NomRaison = "Non defini";
                    RCProgrammerInstallationContext.Instance.GridVisible = Visibility.Collapsed;
                    RCProgrammerInstallationContext.Instance.Grid2Visible = Visibility.Visible;
                }
            }
            else if (Tab_ModifierCompte.IsSelected && MenuPosition.Instance.Position != 6)
            {
                MenuPosition.Instance.Position = 6;
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
    }
}
