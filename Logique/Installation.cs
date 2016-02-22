
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP3_genie_noel.Logique
{

public class Installation : DomainObject
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
      	private string mDate_programmation;
        public string Date_programmation {
        			get {
          				return  mDate_programmation;
        			}
        			set {
          				mDate_programmation=value;
        			}
    		    }
      	private string mDate_realisation;
        public string Date_realisation {
        			get {
          				return  mDate_realisation;
        			}
        			set {
          				mDate_realisation=value;
        			}
    		    }
      	private float mFrais;
        public float Frais {
        			get {
          				return  mFrais;
        			}
        			set {
          				mFrais=value;
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
       