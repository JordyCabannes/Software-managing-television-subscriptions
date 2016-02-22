using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TP3_genie_noel.InterfaceUtilisateur.Context
{
    class RCModifierCompteContext : INotifyPropertyChanged
    {
        private static RCModifierCompteContext instance;

        private RCModifierCompteContext() { }

        public static RCModifierCompteContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RCModifierCompteContext();
                }
                return instance;
            }
        }

        public float Solde
        {
            get
            {
                return solde;
            }

            set
            {
                solde = value;
                NotifyPropertyChanged("Solde");
            }
        }

        private float solde;

        public int Mode
        {
            get
            {
                return mode;
            }

            set
            {
                mode = value;
                NotifyPropertyChanged("Mode");
            }
        }

        private int mode;

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


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
