using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Group_Project.Items
{
    /// <summary>
    /// Class for main business logic behind Items modification
    /// </summary>
    class clsItemsLogic
    {
        /// <summary>
        /// dataset containing invoices the item is on
        /// </summary>
        public DataSet dsItemOnInvoices;

        /// <summary>
        /// data access to database
        /// </summary>
        private clsDataAccess db;

        /// <summary>
        /// Items data set
        /// </summary>
        private DataSet dsItems;

        /// <summary>
        /// Constructor
        /// </summary>
        public clsItemsLogic()
        {
            db = new clsDataAccess();
            dsItemOnInvoices = new DataSet();
        }

        /// <summary>
        /// Select all items from database
        /// </summary>
        /// <returns>all items</returns>
        public List<DataRow> Items()
        {
            try
            {
                // Initialize variablse
                int iRetVal = 0;
                List<DataRow> lstItems = new List<DataRow>();

                // SQL query string
                string sSQLQuery = clsItemsSQL.SelectAllItems();

                // query the database
                dsItems = db.ExecuteSQLStatement(sSQLQuery, ref iRetVal);

                // loop through dataset and append to list
                foreach (DataRow drRow in dsItems.Tables[0].Rows)
                {
                    lstItems.Add(drRow);
                }

                // return list
                return lstItems;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        
        /// <summary>
        /// Add Item
        /// </summary>
        /// <param name="sItemCode">Item Code</param>
        /// <param name="sItemDesc">Item Description</param>
        /// <param name="iCost">Item Cost</param>
        /// <returns>Success of Item addition</returns>
        public bool Add(string sItemCode, string sItemDesc, int iCost)
        {
            try
            {
                // Initialize variables
                bool bSuccess = false;
                string sNonSQLQuery = clsItemsSQL.AddItem(sItemCode, sItemDesc, iCost);

                // Add item query
                int iRowsAffected = db.ExecuteNonQuery(sNonSQLQuery);

                // return count should be 1 for indication item was added
                if (iRowsAffected >= 1)
                {
                    bSuccess = true;
                }

                return bSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Delete Item 
        /// </summary>
        /// <param name="sItemCode">Item Code</param>
        /// <returns>Success of Item deletion</returns>
        public bool Delete(string sItemCode)
        {
            try
            {
                // initialize variables
                string sSQLQuery = clsItemsSQL.ItemInvoiceNum(sItemCode);
                int iRetCnt = 0;
                bool bSuccess = false;

                // Determine if ItemCode exists in an invoice
                dsItemOnInvoices = db.ExecuteSQLStatement(sSQLQuery, ref iRetCnt);

                // return count should be 0 for indication item is not on an invoice
                if (iRetCnt == 0)
                {
                    // Delete the item
                    sSQLQuery = clsItemsSQL.DeleteItem(sItemCode);
                    int rowsAffected = db.ExecuteNonQuery(sSQLQuery);

                    // update success status
                    if (rowsAffected >= 1)
                    {
                        bSuccess = true;
                    }
                }

                return bSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Update item information
        /// </summary>
        /// <param name="sItemCode">Item Name</param>
        /// <param name="sItemDesc">Item Description</param>
        /// <param name="iCost">Item Cost</param>
        /// <returns>Success of Item update</returns>
        public bool Update(string sItemCode, string sItemDesc, int iCost)
        {
            try
            {
                // Initialize variables
                bool bSuccess = false;
                string sNonSQLQuery = clsItemsSQL.UpdateItem(sItemCode, sItemDesc, iCost);

                // Execute the update
                int rowsAffected = db.ExecuteNonQuery(sNonSQLQuery);

                // update success status
                if (rowsAffected >= 1)
                {
                    bSuccess = true;
                }

                return bSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
