
       using System;
       using System.Collections.Generic;
       using System.Linq;
       using System.Text;
       using System.Data;
       using TP3_genie_noel.Logique;

       namespace TP3_genie_noel.AccesDonnees.MSSQL
       {
           public class CompteMapper : AbstractMapper, ICompteMapper
           {

               public CompteMapper()
               {
               }

               //--------------------------------------------------------------------
               public Compte Find(Guid ID)
               {
                   Compte lCompte = (Compte)AbstractFind(ID);

                   if (Util.isNULL(lCompte))
                   {
                       DataRow row = DataBase.SelectID(ID, "[Compte]");
                       if (Util.isNULL(row))
                           return null;
                       lCompte = this.FillFields(row);
                       LoadedMap.Add(lCompte.ID, lCompte);
                   }
                   return lCompte;
               }


               //--------------------------------------------------------------------
               private Compte FillFields(DataRow pDataRow)
               {
                   Compte lCompte = new Compte();

                   
                        lCompte.Numero = (int)pDataRow["numero"];
                      
                        lCompte.Mode_de_facturation = (string)pDataRow["mode_de_facturation"];
                      
                        lCompte.Solde = (float)pDataRow["solde"];
                      
                        lCompte.Total_du_mois = (float)pDataRow["total_du_mois"];
                      
                        lCompte.IDClient = (string)pDataRow["iDClient"];
                      


                   lCompte.ID = new Guid(pDataRow["iD"].ToString());
                   return lCompte;
               }

               //--------------------------------------------------------------------
               public DataTable FindAll()
               {
                   return DataBase.SelectTable("[Compte]", "");
               }

               //---------------------------------------------------------------------
               private void FillArray(ref string[] pCols, ref string[] pValues, Compte pCompte, bool pIsInsertID)
               {
                   int liCpt = 0;
                   int liNombre = 5;
                   if (pIsInsertID)
                   {
                       pCols = new string[liNombre + 1];
                       pValues = new string[liNombre + 1];
                       pCols[liCpt] = "iD";
                       pValues[liCpt++] = "'" + pCompte.ID.ToString() + "'";
                   }
                   else
                   {
                       pCols = new string[liNombre];
                       pValues = new string[liNombre];
                   }

                   
                        pCols[liCpt] = "numero";
                        pValues[liCpt++] = "'" + pCompte.Numero.ToString() + "'";
                      
                        pCols[liCpt] = "mode_de_facturation";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pCompte.Mode_de_facturation) + "'";
                      
                        pCols[liCpt] = "solde";
                        pValues[liCpt++] = "'" + pCompte.Solde.ToString() + "'";
                      
                        pCols[liCpt] = "total_du_mois";
                        pValues[liCpt++] = "'" + pCompte.Total_du_mois.ToString() + "'";
                      
                        pCols[liCpt] = "iDClient";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pCompte.IDClient) + "'";
                      

               }

               //----------------------------------------------------------------------------------------
               public int Delete(Compte pCompte)
               {
                   return DataBase.DeleteID(pCompte.ID, "[Compte]");
               }

               //--------------------------------------------------------------------

               public int Insert(Compte pCompte)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;
                   this.FillArray(ref lsCols, ref lsValues, pCompte, true);
                   return DataBase.Insert("[Compte]", lsCols, lsValues);
               }


               //---------------------------------------------------------------------
               public int Update(Compte pCompte)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;

                   this.FillArray(ref lsCols, ref lsValues, pCompte, false);
                   return DataBase.UpdateID("Compte", lsCols, lsValues, pCompte.ID);
               }

           }
       }

       