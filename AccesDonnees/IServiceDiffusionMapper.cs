
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TP3_genie_noel.Logique;

namespace TP3_genie_noel.AccesDonnees
{

public interface IServiceDiffusionMapper
 {
      ServiceDiffusion Find(Guid ID);
      DataTable FindAll();
      int Insert(ServiceDiffusion pServiceDiffusion);
      int Update(ServiceDiffusion pServiceDiffusion);
      int Delete(ServiceDiffusion pServiceDiffusion);
 }

 }

       