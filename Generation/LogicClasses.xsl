<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"  xmlns:uFN="uFN" version="2.0">
  <xsl:import href="utilFunctions.xsl"/>
	<xsl:output method="text" encoding="iso-8859-1" indent="yes"/>

  <xsl:template match="Project/Models">
    <xsl:for-each select="./Package">
      <xsl:for-each select="./ModelChildren/Class">
           <xsl:variable name="contextName" select="@Name"/>
	   <xsl:result-document href="../TP3_genie_noel/TP3_genie_noel/Logique//{$contextName}.cs">
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP3_genie_noel.Logique
{

public class <xsl:value-of select="$contextName"/> : DomainObject
 {
	<xsl:for-each select=".//Attribute">
    <xsl:variable name="type" select=".//DataType/@Name"/>
		<xsl:text>&#x9;</xsl:text>
		<xsl:value-of select="@Visibility"/>
		<xsl:text>&#x20;</xsl:text>
    <xsl:choose>
      <xsl:when test="$type='boolean'">
  		<xsl:text>bool</xsl:text>
  		<xsl:text> m</xsl:text>
  		<xsl:value-of select="uFN:first-upper(@Name)"/>;
        public bool <xsl:text>&#x20;</xsl:text> <xsl:value-of select="uFN:first-upper(./@Name)"/> {
        			get {
          				return <xsl:text> m</xsl:text><xsl:value-of select="uFN:first-upper(@Name)"/>;
        			}
        			set {
          				<xsl:text>m</xsl:text><xsl:value-of select="uFN:first-upper(@Name)"/>=value;
        			}
    		    }
      </xsl:when>
      <xsl:otherwise>
  		<xsl:value-of select=".//DataType/@Name"/>
  		<xsl:text> m</xsl:text>
  		<xsl:value-of select="uFN:first-upper(@Name)"/>;
        public <xsl:value-of select=".//DataType/@Name"/> <xsl:text>&#x20;</xsl:text> <xsl:value-of select="uFN:first-upper(./@Name)"/> {
        			get {
          				return <xsl:text> m</xsl:text><xsl:value-of select="uFN:first-upper(@Name)"/>;
        			}
        			set {
          				<xsl:text>m</xsl:text><xsl:value-of select="uFN:first-upper(@Name)"/>=value;
        			}
    		    }
      </xsl:otherwise>
    </xsl:choose>
	</xsl:for-each>

 }

}
       </xsl:result-document>
     </xsl:for-each>
     </xsl:for-each>
</xsl:template>
</xsl:stylesheet>
