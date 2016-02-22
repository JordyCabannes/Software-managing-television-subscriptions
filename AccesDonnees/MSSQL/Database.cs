using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace TP3_genie_noel.AccesDonnees.MSSQL
{
    public static class DataBase
    {
        // Return the DataTable of the SQL Query [psQuery]
        public static DataTable Select(string psQuery)
        {
            try
            {
                SqlDataAdapter lSqlDataAdapter = new SqlDataAdapter(new SqlCommand(psQuery, new SqlConnection(GlobalConfig.getConnectionString())));
                DataTable lDataTable = new DataTable();

                lSqlDataAdapter.Fill(lDataTable);
                return lDataTable;
            }
            catch
            {
                return null;
            }
        }

        // Return a DataTable with all records of Table [psTableName]
        public static DataTable SelectTable(string psTableName, string psOrderBy)
        {
            try
            {
                psTableName = psTableName.Trim();
                if (psTableName == "")
                {
                    return null;
                }
                psOrderBy = " " + psOrderBy.Trim();
                if (psOrderBy != " " && !psOrderBy.ToUpper().Contains("ORDER BY"))
                {
                    psOrderBy = " ORDER BY" + psOrderBy;
                }
                return Select("SELECT * FROM " + psTableName + psOrderBy);
                //SqlDataAdapter lSqlDataAdapter = new SqlDataAdapter(new SqlCommand("SELECT * FROM " + psTableName + psOrderBy, new SqlConnection(pConfig.ConnectionString)));
                //DataTable lDataTable = new DataTable();
                //lSqlDataAdapter.Fill(lDataTable);
                //return lDataTable;
            }
            catch
            {
                return null;
            }
        }

        // Return a DataRow (the first row) of the SQL Query [psQuery}
        public static DataRow SelectRow(string psQuery)
        {
            DataTable lDataTable = Select(psQuery);

            if (!Util.isNULL(lDataTable))
            {
                if (lDataTable.Rows.Count > 0)
                {
                    return lDataTable.Rows[0];
                }
            }
            return null;
        }

        // Return a DataRow (the first row) of the Table [psTableName] where [psWhere]
        public static DataRow SelectRow(string psTableName, string psWhere)
        {
            psTableName = psTableName.Trim();
            if (psTableName == "")
            {
                return null;
            }
            psWhere = " " + psWhere.Trim();
            if (psWhere != " " && !psWhere.ToUpper().Contains("WHERE"))
            {
                psWhere = " WHERE" + psWhere;
            }
            return SelectRow("SELECT TOP 1 * FROM " + psTableName + psWhere);
        }

        // Return a DataRow (the first row) of the Table [psTableName] where ID = [pID]
        public static DataRow SelectID(Guid pID, string psTableName)
        {
            if (Util.isNULL(pID))
            {
                return null;
            }
            psTableName = psTableName.Trim();
            if (psTableName == "")
            {
                return null;
            }
            return SelectRow("SELECT TOP 1 * FROM " + psTableName + " WHERE ID = '" + pID.ToString() + "'");
        }

        public static DataRow SelectID(string psID, string psTableName)
        {
            if (!Util.isValidGuid(psID))
            {
                return null;
            }
            psTableName = psTableName.Trim();
            if (psTableName == "")
            {
                return null;
            }
            return SelectRow("SELECT TOP 1 * FROM " + psTableName + " WHERE ID = '" + psID + "'");
        }

        public static DataRow SelectID(Guid pID, string psIDName, string psTableName)
        {
            if (Util.isNULL(pID))
            {
                return null;
            }
            psTableName = psTableName.Trim();
            if (psTableName == "")
            {
                return null;
            }
            return SelectRow("SELECT TOP 1 * FROM " + psTableName + " WHERE " + psIDName + " = '" + pID.ToString() + "'");
        }

        // Delete everything from the Query [psQuery]
        // Return number of record affected, -1 if operation failed
        public static int Delete(string psQuery)
        {
            try
            {
                int liReturn = int.MinValue;
                SqlCommand lSqlCommand = new SqlCommand(psQuery, new SqlConnection(GlobalConfig.getConnectionString()));

                lSqlCommand.Connection.Open();
                liReturn = lSqlCommand.ExecuteNonQuery();
                lSqlCommand.Connection.Close();
                return liReturn;
            }
            catch
            {
                return int.MinValue;
            }
        }

        // Delete ID [pID] from Table [psTableName]
        // Return number of record affected
        public static int DeleteID(Guid pID, string psTableName)
        {
            if (Util.isNULL(pID))
            {
                return int.MinValue;
            }
            psTableName = psTableName.Trim();
            if (psTableName == "")
            {
                return int.MinValue;
            }
            return Delete("DELETE FROM " + psTableName + " WHERE ID = '" + pID + "'");
        }

        public static int DeleteID(string psID, string psTableName)
        {
            if (!Util.isValidGuid(psID))
            {
                return int.MinValue;
            }
            psTableName = psTableName.Trim();
            if (psTableName == "")
            {
                return int.MinValue;
            }
            return Delete("DELETE FROM " + psTableName + " WHERE ID = '" + psID + "'");
        }

        public static int DeleteID(Guid pID, string psIDName, string psTableName)
        {
            if (Util.isNULL(pID))
            {
                return int.MinValue;
            }
            psTableName = psTableName.Trim();
            if (psTableName == "" || psIDName == "")
            {
                return int.MinValue;
            }
            return Delete("DELETE FROM " + psTableName + " WHERE " + psIDName + " = '" + pID + "'");
        }

        public static int DeleteID(string psID, string psIDName, string psTableName)
        {
            if (!Util.isValidGuid(psID))
            {
                return int.MinValue;
            }
            psTableName = psTableName.Trim();
            if (psTableName == "" || psIDName == "")
            {
                return int.MinValue;
            }
            return Delete("DELETE FROM " + psTableName + " WHERE " + psIDName + " = '" + psID + "'");
        }

        // Delete everything from Table [psTableName]
        // Return number of record affected
        public static int DeleteAll(string psTableName)
        {
            psTableName = psTableName.Trim();
            if (psTableName == "")
            {
                return int.MinValue;
            }
            return Delete("DELETE FROM " + psTableName);
        }

        // Delete ID [pID] from Table [psTableName] Where [psWhere]
        // Return number of record affected
        public static int DeleteRecords(string psTableName, string psWhere)
        {
            psTableName = psTableName.Trim();
            if (psTableName == "")
            {
                return int.MinValue;
            }
            psWhere = " " + psWhere.Trim();
            if (psWhere != " " && !psWhere.ToUpper().Contains("WHERE"))
            {
                psWhere = " WHERE" + psWhere;
            }
            return Delete("DELETE FROM " + psTableName + psWhere);
        }

        // Insert into Table [psTableName] ([psValues[i]]) Values ([psValues[i+1]])
        // Return true if record is inserted
        public static int Insert(string psTableName, string[] psValues)
        {
            psTableName = psTableName.Trim();
            if (psTableName == "")
            {
                return int.MinValue;
            }
            if (!Util.isNULL(psValues))
            {
                string lsQuery = "";
                string lsCols = "";
                string lsValues = "";

                int liValuesLength = psValues.Length;
                int liNbValues = liValuesLength / 2;

                //if (have at least 2 values and is even)
                if (liNbValues != 0 && (liValuesLength % 2) == 0)
                {
                    for (int i = 0; i < liNbValues; i++)
                    {
                        lsCols += psValues[2 * i];
                        lsValues += psValues[(2 * i) + 1];
                        if (i != (liNbValues - 1))
                        {
                            lsCols += ",";
                            lsValues += ",";
                        }
                    }
                    lsQuery = "INSERT INTO " + psTableName + "(" + lsCols + ") VALUES(" + lsValues + ")";
                    try
                    {
                        int liReturn = -1;
                        SqlCommand lSqlCommand = new SqlCommand(lsQuery, new SqlConnection(GlobalConfig.getConnectionString()));
                        lSqlCommand.Connection.Open();
                        liReturn = lSqlCommand.ExecuteNonQuery();
                        lSqlCommand.Connection.Close();

                    return liReturn;
                    }

                    catch
                    {
                        return int.MinValue;
                    }

                }
            }
            return int.MinValue;
        }

        // Insert into Table [psTableName] ([psCols[i], psCols[i+1], ...]) Values ([psValues[i], psValues[i+1], ...])
        // Return true if record is inserted
        public static int Insert(string psTableName, string[] psCols, string[] psValues)
        {
            psTableName = psTableName.Trim();
            if (psTableName == "")
                return int.MinValue;
            if (!(Util.isNULL(psCols) || Util.isNULL(psValues)))
            {
                int liColsLength = psCols.Length;

                //if (have at least 1 column and (# of cols and # of values is equal)
                if (liColsLength != 0 && liColsLength == psValues.Length)
                {
                    string lsQuery = "";
                    string lsCols = "";
                    string lsValues = "";

                    for (int i = 0; i < liColsLength; i++)
                    {
                        lsCols += psCols[i];
                        lsValues += psValues[i];
                        if (i != (liColsLength - 1))
                        {
                            lsCols += ",";
                            lsValues += ",";
                        }
                    }
                    lsQuery = "INSERT INTO " + psTableName + "(" + lsCols + ") VALUES(" + lsValues + ")";
                    try
                    {
                        int liReturn = -1;
                        SqlCommand lSqlCommand = new SqlCommand(lsQuery, new SqlConnection(GlobalConfig.getConnectionString()));

                        lSqlCommand.Connection.Open();
                        liReturn = lSqlCommand.ExecuteNonQuery();
                        lSqlCommand.Connection.Close();
                        return liReturn;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        Console.WriteLine(e.Message);
                        MessageBox.Show(e.Message);
                    }
                    catch
                    {
                        return int.MinValue;
                    }
                }
            }
            return int.MinValue;
        }

        // Insert into Table [psTableName] ([psCols]) Values ([psValues])
        // Return true if record is inserted
        public static int Insert(string psTableName, string psCols, string psValues)
        {
            psTableName = psTableName.Trim();
            if (psTableName == "")
            {
                return int.MinValue;
            }
            psCols = Util.RemoveDoubleSpaces(psCols);
            psValues = Util.RemoveDoubleSpaces(psValues);
            if (psCols == "" || psValues == "")
            {
                return int.MinValue;
            }
            if (!psCols.Contains(","))
            {
                psCols = psCols.Replace(" ", ",");
            }
            if (!psValues.Contains(","))
            {
                psValues = psValues.Replace(" ", ",");
            }
            if (!psCols.Contains("("))
            {
                psCols = "(" + psCols;
            }
            if (!psValues.Contains("("))
            {
                psValues = "(" + psValues;
            }
            if (!psCols.Contains(")"))
            {
                psCols = psCols + ") ";
            }
            if (!psValues.Contains(")"))
            {
                psValues = psValues + ") ";
            }
            try
            {
                int liReturn = int.MinValue;
                SqlCommand lSqlCommand = new SqlCommand("INSERT INTO " + psTableName + psCols + " VALUES" + psValues, new SqlConnection(GlobalConfig.getConnectionString()));

                lSqlCommand.Connection.Open();
                liReturn = lSqlCommand.ExecuteNonQuery();
                lSqlCommand.Connection.Close();
                return liReturn;
            }
            catch
            {
                return int.MinValue;
            }
        }

        // Update Table [psTableName] with Query [psQuery]
        // Return number of record affected
        public static int Update(string psQuery)
        {
            return ExecuteNonQuery(psQuery);
        }

        // Update Table [psTableName]
        // SET [psAffectedValues] (must contain "col = value")
        // WHERE [psWhere]
        // Return number of record affected
        public static int Update(string psTableName, string psAffectedValues, string psWhere)
        {
            psTableName = psTableName.Trim();
            if (psTableName == "")
            {
                return int.MinValue;
            }
            psAffectedValues = " " + psAffectedValues.Trim();
            if (psAffectedValues == " ")
            {
                return int.MinValue;
            }
            if (!psAffectedValues.ToUpper().Contains("SET"))
            {
                psAffectedValues = " SET" + psAffectedValues;
            }
            psWhere = " " + psWhere.Trim();
            if (psWhere != " " && !psWhere.ToUpper().Contains("WHERE"))
            {
                psWhere = " WHERE" + psWhere;
            }
            return Update("UPDATE " + psTableName + psAffectedValues + psWhere);
        }

        // Update Table [psTableName]
        // SET [psAffectedValues] (must contain "col = value")
        // WHERE ID = '[psID]'
        // Return number of record affected
        public static int UpdateID(string psTableName, string psAffectedValues, string psID)
        {
            if (!Util.isValidGuid(psID))
                return int.MinValue;
            return Update(psTableName, psAffectedValues, "ID = '" + psID + "'");
        }

        // Update Table [psTableName]
        // SET [psAffectedValues] (must contain "col = value")
        // WHERE ID = '[psID]'
        // Return number of record affected
        public static int UpdateID(string psTableName, string psAffectedValues, Guid pID)
        {
            if (Util.isNULL(pID))
                return int.MinValue;
            return Update(psTableName, psAffectedValues, "ID = '" + pID.ToString() + "'");
        }

        // Update Table [psTableName]
        // SET [psCols[i]=psValues[i]], [psCols[i+1]=psValues[i+1]], ...
        // WHERE ID = '[pID.toString()]'
        // Return number of record affected
        public static int UpdateID(string psTableName, string[] psCols, string[] psValues, Guid pID)
        {
            if (Util.isNULL(pID))
                return int.MinValue;
            return UpdateID(psTableName, psCols, psValues, pID.ToString());
        }

        // Update Table [psTableName]
        // SET [psCols[i]=psValues[i]], [psCols[i+1]=psValues[i+1]], ...
        // WHERE ID = '[psID]'
        // Return number of record affected
        public static int UpdateID(string psTableName, string[] psCols, string[] psValues, string psID)
        {
            if (!Util.isValidGuid(psID))
                return int.MinValue;
            psTableName = psTableName.Trim();
            if (psTableName == "")
                return int.MinValue;
            if (!(Util.isNULL(psCols) || Util.isNULL(psValues)))
            {
                int liColsLength = psCols.Length;

                if (liColsLength != 0 && liColsLength == psValues.Length)
                {
                    string lsAffectedValues = "";

                    for (int i = 0; i < liColsLength; i++)
                    {
                        lsAffectedValues += psCols[i] + "=" + psValues[i];
                        if (i != (liColsLength - 1))
                            lsAffectedValues += ",";
                    }
                    return Update(psTableName, lsAffectedValues, "ID = '" + psID + "'");
                }
            }
            return int.MinValue;
        }

        // Drop Table [psTableName]
        public static int DropTable(string psTableName)
        {
            psTableName = psTableName.Trim();
            if (psTableName == "")
            {
                return int.MinValue;
            }
            return ExecuteNonQuery("DROP TABLE " + psTableName);
        }

        public static bool Exist(string psQuery)
        {
            DataTable lDataTable = Select(psQuery);

            if (Util.isNULL(lDataTable))
            {
                return false;
            }
            else
            {
                return (lDataTable.Rows.Count > 0);
            }
        }

        public static int ExecuteNonQuery(string psQuery)
        {
            try
            {
                int liReturn = int.MinValue;
                SqlCommand lSqlCommand = new SqlCommand(psQuery, new SqlConnection(GlobalConfig.getConnectionString()));

                lSqlCommand.Connection.Open();
                liReturn = lSqlCommand.ExecuteNonQuery();
                lSqlCommand.Connection.Close();
                return liReturn;
            }
            catch
            {
                return int.MinValue;
            }
        }

        public static int ExecuteNonQuery(ref SqlCommand pSqlCommand)
        {
            try
            {
                int liReturn = int.MinValue;

                pSqlCommand.Connection.Open();
                liReturn = pSqlCommand.ExecuteNonQuery();
                pSqlCommand.Connection.Close();
                return liReturn;
            }
            catch
            {
                return int.MinValue;
            }
        }

        public static SqlCommand GetSqlCommand(string psQuery)
        {
            return new SqlCommand(psQuery, new SqlConnection(GlobalConfig.getConnectionString()));
        }

    }
}
