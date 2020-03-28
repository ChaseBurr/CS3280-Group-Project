using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Group_Project.Items
{
    /// <summary>
    /// Main class for SQL queries
    /// </summary>
    class clsItemsSQL
    {
        /// <summary>
        /// Obtain the SQL statement for Adding item
        /// </summary>
        /// <param name="sItemCode">Item name</param>
        /// <param name="sItemDesc">Item description</param>
        /// <param name="iCost">Item cost</param>
        /// <returns>SQL statement for Adding item</returns>
        public static string AddItem(string sItemCode, string sItemDesc, int iCost)
        {
            try
            {
                // Define the SQL statement
                string sSQL = "INSERT INTO ItemDesc (ItemCode, ItemDesc, Cost)" +
                                $"VALUES('{sItemCode}', '{sItemDesc}', {iCost})";

                // returns the SQL statement
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Obtatin the SQL statement for deleting items
        /// </summary>
        /// <param name="sItemCode">Item name</param>
        /// <returns>SQL statement for deleting item</returns>
        public static string DeleteItem(string sItemCode)
        {
            try
            {
                // Define the SQL statement
                string sSQL = "DELETE " +
                                "FROM ItemDesc" +
                                $"WHERE ItemCode = '{sItemCode}'";

                // returns the SQL statement
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Obtain the SQL statement for retrieving invoice number
        /// </summary>
        /// <param name="iItemCode">ItemCode value in the database</param>
        /// <returns>Invoice number for item code</returns>
        public static string ItemInvoiceNum(int iItemCode)
        {
            try
            {
                // Define the SQL statment
                string sSQL = "SELECT DISTINCT InvoiceNum" +
                                "FROM LineItems" +
                                $"WHERE ItemCode = '{iItemCode}'";

                // returns the SQL statement
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Obtain the SQL statement for retrieving all items
        /// </summary>
        /// <returns>All current Items</returns>
        public static string SelectAllItems()
        {
            try
            {
                // Define the SQL statement
                string sSQL = "SELECT ItemCode, ItemDesc, Cost" +
                                "FROM ItemDesc";

                // returns the SQL statement
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Obtatin the SQL statment for Editing item
        /// </summary>
        /// <param name="sItemCode">Item name</param>
        /// <param name="sItemDesc">Item description</param>
        /// <param name="iCost">Item Cost</param>
        /// <returns>SQL statement for editing item</returns>
        public static string UpdateItem(string sItemCode, string sItemDesc, int iCost)
        {
            try
            {
                // Define the SQL statement
                string sSQL = "UPDATE ItemDesc" +
                                $"SET ItemDesc = '{sItemDesc}', Cost = {iCost}" +
                                $"WHERE ItemCode = '{sItemCode}'";

                // returns the SQL statement
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
