
       using System;
       using System.Collections.Generic;
       using System.Linq;
       using System.Text;
       using System.Data;
       using TP3_genie_noel.Logique;

       namespace TP3_genie_noel.AccesDonnees.MSSQL
       {
           public class InstallationMapper : AbstractMapper, IInstallationMapper
           {

               public InstallationMapper()
               {
               }

               //--------------------------------------------------------------------
               public Installation Find(Guid ID)
               {
                   Installation lInstallation = (Installation)AbstractFind(ID);

                   if (Util.isNULL(lInstallation))
                   {
                       DataRow row = DataBase.SelectID(ID, "[Installation]");
                       if (Util.isNULL(row))
                           return null;
                       lInstallation = this.FillFields(row);
                       LoadedMap.Add(lInstallation.ID, lInstallation);
                   }
                   return lInstallation;
               }


               //--------------------------------------------------------------------
               private Installation FillFields(DataRow pDataRow)
               {
                   Installation lInstallation = new Installation();

                   
                        lInstallation.Numero = (int)pDataRow["numero"];
                      
                        lInstallation.Date_programmation = (string)pDataRow["date_programmation"];
                      
                        lInstallation.Date_realisation = (string)pDataRow["date_realisation"];
                      
                        lInstallation.Frais = (float)pDataRow["frais"];
                      
                        lInstallation.IDClient = (string)pDataRow["iDClient"];
                      


                   lInstallation.ID = new Guid(pDataRow["iD"].ToString());
                   return lInstallation;
               }

               //--------------------------------------------------------------------
               public DataTable FindAll()
               {
                   return DataBase.SelectTable("[Installation]", "");
               }

               //---------------------------------------------------------------------
               private void FillArray(ref string[] pCols, ref string[] pValues, Installation pInstallation, bool pIsInsertID)
               {
                   int liCpt = 0;
                   int liNombre = 5;
                   if (pIsInsertID)
                   {
                       pCols = new string[liNombre + 1];
                       pValues = new string[liNombre + 1];
                       pCols[liCpt] = "iD";
                       pValues[liCpt++] = "'" + pInstallation.ID.ToString() + "'";
                   }
                   else
                   {
                       pCols = new string[liNombre];
                       pValues = new string[liNombre];
                   }

                   
                        pCols[liCpt] = "numero";
                        pValues[liCpt++] = "'" + pInstallation.Numero.ToString() + "'";
                      
                        pCols[liCpt] = "date_programmation";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pInstallation.Date_programmation) + "'";
                      
                        pCols[liCpt] = "date_realisation";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pInstallation.Date_realisation) + "'";
                      
                        pCols[liCpt] = "frais";
                        pValues[liCpt++] = "'" + pInstallation.Frais.ToString() + "'";
                      
                        pCols[liCpt] = "iDClient";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pInstallation.IDClient) + "'";
                      

               }

               //----------------------------------------------------------------------------------------
               public int Delete(Installation pInstallation)
               {
                   return DataBase.DeleteID(pInstallation.ID, "[Installation]");
               }

               //--------------------------------------------------------------------

               public int Insert(Installation pInstallation)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;
                   this.FillArray(ref lsCols, ref lsValues, pInstallation, true);
                   return DataBase.Insert("[Installation]", lsCols, lsValues);
               }


               //---------------------------------------------------------------------
               public int Update(Installation pInstallation)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;

                   this.FillArray(ref lsCols, ref lsValues, pInstallation, false);
                   return DataBase.UpdateID("Installation", lsCols, lsValues, pInstallation.ID);
               }

           }
       }

       