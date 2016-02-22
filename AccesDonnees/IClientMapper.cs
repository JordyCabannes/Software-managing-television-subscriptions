
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TP3_genie_noel.Logique;

namespace TP3_genie_noel.AccesDonnees
{

public interface IClientMapper
 {
      Client Find(Guid ID);
      DataTable FindAll();
      int Insert(Client pClient);
      int Update(Client pClient);
      int Delete(Client pClient);
 }

 }

       