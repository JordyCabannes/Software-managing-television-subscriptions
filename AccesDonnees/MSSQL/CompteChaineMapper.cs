
       using System;
       using System.Collections.Generic;
       using System.Linq;
       using System.Text;
       using System.Data;
       using TP3_genie_noel.Logique;

       namespace TP3_genie_noel.AccesDonnees.MSSQL
       {
           public class CompteChaineMapper : AbstractMapper, ICompteChaineMapper
           {

               public CompteChaineMapper()
               {
               }

               //--------------------------------------------------------------------
               public CompteChaine Find(Guid ID)
               {
                   CompteChaine lCompteChaine = (CompteChaine)AbstractFind(ID);

                   if (Util.isNULL(lCompteChaine))
                   {
                       DataRow row = DataBase.SelectID(ID, "[CompteChaine]");
                       if (Util.isNULL(row))
                           return null;
                       lCompteChaine = this.FillFields(row);
                       LoadedMap.Add(lCompteChaine.ID, lCompteChaine);
                   }
                   return lCompteChaine;
               }


               //--------------------------------------------------------------------
               private CompteChaine FillFields(DataRow pDataRow)
               {
                   CompteChaine lCompteChaine = new CompteChaine();

                   
                        lCompteChaine.Id_compte = (string)pDataRow["id_compte"];
                      
                        lCompteChaine.Id_chaine = (string)pDataRow["id_chaine"];
                      


                   lCompteChaine.ID = new Guid(pDataRow["iD"].ToString());
                   return lCompteChaine;
               }

               //--------------------------------------------------------------------
               public DataTable FindAll()
               {
                   return DataBase.SelectTable("[CompteChaine]", "");
               }

               //---------------------------------------------------------------------
               private void FillArray(ref string[] pCols, ref string[] pValues, CompteChaine pCompteChaine, bool pIsInsertID)
               {
                   int liCpt = 0;
                   int liNombre = 2;
                   if (pIsInsertID)
                   {
                       pCols = new string[liNombre + 1];
                       pValues = new string[liNombre + 1];
                       pCols[liCpt] = "iD";
                       pValues[liCpt++] = "'" + pCompteChaine.ID.ToString() + "'";
                   }
                   else
                   {
                       pCols = new string[liNombre];
                       pValues = new string[liNombre];
                   }

                   
                        pCols[liCpt] = "id_compte";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pCompteChaine.Id_compte) + "'";
                      
                        pCols[liCpt] = "id_chaine";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pCompteChaine.Id_chaine) + "'";
                      

               }

               //----------------------------------------------------------------------------------------
               public int Delete(CompteChaine pCompteChaine)
               {
                   return DataBase.DeleteID(pCompteChaine.ID, "[CompteChaine]");
               }

               //--------------------------------------------------------------------

               public int Insert(CompteChaine pCompteChaine)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;
                   this.FillArray(ref lsCols, ref lsValues, pCompteChaine, true);
                   return DataBase.Insert("[CompteChaine]", lsCols, lsValues);
               }


               //---------------------------------------------------------------------
               public int Update(CompteChaine pCompteChaine)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;

                   this.FillArray(ref lsCols, ref lsValues, pCompteChaine, false);
                   return DataBase.UpdateID("CompteChaine", lsCols, lsValues, pCompteChaine.ID);
               }

           }
       }

       