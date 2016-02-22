
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TP3_genie_noel.Logique;

namespace TP3_genie_noel.AccesDonnees
{

public interface ICompteServiceMapper
 {
      CompteService Find(Guid ID);
      DataTable FindAll();
      int Insert(CompteService pCompteService);
      int Update(CompteService pCompteService);
      int Delete(CompteService pCompteService);
 }

 }

       