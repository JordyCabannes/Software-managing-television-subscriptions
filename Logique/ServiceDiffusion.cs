
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP3_genie_noel.Logique
{

public class ServiceDiffusion : DomainObject
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
      

 }

}
       