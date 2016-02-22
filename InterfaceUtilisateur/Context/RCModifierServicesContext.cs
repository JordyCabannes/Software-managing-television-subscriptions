using System;
using System.Collections;
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
    class RCModifierServicesContext : INotifyPropertyChanged
    {
        private static RCModifierServicesContext instance;

        private RCModifierServicesContext() { }

        public static RCModifierServicesContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RCModifierServicesContext();
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

        private ObservableCollection<ServiceDiffusion> listeDispo = new ObservableCollection<ServiceDiffusion>();
        public ObservableCollection<ServiceDiffusion> ListeDispo { get { return listeDispo; } }

        public void ChercherServiceDispo()
        {
            IServiceDiffusionMapper lServiceMapper = (IServiceDiffusionMapper)DataMapperFactory.GetDataMapperFactory().GetServiceDiffusionMapper();
            DataTable services = lServiceMapper.FindAll();
            listeDispo.Clear();
            foreach (DataRow row in services.Rows)
            {
                listeDispo.Add(new ServiceDiffusion
                {
                    Numero = Int32.Parse(row["numero"].ToString()),
                    Nom = row["nom"].ToString()
                });
            }
        }

        private ObservableCollection<Chaine> listeChaine = new ObservableCollection<Chaine>();
        public ObservableCollection<Chaine> ListeChaine { get { return listeChaine; } }

        public void ChercherChaineDispo()
        {
            IChaineMapper lChaineMapper = (IChaineMapper)DataMapperFactory.GetDataMapperFactory().GetChaineMapper();
            DataTable chaines = lChaineMapper.FindAll();
            listeChaine.Clear();
            foreach (DataRow row in chaines.Rows)
            {
                listeChaine.Add(new Chaine
                {
                    Numero = Int32.Parse(row["numero"].ToString()),
                    Sigle = row["sigle"].ToString(),
                    Nom = row["nom"].ToString(),
                    Nature = row["nature"].ToString(),
                    Prix = float.Parse(row["prix"].ToString(), CultureInfo.InvariantCulture.NumberFormat)
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
