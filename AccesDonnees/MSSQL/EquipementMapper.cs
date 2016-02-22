
       using System;
       using System.Collections.Generic;
       using System.Linq;
       using System.Text;
       using System.Data;
       using TP3_genie_noel.Logique;

       namespace TP3_genie_noel.AccesDonnees.MSSQL
       {
           public class EquipementMapper : AbstractMapper, IEquipementMapper
           {

               public EquipementMapper()
               {
               }

               //--------------------------------------------------------------------
               public Equipement Find(Guid ID)
               {
                   Equipement lEquipement = (Equipement)AbstractFind(ID);

                   if (Util.isNULL(lEquipement))
                   {
                       DataRow row = DataBase.SelectID(ID, "[Equipement]");
                       if (Util.isNULL(row))
                           return null;
                       lEquipement = this.FillFields(row);
                       LoadedMap.Add(lEquipement.ID, lEquipement);
                   }
                   return lEquipement;
               }


               //--------------------------------------------------------------------
               private Equipement FillFields(DataRow pDataRow)
               {
                   Equipement lEquipement = new Equipement();

                   
                        lEquipement.Numero = (int)pDataRow["numero"];
                      
                        lEquipement.Nom = (string)pDataRow["nom"];
                      
                        lEquipement.Tarif_mensuel_de_location = (float)pDataRow["tarif_mensuel_de_location"];
                      
                        lEquipement.IDCompte = (string)pDataRow["iDCompte"];
                      


                   lEquipement.ID = new Guid(pDataRow["iD"].ToString());
                   return lEquipement;
               }

               //--------------------------------------------------------------------
               public DataTable FindAll()
               {
                   return DataBase.SelectTable("[Equipement]", "");
               }

               //---------------------------------------------------------------------
               private void FillArray(ref string[] pCols, ref string[] pValues, Equipement pEquipement, bool pIsInsertID)
               {
                   int liCpt = 0;
                   int liNombre = 4;
                   if (pIsInsertID)
                   {
                       pCols = new string[liNombre + 1];
                       pValues = new string[liNombre + 1];
                       pCols[liCpt] = "iD";
                       pValues[liCpt++] = "'" + pEquipement.ID.ToString() + "'";
                   }
                   else
                   {
                       pCols = new string[liNombre];
                       pValues = new string[liNombre];
                   }

                   
                        pCols[liCpt] = "numero";
                        pValues[liCpt++] = "'" + pEquipement.Numero.ToString() + "'";
                      
                        pCols[liCpt] = "nom";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pEquipement.Nom) + "'";
                      
                        pCols[liCpt] = "tarif_mensuel_de_location";
                        pValues[liCpt++] = "'" + pEquipement.Tarif_mensuel_de_location.ToString() + "'";
                      
                        pCols[liCpt] = "iDCompte";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pEquipement.IDCompte) + "'";
                      

               }

               //----------------------------------------------------------------------------------------
               public int Delete(Equipement pEquipement)
               {
                   return DataBase.DeleteID(pEquipement.ID, "[Equipement]");
               }

               //--------------------------------------------------------------------

               public int Insert(Equipement pEquipement)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;
                   this.FillArray(ref lsCols, ref lsValues, pEquipement, true);
                   return DataBase.Insert("[Equipement]", lsCols, lsValues);
               }


               //---------------------------------------------------------------------
               public int Update(Equipement pEquipement)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;

                   this.FillArray(ref lsCols, ref lsValues, pEquipement, false);
                   return DataBase.UpdateID("Equipement", lsCols, lsValues, pEquipement.ID);
               }

           }
       }

       