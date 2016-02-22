
       using System;
       using System.Collections.Generic;
       using System.Linq;
       using System.Text;
       using System.Data;
       using TP3_genie_noel.Logique;

       namespace TP3_genie_noel.AccesDonnees.MSSQL
       {
           public class ClientMapper : AbstractMapper, IClientMapper
           {

               public ClientMapper()
               {
               }

               //--------------------------------------------------------------------
               public Client Find(Guid ID)
               {
                   Client lClient = (Client)AbstractFind(ID);

                   if (Util.isNULL(lClient))
                   {
                       DataRow row = DataBase.SelectID(ID, "[Client]");
                       if (Util.isNULL(row))
                           return null;
                       lClient = this.FillFields(row);
                       LoadedMap.Add(lClient.ID, lClient);
                   }
                   return lClient;
               }


               //--------------------------------------------------------------------
               private Client FillFields(DataRow pDataRow)
               {
                   Client lClient = new Client();

                   
                        lClient.Numero = (int)pDataRow["numero"];
                      
                        lClient.Pseudo = (string)pDataRow["pseudo"];
                      
                        lClient.Mot_de_passe = (string)pDataRow["mot_de_passe"];
                      
                        lClient.Nom = (string)pDataRow["nom"];
                      
                        lClient.Prenom = (string)pDataRow["prenom"];
                      
                        lClient.Raison_sociale = (string)pDataRow["raison_sociale"];
                      
                        lClient.Adresse = (string)pDataRow["adresse"];
                      
                        lClient.Telephone = (string)pDataRow["telephone"];
                      


                   lClient.ID = new Guid(pDataRow["iD"].ToString());
                   return lClient;
               }

               //--------------------------------------------------------------------
               public DataTable FindAll()
               {
                   return DataBase.SelectTable("[Client]", "");
               }

               //---------------------------------------------------------------------
               private void FillArray(ref string[] pCols, ref string[] pValues, Client pClient, bool pIsInsertID)
               {
                   int liCpt = 0;
                   int liNombre = 8;
                   if (pIsInsertID)
                   {
                       pCols = new string[liNombre + 1];
                       pValues = new string[liNombre + 1];
                       pCols[liCpt] = "iD";
                       pValues[liCpt++] = "'" + pClient.ID.ToString() + "'";
                   }
                   else
                   {
                       pCols = new string[liNombre];
                       pValues = new string[liNombre];
                   }

                   
                        pCols[liCpt] = "numero";
                        pValues[liCpt++] = "'" + pClient.Numero.ToString() + "'";
                      
                        pCols[liCpt] = "pseudo";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pClient.Pseudo) + "'";
                      
                        pCols[liCpt] = "mot_de_passe";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pClient.Mot_de_passe) + "'";
                      
                        pCols[liCpt] = "nom";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pClient.Nom) + "'";
                      
                        pCols[liCpt] = "prenom";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pClient.Prenom) + "'";
                      
                        pCols[liCpt] = "raison_sociale";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pClient.Raison_sociale) + "'";
                      
                        pCols[liCpt] = "adresse";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pClient.Adresse) + "'";
                      
                        pCols[liCpt] = "telephone";
                        pValues[liCpt++] = "'" + Util.DoubleQuote(pClient.Telephone) + "'";
                      

               }

               //----------------------------------------------------------------------------------------
               public int Delete(Client pClient)
               {
                   return DataBase.DeleteID(pClient.ID, "[Client]");
               }

               //--------------------------------------------------------------------

               public int Insert(Client pClient)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;
                   this.FillArray(ref lsCols, ref lsValues, pClient, true);
                   return DataBase.Insert("[Client]", lsCols, lsValues);
               }


               //---------------------------------------------------------------------
               public int Update(Client pClient)
               {
                   string[] lsCols = null;
                   string[] lsValues = null;

                   this.FillArray(ref lsCols, ref lsValues, pClient, false);
                   return DataBase.UpdateID("Client", lsCols, lsValues, pClient.ID);
               }

           }
       }

       