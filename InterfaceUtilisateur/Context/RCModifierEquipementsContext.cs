using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TP3_genie_noel.AccesDonnees;
using TP3_genie_noel.Logique;

namespace TP3_genie_noel.InterfaceUtilisateur.Context
{
    class RCModifierEquipementsContext : INotifyPropertyChanged
    {
        private static RCModifierEquipementsContext instance;

        private RCModifierEquipementsContext() { }

        public static RCModifierEquipementsContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RCModifierEquipementsContext();
                }
                return instance;
            }
        }

        public Guid GuidCompte
        {
            get
            {
                return guidCompte;
            }

            set
            {
                guidCompte = value;
                NotifyPropertyChanged("GuidCompte");
            }
        }

        private Guid guidCompte;

        public int Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
                NotifyPropertyChanged("Numero");
            }
        }

        private int numero;

        public Guid GuidClient
        {
            get
            {
                return guidClient;
            }

            set
            {
                guidClient = value;
                NotifyPropertyChanged("GuidClient");
            }
        }
        private Guid guidClient;

        public string NomRaison
        {
            get
            {
                return nomRaison;
            }

            set
            {
                nomRaison = value;
                NotifyPropertyChanged("NomRaison");
            }
        }
        private string nomRaison;

        public Visibility GridVisible
        {
            get
            {
                return gridVisible;
            }

            set
            {
                gridVisible = value;
                NotifyPropertyChanged("GridVisible");
            }
        }

        private Visibility gridVisible;


        public Visibility Grid2Visible
        {
            get
            {
                return grid2Visible;
            }

            set
            {
                grid2Visible = value;
                NotifyPropertyChanged("Grid2Visible");
            }
        }

        private Visibility grid2Visible;

        private ObservableCollection<Equipement> listeDispo = new ObservableCollection<Equipement>();
        public ObservableCollection<Equipement> ListeDispo { get { return listeDispo; } }

        public void ChercherEquipDispo()
        {
            IEquipementMapper lEquipementMapper = (IEquipementMapper)DataMapperFactory.GetDataMapperFactory().GetEquipementMapper();
            DataTable equips = lEquipementMapper.FindAll();
            listeDispo.Clear();
            foreach (DataRow row in equips.Rows)
            {
                listeDispo.Add(new Equipement
                {
                    Numero = Int32.Parse(row["numero"].ToString()),
                    Nom = row["nom"].ToString(),
                    Tarif_mensuel_de_location = float.Parse(row["tarif_mensuel_de_location"].ToString(), CultureInfo.InvariantCulture.NumberFormat),
                    IDCompte = ""
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
