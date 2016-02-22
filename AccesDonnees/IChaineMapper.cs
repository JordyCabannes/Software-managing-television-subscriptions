
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TP3_genie_noel.Logique;

namespace TP3_genie_noel.AccesDonnees
{

public interface IChaineMapper
 {
      Chaine Find(Guid ID);
      DataTable FindAll();
      int Insert(Chaine pChaine);
      int Update(Chaine pChaine);
      int Delete(Chaine pChaine);
 }

 }

       