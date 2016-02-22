
       using System;
       using System.Collections.Generic;
       using System.Linq;
       using System.Text;
       using System.Data;
       using TP3_genie_noel.Logique;

       namespace TP3_genie_noel.AccesDonnees.MSSQL
       {
           public class EmployeMapper : AbstractMapper, IEmployeMapper
           {

               public EmployeMapper()
               {
               }

               //--------------------------------------------------------------------
               public Employe Find(Guid ID)
               {
                   Employe lEmploye = (Employe)AbstractFind(ID);

                   if (Util.isNULL(lEmploye))
                   {
                       DataRow row = DataBase.SelectID(ID, "[Employe]");
                       if (Util.isNULL(row))
                           return null;
                       lEmploye = this.FillFields(row);
                       LoadedMap.Add(lEmploye.ID, lEmploye);
                   }
                   return lEmploye;
               }


               //--------------------------------------------------------------------
               private Employe FillFields(DataRow pDataRow)
               {
                   Employe lEmploye = new Employe();

                   
                        lEmploye.Numero = (int)pDataRow["numero"];
                      
                        lEmploye.Pseudo = (string)pDataRow["pseudo"];
                      
                        lEmploye.Mot_de_passe = (string)pDataRow["mot_de_passe"];
                      
                        lEmploye.Nom = (string)pDataRow["nom"];
                      
                        lEmploye.Prenom = (string)pDataRow["prenom"];
                      
                        lEmploye.Adresse = (string)pDataRow["adresse"];
                      
                        lEmploye.Telephone = (string)pDataRow["telephone"];
                      
                        lEmploye.Fonction = (string)pDataRow["fonction"];
                      
                        lEmploye.Salaire = (float)pDataRow["salaire"];
                      


                   lEmploye.ID = new Guid(pDataRow["iD"].ToString());
                   return lEmploye;
               }

               //--------------------------------------------------------------------
               public DataTable FindAll()
               {
                   return DataBase.SelectTable("[Employe]", "");
               }

               //---------------------------------------------------------------------
               private void FillArray(ref string[] pCols, ref string[] pValues, Employe pEmploye, bool pIsInsertID)
               {
                   int liCpt = 0;
                   int liNombre = 9;
                   if (pIsInsertID)
                   {
                       pCols = new string[liNombre + 1];
                       pValues = new string[liNombre + 1];
                       pCols[liCpt] = "iD";
                       pValues[liCpt++] = "'" + pEmploye.ID.ToString() + "'";
                   }
                   else
                   {
                       pCols = new string[liNombre];
                       pValues = new string[liNombre];
                   }

                   
                        pCols[liCpt] = "numero";
                        pValues[liCpt++] = "'" + pEmploye.Numero.ToString() + "'";
                      
                        pCols[liCpt] = "pseudo";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pEmploye.Pseudo) + "'";
                      
                        pCols[liCpt] = "mot_de_passe";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pEmploye.Mot_de_passe) + "'";
                      
                        pCols[liCpt] = "nom";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pEmploye.Nom) + "'";
                      
                        pCols[liCpt] = "prenom";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pEmploye.Prenom) + "'";
                      
                        pCols[liCpt] = "adresse";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pEmploye.Adresse) + "'";
                      
                        pCols[liCpt] = "telephone";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pEmploye.Telephone) + "'";
                      
                        pCols[liCpt] = "fonction";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pEmploye.Fonction) + "'";
                      
                        pCols[liCpt] = "salaire";
                        pValues[liCpt++] = "'" + pEmploye.Salaire.ToString() + "'";
                      

               }

               //----------------------------------------------------------------------------------------
               public int Delete(Employe pEmploye)
               {
                   return DataBase.DeleteID(pEmploye.ID, "[Employe]");
               }

               //--------------------------------------------------------------------

               public int Insert(Employe pEmploye)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;
                   this.FillArray(ref lsCols, ref lsValues, pEmploye, true);
                   return DataBase.Insert("[Employe]", lsCols, lsValues);
               }


               //---------------------------------------------------------------------
               public int Update(Employe pEmploye)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;

                   this.FillArray(ref lsCols, ref lsValues, pEmploye, false);
                   return DataBase.UpdateID("Employe", lsCols, lsValues, pEmploye.ID);
               }

           }
       }

       