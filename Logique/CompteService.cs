
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP3_genie_noel.Logique
{

public class CompteService : DomainObject
 {
		private string mId_compe;
        public string Id_compe {
        			get {
          				return  mId_compe;
        			}
        			set {
          				mId_compe=value;
        			}
    		    }
      	private string mId_service;
        public string Id_service {
        			get {
          				return  mId_service;
        			}
        			set {
          				mId_service=value;
        			}
    		    }
      

 }

}
       