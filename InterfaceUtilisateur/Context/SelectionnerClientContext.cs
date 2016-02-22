using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TP3_genie_noel.AccesDonnees;
using TP3_genie_noel.Logique;

namespace TP3_genie_noel.InterfaceUtilisateur.Context
{
    class SelectionnerClientContext
    {
        private ObservableCollection<ClientSelection> listeClient = new ObservableCollection<ClientSelection>();
        public ObservableCollection<ClientSelection> ListeClient { get { return listeClient; } }

        public SelectionnerClientContext()
        {
            IClientMapper lClientMapper = (IClientMapper)DataMapperFactory.GetDataMapperFactory().GetClientMapper();
            DataTable clients = lClientMapper.FindAll();
            foreach (DataRow row in clients.Rows)
            {
                Guid guidClient;
                if (Guid.TryParse(row["iD"].ToString(), out guidClient))
                {
                    listeClient.Add(new ClientSelection {
                        NomRaison = row["nom"].ToString() + " " + row["prenom"].ToString() + " " + row["raison_sociale"].ToString(),
                        GuidClient = guidClient
                    });
                }
                else
                    Debug.WriteLine("Client non trouvé");
            }
        }
    }
}
