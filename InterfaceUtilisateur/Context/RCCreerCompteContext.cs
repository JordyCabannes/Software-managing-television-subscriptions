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
    class RCCreerCompteContext : INotifyPropertyChanged
    {
        private static RCCreerCompteContext instance;

        private RCCreerCompteContext() { }

        public static RCCreerCompteContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RCCreerCompteContext();
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


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
