using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Group_Project.Main
{
    class clsMainSQL
    {
        #region Attributes
        /// <summary>
        /// database connection
        /// </summary>
        clsDataAccess db;
        /// <summary>
        /// dataset object
        /// </summary>
        DataSet ds;
        #endregion

        /// <summary>
        /// Main constructor
        /// </summary>
        public clsMainSQL()
        {
            db = new clsDataAccess();
            ds = new DataSet();
        }

        #region Update Queries
        
        /// <summary>
        /// update invoice
        /// </summary>
        /// <param name="InvoiceNumber"></param>
        /// <param name="TotalCost"></param>
        public void Update(int InvoiceNumber, int TotalCost)
        {
            db.ExecuteNonQuery($"UPDATE Invoices SET TotalCost = {TotalCost} Where InvoiceNum = {InvoiceNumber}");
        }
        
        #endregion

        #region Delete queries

        /// <summary>
        /// delete item from table
        /// </summary>
        /// <param name="InvoiceNumber"></param>
        public void DeleteItem(int InvoiceNumber)
        {
            // need to delete from item desc first
            db.ExecuteNonQuery($"DELETE FROM LineItems Where InvoiceNum = {InvoiceNumber}");
        }

        /// <summary>
        /// delete invoice
        /// </summary>
        /// <param name="InvoiceNumber"></param>
        public void DeleteInvoice(int InvoiceNumber)
        {
            db.ExecuteNonQuery($"DELETE FROM Invoices Where InvoiceNum = {InvoiceNumber}");
        }

        #endregion

        #region Select Statements

        /// <summary>
        /// returns dataset of the invoice number searched for
        /// </summary>
        /// <param name="InvoiceNumber"></param>
        /// <returns></returns>
        public DataSet SelectInvoice(int InvoiceNumber)
        {
            int iRet = 0;
            ds = db.ExecuteSQLStatement($"SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = {InvoiceNumber}", ref iRet);
            return ds;
        }

        /// <summary>
        /// returns the item descriptions
        /// </summary>
        /// <returns></returns>
        public DataSet SelectItemDesc()
        {
            int iRet = 0;
            ds = db.ExecuteSQLStatement($"select ItemCode, ItemDesc, Cost FROM ItemDesc", ref iRet);
            return ds;
        }

        /// <summary>
        /// select item based off invoice number
        /// </summary>
        /// <param name="InvoiceNumber"></param>
        /// <returns></returns>
        public DataSet SelectItem(int InvoiceNumber)
        {
            int iRet = 0;
            ds = db.ExecuteSQLStatement($"SELECT li.ItemCode, id.ItemDesc, id.Cost FROM LineItems li inner join ItemDesc id ON li.ItemCode = id.ItemCode WHERE li.InvoiceNum = {InvoiceNumber}", ref iRet);
            return ds;
        }

        #endregion

        #region Insert Queries

        /// <summary>
        /// Inserts items into LineItems
        /// </summary>
        /// <param name="InvoiceNum">invoice number</param>
        /// <param name="LinItem">line item number</param>
        /// <param name="ItemCode">item code</param>
        public void InsertItem(int InvoiceNum, int LinItem, string ItemCode)
        {
            try
            {
                db.ExecuteNonQuery($"INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode) Values ({InvoiceNum}, {LinItem}, '{ItemCode}')");
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// insert invoice into database
        /// </summary>
        /// <param name="InvoiceDate">Invoice date</param>
        /// <param name="TotalCost">total cost</param>
        public void InsertInvoice(string InvoiceDate, double TotalCost)
        {
            try
            {
                db.ExecuteNonQuery($"INSERT INTO Invoices (InvoiceDate, TotalCost) Values ('{InvoiceDate}', {TotalCost})");
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #endregion

        /// <summary>
        /// returns max invoice number
        /// </summary>
        /// <returns></returns>
        public int GetMaxInvoiceNumber()
        {
            int iRet = 0;

            int max = Convert.ToInt32(db.ExecuteSQLStatement("SELECT MAX(InvoiceNum) FROM Invoices ", ref iRet).Tables[0].Rows[0][0]);

            return max;
        }
    }
}
