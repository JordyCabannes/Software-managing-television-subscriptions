using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_genie_noel.AccesDonnees;
using TP3_genie_noel.Logique;

namespace TP3_genie_noel.InterfaceUtilisateur.Context
{
    class SelectionnerCompteContext
    {
        private ObservableCollection<CompteSelection> listeCompte = new ObservableCollection<CompteSelection>();
        public ObservableCollection<CompteSelection> ListeCompte { get { return listeCompte; } }

        public SelectionnerCompteContext()
        {
            ICompteMapper lCompteMapper = (ICompteMapper)DataMapperFactory.GetDataMapperFactory().GetCompteMapper();
            DataTable comptes = lCompteMapper.FindAll();
            foreach (DataRow row in comptes.Rows)
            {
                Guid guidCompte;
                if (Guid.TryParse(row["iD"].ToString(), out guidCompte))
                {
                    IClientMapper lClientMapper = (IClientMapper)DataMapperFactory.GetDataMapperFactory().GetClientMapper();
                    Guid guidClient;
                    if (Guid.TryParse(row["iDClient"].ToString(), out guidClient))
                    {
                        Client client = lClientMapper.Find(guidClient);
                        listeCompte.Add(new CompteSelection
                        {
                            NomRaison = client.Nom + " " + client.Prenom + " " + client.Raison_sociale,
                            GuidClient = guidClient,
                            Numero = Int32.Parse(row["numero"].ToString()),
                            GuidCompte = guidCompte,
                            Solde = float.Parse(row["solde"].ToString()),
                            Mode = (row["mode_de_facturation"].ToString().Equals("Mensuel") ? 0 : 1),
                            Client = new Client
                            {
                                Numero = client.Numero,
                                Pseudo = client.Pseudo,
                                Mot_de_passe = client.Mot_de_passe,
                                Nom = client.Nom,
                                Prenom = client.Prenom,
                                Raison_sociale = client.Raison_sociale,
                                Adresse = client.Adresse,
                                Telephone = client.Telephone
                            }
                        });
                    }
                    else
                        Debug.WriteLine("Client non trouvé");
                }
                else
                    Debug.WriteLine("Compte non trouvé");
            }
        }
    }
}
