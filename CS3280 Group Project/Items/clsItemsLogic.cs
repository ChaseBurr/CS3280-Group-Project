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
            try
            {
                db = new clsDataAccess();
                dsItemOnInvoices = new DataSet();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Select all items from database
        /// </summary>
        /// <returns>all items</returns>
        public List<clsItem> Items()
        {
            try
            {
                // Initialize variablse
                int iRetVal = 0;
                List<clsItem> lstItems = new List<clsItem>();

                // SQL query string
                string sSQLQuery = clsItemsSQL.SelectAllItems();

                // query the database
                dsItems = db.ExecuteSQLStatement(sSQLQuery, ref iRetVal);

                // temp variables
                string sName;
                string sDescription;
                int iCost;
                bool bNumValid;

                foreach (DataRow drRow in dsItems.Tables[0].Rows)
                {
                    sName = drRow.ItemArray[0].ToString();
                    sDescription = drRow.ItemArray[1].ToString();
                    iCost = 0;
                    bNumValid = Int32.TryParse( drRow.ItemArray[2].ToString(), out iCost);

                    // if parsing of string to int valid
                    if (bNumValid)
                    {
                        lstItems.Add(new clsItem { sItemName = sName, sItemDesc = sDescription, iItemCost = iCost });
                    }
                }

                // comparer object for sorting the item code
                clsItemComparer itemComparer = new clsItemComparer();
                lstItems.Sort(itemComparer);

                // return the items list
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
                string sNonSQLQuery = clsItemsSQL.AddItem(sItemCode, sItemDesc, iCost);
                int iRowsAffected = 0;

                // Add item query
                iRowsAffected = db.ExecuteNonQuery(sNonSQLQuery);

                // return success
                return (iRowsAffected >= 1);
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
                int rowsAffected = 0;

                // Determine if ItemCode exists in an invoice
                dsItemOnInvoices = db.ExecuteSQLStatement(sSQLQuery, ref iRetCnt);

                // return count should be 0 for indication item is not on an invoice
                if (iRetCnt == 0)
                {
                    // Delete the item
                    sSQLQuery = clsItemsSQL.DeleteItem(sItemCode);
                    rowsAffected = db.ExecuteNonQuery(sSQLQuery);
                }

                //return success;
                return (rowsAffected >= 1);
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
                // variables
                bool itemCodeFound = false;
                int rowsAffected = 0;

                // verify the Item Code hasn't been changed
                foreach (DataRow row in dsItems.Tables[0].Rows)
                {
                    if (row[0].ToString() == sItemCode)
                    {
                        itemCodeFound = true;
                    }
                }

                // if exists in database proceed with update
                if (itemCodeFound)
                {
                    // Initialize variables
                    string sNonSQLQuery = clsItemsSQL.UpdateItem(sItemCode, sItemDesc, iCost);

                    // Execute the update
                    rowsAffected = db.ExecuteNonQuery(sNonSQLQuery);
                }
                
                // return success
                return (rowsAffected >= 1);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
