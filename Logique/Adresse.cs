
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP3_genie_noel.Logique
{

public class Adresse : DomainObject
 {
		private string mAdresse_branchement;
        public string Adresse_branchement {
        			get {
          				return  mAdresse_branchement;
        			}
        			set {
          				mAdresse_branchement=value;
        			}
    		    }
      	private bool mBranchee;
        public bool  Branchee {
        			get {
          				return  mBranchee;
        			}
        			set {
          				mBranchee=value;
        			}
    		    }
      

 }

}
       