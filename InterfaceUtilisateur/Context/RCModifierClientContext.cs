using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TP3_genie_noel.InterfaceUtilisateur.Context
{
    class RCModifierClientContext : INotifyPropertyChanged
    {
        private static RCModifierClientContext instance;

        private RCModifierClientContext() { }

        public static RCModifierClientContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RCModifierClientContext();
                }
                return instance;
            }
        }

        public Guid ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                NotifyPropertyChanged("ID");
            }
        }
        private Guid id;
        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
                NotifyPropertyChanged("Nom");
            }
        }
        private string nom;
        public string Prenom
        {
            get
            {
                return prenom;
            }

            set
            {
                prenom = value;
                NotifyPropertyChanged("Prenom");
            }
        }
        private string prenom;
        public string RaisonSociale
        {
            get
            {
                return raisonSociale;
            }

            set
            {
                raisonSociale = value;
                NotifyPropertyChanged("RaisonSociale");
            }
        }
        private string raisonSociale;
        public string Adresse
        {
            get
            {
                return adresse;
            }

            set
            {
                adresse = value;
                NotifyPropertyChanged("Adresse");
            }
        }
        private string adresse;
        public string Telephone
        {
            get
            {
                return telephone;
            }

            set
            {
                telephone = value;
                NotifyPropertyChanged("Telephone");
            }
        }
        private string telephone;
        public string Pseudo
        {
            get
            {
                return pseudo;
            }

            set
            {
                pseudo = value;
                NotifyPropertyChanged("Pseudo");
            }
        }
        private string pseudo;
        public string MotDePasse
        {
            get
            {
                return motDePasse;
            }

            set
            {
                motDePasse = value;
                NotifyPropertyChanged("MotDePasse");
            }
        }
        private string motDePasse;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
