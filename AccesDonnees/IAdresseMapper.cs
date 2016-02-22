
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TP3_genie_noel.Logique;

namespace TP3_genie_noel.AccesDonnees
{

public interface IAdresseMapper
 {
      Adresse Find(Guid ID);
      DataTable FindAll();
      int Insert(Adresse pAdresse);
      int Update(Adresse pAdresse);
      int Delete(Adresse pAdresse);
 }

 }

       