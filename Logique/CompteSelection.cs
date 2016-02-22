using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_genie_noel.Logique
{
    class CompteSelection : ClientSelection
    {
        public int Numero { get; set; }
        public string NumeroStr { get { return Numero.ToString(); } }
        public Guid GuidCompte { get; set; }
        public float Solde { get; set; }
        public int Mode { get; set; }
        public Client Client { get; set; }
    }
}
