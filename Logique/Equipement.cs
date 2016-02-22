
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP3_genie_noel.Logique
{

public class Equipement : DomainObject
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
      	private string mNom;
        public string Nom {
        			get {
          				return  mNom;
        			}
        			set {
          				mNom=value;
        			}
    		    }
      	private float mTarif_mensuel_de_location;
        public float Tarif_mensuel_de_location {
        			get {
          				return  mTarif_mensuel_de_location;
        			}
        			set {
          				mTarif_mensuel_de_location=value;
        			}
    		    }
      	private string mIDCompte;
        public string IDCompte {
        			get {
          				return  mIDCompte;
        			}
        			set {
          				mIDCompte=value;
        			}
    		    }
      

 }

}
       