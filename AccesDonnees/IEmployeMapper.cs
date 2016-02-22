
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TP3_genie_noel.Logique;

namespace TP3_genie_noel.AccesDonnees
{

public interface IEmployeMapper
 {
      Employe Find(Guid ID);
      DataTable FindAll();
      int Insert(Employe pEmploye);
      int Update(Employe pEmploye);
      int Delete(Employe pEmploye);
 }

 }

       