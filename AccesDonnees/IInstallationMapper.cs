
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TP3_genie_noel.Logique;

namespace TP3_genie_noel.AccesDonnees
{

public interface IInstallationMapper
 {
      Installation Find(Guid ID);
      DataTable FindAll();
      int Insert(Installation pInstallation);
      int Update(Installation pInstallation);
      int Delete(Installation pInstallation);
 }

 }

       