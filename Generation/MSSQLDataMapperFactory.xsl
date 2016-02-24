<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"  xmlns:uFN="uFN" version="2.0">
  <xsl:import href="utilFunctions.xsl"/>
	<xsl:output method="text" encoding="iso-8859-1" indent="yes"/>

  <xsl:template match="Project/Models">
	   <xsl:result-document href="../TP3_genie_noel/TP3_genie_noel/AccesDonnees/MSSQL//MSSQLDataMapperFactory.cs">
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

 <xsl:for-each select="./Package">

 <xsl:for-each select="./ModelChildren/Class">
   <xsl:variable name="contextName" select="@Name"/>
   <xsl:text>&#x9;</xsl:text>
   public override I<xsl:value-of select="$contextName"/>Mapper Get<xsl:value-of select="$contextName"/>Mapper()
   {
    return new <xsl:value-of select="$contextName"/>Mapper();
   }
 </xsl:for-each>

 </xsl:for-each>

    }
}

</xsl:result-document>
</xsl:template>
</xsl:stylesheet>
