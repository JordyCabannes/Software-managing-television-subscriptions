using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_genie_noel.Logique
{
    class MenuPosition
    {
        private static MenuPosition instance;

        private MenuPosition() { }

        public static MenuPosition Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MenuPosition();
                    instance.Position = 0;
                }
                return instance;
            }
        }

        public int Position { get; set; }
    }
}
