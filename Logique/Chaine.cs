
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP3_genie_noel.Logique
{

public class Chaine : DomainObject
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
      	private string mSigle;
        public string Sigle {
        			get {
          				return  mSigle;
        			}
        			set {
          				mSigle=value;
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
      	private string mNature;
        public string Nature {
        			get {
          				return  mNature;
        			}
        			set {
          				mNature=value;
        			}
    		    }
      	private float mPrix;
        public float Prix {
        			get {
          				return  mPrix;
        			}
        			set {
          				mPrix=value;
        			}
    		    }
      

 }

}
       