
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP3_genie_noel.Logique
{

public class ServiceChaine : DomainObject
 {
		private string mId_service;
        public string Id_service {
        			get {
          				return  mId_service;
        			}
        			set {
          				mId_service=value;
        			}
    		    }
      	private string mId_compte;
        public string Id_compte {
        			get {
          				return  mId_compte;
        			}
        			set {
          				mId_compte=value;
        			}
    		    }
      

 }

}
       