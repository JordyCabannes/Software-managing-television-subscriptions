
       using System;
       using System.Collections.Generic;
       using System.Linq;
       using System.Text;
       using System.Data;
       using TP3_genie_noel.Logique;

       namespace TP3_genie_noel.AccesDonnees.MSSQL
       {
           public class ServiceDiffusionMapper : AbstractMapper, IServiceDiffusionMapper
           {

               public ServiceDiffusionMapper()
               {
               }

               //--------------------------------------------------------------------
               public ServiceDiffusion Find(Guid ID)
               {
                   ServiceDiffusion lServiceDiffusion = (ServiceDiffusion)AbstractFind(ID);

                   if (Util.isNULL(lServiceDiffusion))
                   {
                       DataRow row = DataBase.SelectID(ID, "[ServiceDiffusion]");
                       if (Util.isNULL(row))
                           return null;
                       lServiceDiffusion = this.FillFields(row);
                       LoadedMap.Add(lServiceDiffusion.ID, lServiceDiffusion);
                   }
                   return lServiceDiffusion;
               }


               //--------------------------------------------------------------------
               private ServiceDiffusion FillFields(DataRow pDataRow)
               {
                   ServiceDiffusion lServiceDiffusion = new ServiceDiffusion();

                   
                        lServiceDiffusion.Numero = (int)pDataRow["numero"];
                      
                        lServiceDiffusion.Nom = (string)pDataRow["nom"];
                      


                   lServiceDiffusion.ID = new Guid(pDataRow["iD"].ToString());
                   return lServiceDiffusion;
               }

               //--------------------------------------------------------------------
               public DataTable FindAll()
               {
                   return DataBase.SelectTable("[ServiceDiffusion]", "");
               }

               //---------------------------------------------------------------------
               private void FillArray(ref string[] pCols, ref string[] pValues, ServiceDiffusion pServiceDiffusion, bool pIsInsertID)
               {
                   int liCpt = 0;
                   int liNombre = 2;
                   if (pIsInsertID)
                   {
                       pCols = new string[liNombre + 1];
                       pValues = new string[liNombre + 1];
                       pCols[liCpt] = "iD";
                       pValues[liCpt++] = "'" + pServiceDiffusion.ID.ToString() + "'";
                   }
                   else
                   {
                       pCols = new string[liNombre];
                       pValues = new string[liNombre];
                   }

                   
                        pCols[liCpt] = "numero";
                        pValues[liCpt++] = "'" + pServiceDiffusion.Numero.ToString() + "'";
                      
                        pCols[liCpt] = "nom";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pServiceDiffusion.Nom) + "'";
                      

               }

               //----------------------------------------------------------------------------------------
               public int Delete(ServiceDiffusion pServiceDiffusion)
               {
                   return DataBase.DeleteID(pServiceDiffusion.ID, "[ServiceDiffusion]");
               }

               //--------------------------------------------------------------------

               public int Insert(ServiceDiffusion pServiceDiffusion)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;
                   this.FillArray(ref lsCols, ref lsValues, pServiceDiffusion, true);
                   return DataBase.Insert("[ServiceDiffusion]", lsCols, lsValues);
               }


               //---------------------------------------------------------------------
               public int Update(ServiceDiffusion pServiceDiffusion)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;

                   this.FillArray(ref lsCols, ref lsValues, pServiceDiffusion, false);
                   return DataBase.UpdateID("ServiceDiffusion", lsCols, lsValues, pServiceDiffusion.ID);
               }

           }
       }

       