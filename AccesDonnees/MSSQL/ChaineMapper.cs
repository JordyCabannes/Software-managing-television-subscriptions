
       using System;
       using System.Collections.Generic;
       using System.Linq;
       using System.Text;
       using System.Data;
       using TP3_genie_noel.Logique;

       namespace TP3_genie_noel.AccesDonnees.MSSQL
       {
           public class ChaineMapper : AbstractMapper, IChaineMapper
           {

               public ChaineMapper()
               {
               }

               //--------------------------------------------------------------------
               public Chaine Find(Guid ID)
               {
                   Chaine lChaine = (Chaine)AbstractFind(ID);

                   if (Util.isNULL(lChaine))
                   {
                       DataRow row = DataBase.SelectID(ID, "[Chaine]");
                       if (Util.isNULL(row))
                           return null;
                       lChaine = this.FillFields(row);
                       LoadedMap.Add(lChaine.ID, lChaine);
                   }
                   return lChaine;
               }


               //--------------------------------------------------------------------
               private Chaine FillFields(DataRow pDataRow)
               {
                   Chaine lChaine = new Chaine();

                   
                        lChaine.Numero = (int)pDataRow["numero"];
                      
                        lChaine.Sigle = (string)pDataRow["sigle"];
                      
                        lChaine.Nom = (string)pDataRow["nom"];
                      
                        lChaine.Nature = (string)pDataRow["nature"];
                      
                        lChaine.Prix = (float)pDataRow["prix"];
                      


                   lChaine.ID = new Guid(pDataRow["iD"].ToString());
                   return lChaine;
               }

               //--------------------------------------------------------------------
               public DataTable FindAll()
               {
                   return DataBase.SelectTable("[Chaine]", "");
               }

               //---------------------------------------------------------------------
               private void FillArray(ref string[] pCols, ref string[] pValues, Chaine pChaine, bool pIsInsertID)
               {
                   int liCpt = 0;
                   int liNombre = 5;
                   if (pIsInsertID)
                   {
                       pCols = new string[liNombre + 1];
                       pValues = new string[liNombre + 1];
                       pCols[liCpt] = "iD";
                       pValues[liCpt++] = "'" + pChaine.ID.ToString() + "'";
                   }
                   else
                   {
                       pCols = new string[liNombre];
                       pValues = new string[liNombre];
                   }

                   
                        pCols[liCpt] = "numero";
                        pValues[liCpt++] = "'" + pChaine.Numero.ToString() + "'";
                      
                        pCols[liCpt] = "sigle";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pChaine.Sigle) + "'";
                      
                        pCols[liCpt] = "nom";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pChaine.Nom) + "'";
                      
                        pCols[liCpt] = "nature";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pChaine.Nature) + "'";
                      
                        pCols[liCpt] = "prix";
                        pValues[liCpt++] = "'" + pChaine.Prix.ToString() + "'";
                      

               }

               //----------------------------------------------------------------------------------------
               public int Delete(Chaine pChaine)
               {
                   return DataBase.DeleteID(pChaine.ID, "[Chaine]");
               }

               //--------------------------------------------------------------------

               public int Insert(Chaine pChaine)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;
                   this.FillArray(ref lsCols, ref lsValues, pChaine, true);
                   return DataBase.Insert("[Chaine]", lsCols, lsValues);
               }


               //---------------------------------------------------------------------
               public int Update(Chaine pChaine)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;

                   this.FillArray(ref lsCols, ref lsValues, pChaine, false);
                   return DataBase.UpdateID("Chaine", lsCols, lsValues, pChaine.ID);
               }

           }
       }

       