
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP3_genie_noel.Logique
{

public class Employe : DomainObject
 {
		private int mNumero;
        public int Numero {
        			get {
          				return  mNumero;
        			}
        			set {
          				mNumero=value;
        			}
    		    }
      	private string mPseudo;
        public string Pseudo {
        			get {
          				return  mPseudo;
        			}
        			set {
          				mPseudo=value;
        			}
    		    }
      	private string mMot_de_passe;
        public string Mot_de_passe {
        			get {
          				return  mMot_de_passe;
        			}
        			set {
          				mMot_de_passe=value;
        			}
    		    }
      	private string mNom;
        public string Nom {
        			get {
          				return  mNom;
        			}
        			set {
          				mNom=value;
        			}
    		    }
      	private string mPrenom;
        public string Prenom {
        			get {
          				return  mPrenom;
        			}
        			set {
          				mPrenom=value;
        			}
    		    }
      	private string mAdresse;
        public string Adresse {
        			get {
          				return  mAdresse;
        			}
        			set {
          				mAdresse=value;
        			}
    		    }
      	private string mTelephone;
        public string Telephone {
        			get {
          				return  mTelephone;
        			}
        			set {
          				mTelephone=value;
        			}
    		    }
      	private string mFonction;
        public string Fonction {
        			get {
          				return  mFonction;
        			}
        			set {
          				mFonction=value;
        			}
    		    }
      	private float mSalaire;
        public float Salaire {
        			get {
          				return  mSalaire;
        			}
        			set {
          				mSalaire=value;
        			}
    		    }
      

 }

}
       