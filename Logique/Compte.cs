
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP3_genie_noel.Logique
{

public class Compte : DomainObject
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
      	private string mMode_de_facturation;
        public string Mode_de_facturation {
        			get {
          				return  mMode_de_facturation;
        			}
        			set {
          				mMode_de_facturation=value;
        			}
    		    }
      	private float mSolde;
        public float Solde {
        			get {
          				return  mSolde;
        			}
        			set {
          				mSolde=value;
        			}
    		    }
      	private float mTotal_du_mois;
        public float Total_du_mois {
        			get {
          				return  mTotal_du_mois;
        			}
        			set {
          				mTotal_du_mois=value;
        			}
    		    }
      	private string mIDClient;
        public string IDClient {
        			get {
          				return  mIDClient;
        			}
        			set {
          				mIDClient=value;
        			}
    		    }
      

 }

}
       