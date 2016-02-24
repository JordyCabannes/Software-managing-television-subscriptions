<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"  xmlns:uFN="uFN" version="2.0">
  <xsl:import href="utilFunctions.xsl"/>
	<xsl:output method="text" encoding="iso-8859-1" indent="yes"/>

  <xsl:template match="Project/Models">
    <xsl:for-each select="./Package">
      <xsl:for-each select="./ModelChildren/Class">
           <xsl:variable name="contextName" select="@Name"/>
	   <xsl:result-document href="../TP3_genie_noel/TP3_genie_noel/AccesDonnees//I{$contextName}Mapper.cs">
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TP3_genie_noel.Logique;

namespace TP3_genie_noel.AccesDonnees
{

public interface I<xsl:value-of select="$contextName"/>Mapper
 {
      <xsl:value-of select="$contextName"/> Find(Guid ID);
      DataTable FindAll();
      int Insert(<xsl:value-of select="$contextName"/> p<xsl:value-of select="$contextName"/>);
      int Update(<xsl:value-of select="$contextName"/> p<xsl:value-of select="$contextName"/>);
      int Delete(<xsl:value-of select="$contextName"/> p<xsl:value-of select="$contextName"/>);
 }

 }

       </xsl:result-document>
       </xsl:for-each>
       </xsl:for-each>
</xsl:template>
</xsl:stylesheet>
