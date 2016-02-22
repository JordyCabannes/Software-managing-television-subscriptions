
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TP3_genie_noel.Logique;

namespace TP3_genie_noel.AccesDonnees
{

public interface IEquipementMapper
 {
      Equipement Find(Guid ID);
      DataTable FindAll();
      int Insert(Equipement pEquipement);
      int Update(Equipement pEquipement);
      int Delete(Equipement pEquipement);
 }

 }

       