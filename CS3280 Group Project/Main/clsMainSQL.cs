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
        /// <summary>
        /// database connection
        /// </summary>
        clsDataAccess db;
        /// <summary>
        /// dataset object
        /// </summary>
        DataSet ds;

        /// <summary>
        /// Main constructor
        /// </summary>
        public clsMainSQL()
        {
            db = new clsDataAccess();
            ds = new DataSet();
        }
        

        // update
        public void Update(int InvoiceNumber, int TotalCost)
        {
            db.ExecuteNonQuery($"UPDATE Invoices SET TotalCost = {TotalCost} Where InvoiceNum = {InvoiceNumber}");
        }

        #region Delete queries

        public void DeleteItem(int InvoiceNumber)
        {
            // need to delete from item desc first
            db.ExecuteNonQuery($"DELETE FROM LineItems Where InvoiceNum = {InvoiceNumber}");
        }

        public void DeleteInvoice(int InvoiceNumber)
        {
            db.ExecuteNonQuery($"DELETE FROM Invoices Where InvoiceNum = {InvoiceNumber}");
        }

        #endregion

        #region Select Statements

        public DataSet SelectInvoice(int InvoiceNumber)
        {
            int iRet = 0;
            ds = db.ExecuteSQLStatement($"SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = {InvoiceNumber}", ref iRet);
            return ds;
        }

        public DataSet SelectItemDesc()
        {
            int iRet = 0;
            ds = db.ExecuteSQLStatement($"select ItemCode, ItemDesc, Cost FROM ItemDesc", ref iRet);
            return ds;
        }

        public DataSet SelectItem(int InvoiceNumber)
        {
            int iRet = 0;
            ds = db.ExecuteSQLStatement("SELECT li.ItemCode, id.ItemDesc, id.Cost FROM LineItems li, ItemDesc id " +
                                        $"Where li.ItemCode = id.ItemCode = {InvoiceNumber} AND li.InvoiceNum = {InvoiceNumber}", ref iRet);
            return ds;
        }

        #endregion


        /// <summary>
        /// Inserts invoice into database
        /// </summary>
        /// <param name="cost"></param>
        /// <param name="date"></param>
        /// <param name="desc"></param>
        public void Insert(int cost, string date, string desc)
        {
            try
            {
                int invoiceNum = GetMaxInvoiceNumber() + 1;
                db.ExecuteNonQuery($"INSERT INTO Invoices(InvoiceNum, InvoiceDate, TotalCost) VALUES({invoiceNum}, {date}, {cost})");
                db.ExecuteNonQuery($"INSERT INTO LineItems(InvoiceNum, ItemCode) VALUSE({invoiceNum}, {getItemCode(desc)})");
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns item code based off description
        /// </summary>
        /// <param name="desc"></param>
        /// <returns></returns>
        private string getItemCode(string desc)
        {
            int iRet = 0;
            ds = db.ExecuteSQLStatement($"SELECT ItemCode FROM ItemDesc where ItemDesc = {desc}", ref iRet);
            string code = ds.Tables[0].Rows[0][0].ToString();

            return code;

        }

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

        /// <summary>
        /// returns invoice datarow based off invoice num
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public List<DataRow> GetInvoice(int invoiceNum)
        {
            List<DataRow> invoice = new List<DataRow>();
            int iRet = 0;
            ds = db.ExecuteSQLStatement("SELECT i.InvoiceNum, i.InvoiceDate, id.ItemDesc, i.TotalCost FROM Invoices i " +
                                        "inner join LineItems li on i.InvoiceNum = li.InvoiceNum" +
                                        "inner join ItemDesc id on li.ItemCode = id.ItemCode" +
                                        $"Where i.InvoiceNum = {invoiceNum}", ref iRet);

            return invoice;
        }
    }
}
