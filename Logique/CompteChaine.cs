
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP3_genie_noel.Logique
{

public class CompteChaine : DomainObject
 {
		private string mId_compte;
        public string Id_compte {
        			get {
          				return  mId_compte;
        			}
        			set {
          				mId_compte=value;
        			}
    		    }
      	private string mId_chaine;
        public string Id_chaine {
        			get {
          				return  mId_chaine;
        			}
        			set {
          				mId_chaine=value;
        			}
    		    }
      

 }

}
       