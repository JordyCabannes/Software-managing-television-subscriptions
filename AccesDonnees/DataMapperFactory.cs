
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP3_genie_noel;

namespace TP3_genie_noel.AccesDonnees
{

public abstract class DataMapperFactory
 {

      	
        public abstract IClientMapper GetClientMapper();
      	
        public abstract ICompteMapper GetCompteMapper();
      	
        public abstract IServiceDiffusionMapper GetServiceDiffusionMapper();
      	
        public abstract IEquipementMapper GetEquipementMapper();
      	
        public abstract IEmployeMapper GetEmployeMapper();
      	
        public abstract IInstallationMapper GetInstallationMapper();
      	
        public abstract IChaineMapper GetChaineMapper();
      	
        public abstract IAdresseMapper GetAdresseMapper();
      	
        public abstract ICompteServiceMapper GetCompteServiceMapper();
      	
        public abstract IServiceChaineMapper GetServiceChaineMapper();
      	
        public abstract ICompteChaineMapper GetCompteChaineMapper();
      

      public static DataMapperFactory GetDataMapperFactory()
      {
          switch (GlobalConfig.getMapperType())
          {
              case MapperType.MEMORY:
                  return null;
              case MapperType.MSSQL:
                  return new MSSQL.MSSQLDataMapperFactory();
              case MapperType.MYSQL:
                  return null;
              case MapperType.ORACLE:
                  return null;
              case MapperType.FLAT_FILE:
                  return null;
              case MapperType.NONE:
                  return null;
              default:
                  return null;
          }

      }

 }

 }

       