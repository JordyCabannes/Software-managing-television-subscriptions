using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using TP3_genie_noel.AccesDonnees;
namespace TP3_genie_noel
{
    public static class GlobalConfig
    {

        public static string getConnectionString()
        {
            return "Data Source=(localdb)\\ProjectsV12;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public static MapperType getMapperType()
        {
            return MapperType.MSSQL;
        }
    }
}
