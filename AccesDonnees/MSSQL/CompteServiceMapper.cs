
       using System;
       using System.Collections.Generic;
       using System.Linq;
       using System.Text;
       using System.Data;
       using TP3_genie_noel.Logique;

       namespace TP3_genie_noel.AccesDonnees.MSSQL
       {
           public class CompteServiceMapper : AbstractMapper, ICompteServiceMapper
           {

               public CompteServiceMapper()
               {
               }

               //--------------------------------------------------------------------
               public CompteService Find(Guid ID)
               {
                   CompteService lCompteService = (CompteService)AbstractFind(ID);

                   if (Util.isNULL(lCompteService))
                   {
                       DataRow row = DataBase.SelectID(ID, "[CompteService]");
                       if (Util.isNULL(row))
                           return null;
                       lCompteService = this.FillFields(row);
                       LoadedMap.Add(lCompteService.ID, lCompteService);
                   }
                   return lCompteService;
               }


               //--------------------------------------------------------------------
               private CompteService FillFields(DataRow pDataRow)
               {
                   CompteService lCompteService = new CompteService();

                   
                        lCompteService.Id_compe = (string)pDataRow["id_compe"];
                      
                        lCompteService.Id_service = (string)pDataRow["id_service"];
                      


                   lCompteService.ID = new Guid(pDataRow["iD"].ToString());
                   return lCompteService;
               }

               //--------------------------------------------------------------------
               public DataTable FindAll()
               {
                   return DataBase.SelectTable("[CompteService]", "");
               }

               //---------------------------------------------------------------------
               private void FillArray(ref string[] pCols, ref string[] pValues, CompteService pCompteService, bool pIsInsertID)
               {
                   int liCpt = 0;
                   int liNombre = 2;
                   if (pIsInsertID)
                   {
                       pCols = new string[liNombre + 1];
                       pValues = new string[liNombre + 1];
                       pCols[liCpt] = "iD";
                       pValues[liCpt++] = "'" + pCompteService.ID.ToString() + "'";
                   }
                   else
                   {
                       pCols = new string[liNombre];
                       pValues = new string[liNombre];
                   }

                   
                        pCols[liCpt] = "id_compe";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pCompteService.Id_compe) + "'";
                      
                        pCols[liCpt] = "id_service";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pCompteService.Id_service) + "'";
                      

               }

               //----------------------------------------------------------------------------------------
               public int Delete(CompteService pCompteService)
               {
                   return DataBase.DeleteID(pCompteService.ID, "[CompteService]");
               }

               //--------------------------------------------------------------------

               public int Insert(CompteService pCompteService)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;
                   this.FillArray(ref lsCols, ref lsValues, pCompteService, true);
                   return DataBase.Insert("[CompteService]", lsCols, lsValues);
               }


               //---------------------------------------------------------------------
               public int Update(CompteService pCompteService)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;

                   this.FillArray(ref lsCols, ref lsValues, pCompteService, false);
                   return DataBase.UpdateID("CompteService", lsCols, lsValues, pCompteService.ID);
               }

           }
       }

       