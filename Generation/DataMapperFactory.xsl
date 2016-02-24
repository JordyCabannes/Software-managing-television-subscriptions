<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"  xmlns:uFN="uFN" version="2.0">
  <xsl:import href="utilFunctions.xsl"/>
	<xsl:output method="text" encoding="iso-8859-1" indent="yes"/>

  <xsl:template match="Project/Models">
	   <xsl:result-document href="../TP3_genie_noel/TP3_genie_noel/AccesDonnees//DataMapperFactory.cs">
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP3_genie_noel;

namespace TP3_genie_noel.AccesDonnees
{

public abstract class DataMapperFactory
 {

      <xsl:for-each select="./Package">

      <xsl:for-each select="./ModelChildren/Class">
        <xsl:variable name="contextName" select="@Name"/>
        <xsl:text>&#x9;</xsl:text>
        public abstract I<xsl:value-of select="$contextName"/>Mapper Get<xsl:value-of select="$contextName"/>Mapper();
      </xsl:for-each>

      </xsl:for-each>

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

       </xsl:result-document>
</xsl:template>
</xsl:stylesheet>
