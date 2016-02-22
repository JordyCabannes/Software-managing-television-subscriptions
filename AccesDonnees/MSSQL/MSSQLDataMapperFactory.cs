
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP3_genie_noel.AccesDonnees.MSSQL
{
    public class MSSQLDataMapperFactory : DataMapperFactory
    {
    public MSSQLDataMapperFactory()
    {
    }

 	
   public override IClientMapper GetClientMapper()
   {
    return new ClientMapper();
   }
 	
   public override ICompteMapper GetCompteMapper()
   {
    return new CompteMapper();
   }
 	
   public override IServiceDiffusionMapper GetServiceDiffusionMapper()
   {
    return new ServiceDiffusionMapper();
   }
 	
   public override IEquipementMapper GetEquipementMapper()
   {
    return new EquipementMapper();
   }
 	
   public override IEmployeMapper GetEmployeMapper()
   {
    return new EmployeMapper();
   }
 	
   public override IInstallationMapper GetInstallationMapper()
   {
    return new InstallationMapper();
   }
 	
   public override IChaineMapper GetChaineMapper()
   {
    return new ChaineMapper();
   }
 	
   public override IAdresseMapper GetAdresseMapper()
   {
    return new AdresseMapper();
   }
 	
   public override ICompteServiceMapper GetCompteServiceMapper()
   {
    return new CompteServiceMapper();
   }
 	
   public override IServiceChaineMapper GetServiceChaineMapper()
   {
    return new ServiceChaineMapper();
   }
 	
   public override ICompteChaineMapper GetCompteChaineMapper()
   {
    return new CompteChaineMapper();
   }
 

    }
}

