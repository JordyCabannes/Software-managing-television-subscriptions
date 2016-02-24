<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"  xmlns:uFN="uFN" version="2.0">
  <xsl:import href="utilFunctions.xsl"/>
	<xsl:output method="text" encoding="iso-8859-1" indent="yes"/>

  <xsl:template match="Project/Models">
    <xsl:for-each select="./Package">
      <xsl:for-each select="./ModelChildren/Class">
           <xsl:variable name="contextName" select="@Name"/>
	   <xsl:result-document href="../TP3_genie_noel/TP3_genie_noel/AccesDonnees/MSSQL//{$contextName}Mapper.cs">
       using System;
       using System.Collections.Generic;
       using System.Linq;
       using System.Text;
       using System.Data;
       using TP3_genie_noel.Logique;

       namespace TP3_genie_noel.AccesDonnees.MSSQL
       {
           public class <xsl:value-of select="$contextName"/>Mapper : AbstractMapper, I<xsl:value-of select="$contextName"/>Mapper
           {

               public <xsl:value-of select="$contextName"/>Mapper()
               {
               }

               //--------------------------------------------------------------------
               public <xsl:value-of select="$contextName"/> Find(Guid ID)
               {
                   <xsl:value-of select="$contextName"/> l<xsl:value-of select="$contextName"/> = (<xsl:value-of select="$contextName"/>)AbstractFind(ID);

                   if (Util.isNULL(l<xsl:value-of select="$contextName"/>))
                   {
                       DataRow row = DataBase.SelectID(ID, "[<xsl:value-of select="$contextName"/>]");
                       if (Util.isNULL(row))
                           return null;
                       l<xsl:value-of select="$contextName"/> = this.FillFields(row);
                       LoadedMap.Add(l<xsl:value-of select="$contextName"/>.ID, l<xsl:value-of select="$contextName"/>);
                   }
                   return l<xsl:value-of select="$contextName"/>;
               }


               //--------------------------------------------------------------------
               private <xsl:value-of select="$contextName"/> FillFields(DataRow pDataRow)
               {
                   <xsl:value-of select="$contextName"/> l<xsl:value-of select="$contextName"/> = new <xsl:value-of select="$contextName"/>();

                   <xsl:for-each select=".//Attribute">
                    <xsl:variable name="type" select=".//DataType/@Name"/>
                    <xsl:choose>
                      <xsl:when test="$type='boolean'">
                        l<xsl:value-of select="$contextName"/>.<xsl:value-of select="uFN:first-upper(./@Name)"/> = (bool)pDataRow["<xsl:value-of select="@Name"/>"];
                      </xsl:when>
                      <xsl:otherwise>
                        l<xsl:value-of select="$contextName"/>.<xsl:value-of select="uFN:first-upper(./@Name)"/> = (<xsl:value-of select="$type"/>)pDataRow["<xsl:value-of select="@Name"/>"];
                      </xsl:otherwise>
                    </xsl:choose>
                 	</xsl:for-each>


                   l<xsl:value-of select="$contextName"/>.ID = new Guid(pDataRow["iD"].ToString());
                   return l<xsl:value-of select="$contextName"/>;
               }

               //--------------------------------------------------------------------
               public DataTable FindAll()
               {
                   return DataBase.SelectTable("[<xsl:value-of select="$contextName"/>]", "");
               }

               //---------------------------------------------------------------------
               private void FillArray(ref string[] pCols, ref string[] pValues, <xsl:value-of select="$contextName"/> p<xsl:value-of select="$contextName"/>, bool pIsInsertID)
               {
                   int liCpt = 0;
                   int liNombre = <xsl:value-of select="count(.//Attribute)" />;
                   if (pIsInsertID)
                   {
                       pCols = new string[liNombre + 1];
                       pValues = new string[liNombre + 1];
                       pCols[liCpt] = "iD";
                       pValues[liCpt++] = "'" + p<xsl:value-of select="$contextName"/>.ID.ToString() + "'";
                   }
                   else
                   {
                       pCols = new string[liNombre];
                       pValues = new string[liNombre];
                   }

                   <xsl:for-each select=".//Attribute">
                    <xsl:variable name="type" select=".//DataType/@Name"/>
                    <xsl:choose>

                      <xsl:when test="$type='string'">
                        pCols[liCpt] = "<xsl:value-of select="@Name"/>";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(p<xsl:value-of select="$contextName"/>.<xsl:value-of select="uFN:first-upper(./@Name)"/>) + "'";
                      </xsl:when>

                      <xsl:when test="$type='float'">
                        pCols[liCpt] = "<xsl:value-of select="@Name"/>";
                        pValues[liCpt++] = "'" + p<xsl:value-of select="$contextName"/>.<xsl:value-of select="uFN:first-upper(./@Name)"/>.ToString() + "'";
                      </xsl:when>

                      <xsl:when test="$type='int'">
                        pCols[liCpt] = "<xsl:value-of select="@Name"/>";
                        pValues[liCpt++] = "'" + p<xsl:value-of select="$contextName"/>.<xsl:value-of select="uFN:first-upper(./@Name)"/>.ToString() + "'";
                      </xsl:when>

                      <xsl:when test="$type='boolean'">
                        pCols[liCpt] = "<xsl:value-of select="@Name"/>";
                        pValues[liCpt++] = "'" + p<xsl:value-of select="$contextName"/>.<xsl:value-of select="uFN:first-upper(./@Name)"/>.ToString() + "'";
                      </xsl:when>

                      <xsl:otherwise>
                        pCols[liCpt] = "<xsl:value-of select="@Name"/>";
                        pValues[liCpt++] = "'" + p<xsl:value-of select="$contextName"/>.<xsl:value-of select="uFN:first-upper(./@Name)"/>.ToString() + "'";
                      </xsl:otherwise>
                    </xsl:choose>
                 	</xsl:for-each>

               }

               //----------------------------------------------------------------------------------------
               public int Delete(<xsl:value-of select="$contextName"/> p<xsl:value-of select="$contextName"/>)
               {
                   return DataBase.DeleteID(p<xsl:value-of select="$contextName"/>.ID, "[<xsl:value-of select="$contextName"/>]");
               }

               //--------------------------------------------------------------------

               public int Insert(<xsl:value-of select="$contextName"/> p<xsl:value-of select="$contextName"/>)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;
                   this.FillArray(ref lsCols, ref lsValues, p<xsl:value-of select="$contextName"/>, true);
                   return DataBase.Insert("[<xsl:value-of select="$contextName"/>]", lsCols, lsValues);
               }


               //---------------------------------------------------------------------
               public int Update(<xsl:value-of select="$contextName"/> p<xsl:value-of select="$contextName"/>)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;

                   this.FillArray(ref lsCols, ref lsValues, p<xsl:value-of select="$contextName"/>, false);
                   return DataBase.UpdateID("<xsl:value-of select="$contextName"/>", lsCols, lsValues, p<xsl:value-of select="$contextName"/>.ID);
               }

           }
       }

       </xsl:result-document>
     </xsl:for-each>
     </xsl:for-each>
</xsl:template>
</xsl:stylesheet>
