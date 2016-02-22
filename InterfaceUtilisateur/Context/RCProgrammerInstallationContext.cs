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
using System.Windows;
using TP3_genie_noel.AccesDonnees;
using TP3_genie_noel.Logique;

namespace TP3_genie_noel.InterfaceUtilisateur.Context
{
    class RCProgrammerInstallationContext : INotifyPropertyChanged
    {
        private static RCProgrammerInstallationContext instance;

        private RCProgrammerInstallationContext() { }

        public static RCProgrammerInstallationContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RCProgrammerInstallationContext();
                }
                return instance;
            }
        }

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

        private ObservableCollection<Installation> listeInstall = new ObservableCollection<Installation>();
        public ObservableCollection<Installation> ListeInstall { get { return listeInstall; } }

        public void ChercherInstall()
        {
            IInstallationMapper lInstallMapper = (IInstallationMapper)DataMapperFactory.GetDataMapperFactory().GetInstallationMapper();
            DataTable installs = lInstallMapper.FindAll();
            listeInstall.Clear();
            foreach (DataRow row in installs.Rows)
            {
                listeInstall.Add(new Installation
                {
                    Numero = 123,
                    Date_programmation = row["date_programmation"].ToString(),
                    Date_realisation = row["date_realisation"].ToString(),
                    Frais = float.Parse(row["frais"].ToString()),
                    IDClient = ""
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
