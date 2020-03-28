﻿using System;
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
        clsDataAccess db;
        DataSet ds;

        public clsMainSQL()
        {
            db = new clsDataAccess();
            ds = new DataSet();
        }

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
                db.ExecuteNonQuery($"INSERT INTO Invoices(InvoiceNum, InvoiceDate, TotalCost) VALUSE({invoiceNum}, {date}, {cost})");
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
