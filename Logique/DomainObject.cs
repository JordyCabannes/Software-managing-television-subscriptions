using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP3_genie_noel.Logique
{
    public class DomainObject
    {
        private Guid lID;

        public DomainObject()
        {
            lID = Guid.NewGuid();
        }

        public Guid ID
        {
            get { return lID; }
            set { lID = value; }
        }
    }
}
