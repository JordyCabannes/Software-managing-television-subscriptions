
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TP3_genie_noel.Logique;

namespace TP3_genie_noel.AccesDonnees
{

public interface ICompteChaineMapper
 {
      CompteChaine Find(Guid ID);
      DataTable FindAll();
      int Insert(CompteChaine pCompteChaine);
      int Update(CompteChaine pCompteChaine);
      int Delete(CompteChaine pCompteChaine);
 }

 }

       