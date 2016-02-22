using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_genie_noel.Logique
{
    // singleton qui représente l'utilisateur connecté
    class UtilisateurConnecte
    {
        private static UtilisateurConnecte instance;

        private UtilisateurConnecte() { }

        public static UtilisateurConnecte Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UtilisateurConnecte();
                }
                return instance;
            }
        }

        public string Identifiant
        {
            get
            {
                return identifiant;
            }

            set
            {
                identifiant = value;
            }
        }

        public string Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
            }
        }

        private string identifiant;


        private string role;

    }
}
