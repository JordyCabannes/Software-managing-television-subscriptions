
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TP3_genie_noel.Logique;

namespace TP3_genie_noel.AccesDonnees
{

public interface IServiceChaineMapper
 {
      ServiceChaine Find(Guid ID);
      DataTable FindAll();
      int Insert(ServiceChaine pServiceChaine);
      int Update(ServiceChaine pServiceChaine);
      int Delete(ServiceChaine pServiceChaine);
 }

 }

       