
       using System;
       using System.Collections.Generic;
       using System.Linq;
       using System.Text;
       using System.Data;
       using TP3_genie_noel.Logique;

       namespace TP3_genie_noel.AccesDonnees.MSSQL
       {
           public class ServiceChaineMapper : AbstractMapper, IServiceChaineMapper
           {

               public ServiceChaineMapper()
               {
               }

               //--------------------------------------------------------------------
               public ServiceChaine Find(Guid ID)
               {
                   ServiceChaine lServiceChaine = (ServiceChaine)AbstractFind(ID);

                   if (Util.isNULL(lServiceChaine))
                   {
                       DataRow row = DataBase.SelectID(ID, "[ServiceChaine]");
                       if (Util.isNULL(row))
                           return null;
                       lServiceChaine = this.FillFields(row);
                       LoadedMap.Add(lServiceChaine.ID, lServiceChaine);
                   }
                   return lServiceChaine;
               }


               //--------------------------------------------------------------------
               private ServiceChaine FillFields(DataRow pDataRow)
               {
                   ServiceChaine lServiceChaine = new ServiceChaine();

                   
                        lServiceChaine.Id_service = (string)pDataRow["id_service"];
                      
                        lServiceChaine.Id_compte = (string)pDataRow["id_compte"];
                      


                   lServiceChaine.ID = new Guid(pDataRow["iD"].ToString());
                   return lServiceChaine;
               }

               //--------------------------------------------------------------------
               public DataTable FindAll()
               {
                   return DataBase.SelectTable("[ServiceChaine]", "");
               }

               //---------------------------------------------------------------------
               private void FillArray(ref string[] pCols, ref string[] pValues, ServiceChaine pServiceChaine, bool pIsInsertID)
               {
                   int liCpt = 0;
                   int liNombre = 2;
                   if (pIsInsertID)
                   {
                       pCols = new string[liNombre + 1];
                       pValues = new string[liNombre + 1];
                       pCols[liCpt] = "iD";
                       pValues[liCpt++] = "'" + pServiceChaine.ID.ToString() + "'";
                   }
                   else
                   {
                       pCols = new string[liNombre];
                       pValues = new string[liNombre];
                   }

                   
                        pCols[liCpt] = "id_service";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pServiceChaine.Id_service) + "'";
                      
                        pCols[liCpt] = "id_compte";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pServiceChaine.Id_compte) + "'";
                      

               }

               //----------------------------------------------------------------------------------------
               public int Delete(ServiceChaine pServiceChaine)
               {
                   return DataBase.DeleteID(pServiceChaine.ID, "[ServiceChaine]");
               }

               //--------------------------------------------------------------------

               public int Insert(ServiceChaine pServiceChaine)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;
                   this.FillArray(ref lsCols, ref lsValues, pServiceChaine, true);
                   return DataBase.Insert("[ServiceChaine]", lsCols, lsValues);
               }


               //---------------------------------------------------------------------
               public int Update(ServiceChaine pServiceChaine)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;

                   this.FillArray(ref lsCols, ref lsValues, pServiceChaine, false);
                   return DataBase.UpdateID("ServiceChaine", lsCols, lsValues, pServiceChaine.ID);
               }

           }
       }

       