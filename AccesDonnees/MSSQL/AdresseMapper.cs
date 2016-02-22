
       using System;
       using System.Collections.Generic;
       using System.Linq;
       using System.Text;
       using System.Data;
       using TP3_genie_noel.Logique;

       namespace TP3_genie_noel.AccesDonnees.MSSQL
       {
           public class AdresseMapper : AbstractMapper, IAdresseMapper
           {

               public AdresseMapper()
               {
               }

               //--------------------------------------------------------------------
               public Adresse Find(Guid ID)
               {
                   Adresse lAdresse = (Adresse)AbstractFind(ID);

                   if (Util.isNULL(lAdresse))
                   {
                       DataRow row = DataBase.SelectID(ID, "[Adresse]");
                       if (Util.isNULL(row))
                           return null;
                       lAdresse = this.FillFields(row);
                       LoadedMap.Add(lAdresse.ID, lAdresse);
                   }
                   return lAdresse;
               }


               //--------------------------------------------------------------------
               private Adresse FillFields(DataRow pDataRow)
               {
                   Adresse lAdresse = new Adresse();

                   
                        lAdresse.Adresse_branchement = (string)pDataRow["adresse_branchement"];
                      
                        lAdresse.Branchee = (bool)pDataRow["branchee"];
                      


                   lAdresse.ID = new Guid(pDataRow["iD"].ToString());
                   return lAdresse;
               }

               //--------------------------------------------------------------------
               public DataTable FindAll()
               {
                   return DataBase.SelectTable("[Adresse]", "");
               }

               //---------------------------------------------------------------------
               private void FillArray(ref string[] pCols, ref string[] pValues, Adresse pAdresse, bool pIsInsertID)
               {
                   int liCpt = 0;
                   int liNombre = 2;
                   if (pIsInsertID)
                   {
                       pCols = new string[liNombre + 1];
                       pValues = new string[liNombre + 1];
                       pCols[liCpt] = "iD";
                       pValues[liCpt++] = "'" + pAdresse.ID.ToString() + "'";
                   }
                   else
                   {
                       pCols = new string[liNombre];
                       pValues = new string[liNombre];
                   }

                   
                        pCols[liCpt] = "adresse_branchement";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pAdresse.Adresse_branchement) + "'";
                      
                        pCols[liCpt] = "branchee";
                        pValues[liCpt++] = "'" + pAdresse.Branchee.ToString() + "'";
                      

               }

               //----------------------------------------------------------------------------------------
               public int Delete(Adresse pAdresse)
               {
                   return DataBase.DeleteID(pAdresse.ID, "[Adresse]");
               }

               //--------------------------------------------------------------------

               public int Insert(Adresse pAdresse)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;
                   this.FillArray(ref lsCols, ref lsValues, pAdresse, true);
                   return DataBase.Insert("[Adresse]", lsCols, lsValues);
               }


               //---------------------------------------------------------------------
               public int Update(Adresse pAdresse)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;

                   this.FillArray(ref lsCols, ref lsValues, pAdresse, false);
                   return DataBase.UpdateID("Adresse", lsCols, lsValues, pAdresse.ID);
               }

           }
       }

       