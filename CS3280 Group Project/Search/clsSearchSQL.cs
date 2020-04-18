using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CS3280_Group_Project.Search
{

    class clsSearchSQL {

        #region Class Variables
        /// <summary>
        /// Dataset containing invoices from query
        /// </summary>
        DataSet dataSet;

        /// <summary>
        /// Access to DB
        /// </summary>
        clsDataAccess dataAccess;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for clsSearchSQL
        /// </summary>
        public clsSearchSQL() {
            // access to data
            dataAccess = new clsDataAccess();
        }
        #endregion

        #region Combobox Datasets
        /// <summary>
        /// Gets sorted dataset of invoice costs
        /// </summary>
        /// <returns></returns>
        public DataSet GetSortedCosts() {
            int numInvoices = 0;
            // get ordered costs
            dataSet = dataAccess.ExecuteSQLStatement("SELECT TotalCost FROM Invoices ORDER BY TotalCost", ref numInvoices);
            return dataSet;
        }

        /// <summary>
        /// Gets sorted dataset of invoice dates
        /// </summary>
        /// <returns></returns>
        public DataSet GetSortedDates() {
            int numInvoices = 0;
            // get ordered dates
            dataSet = dataAccess.ExecuteSQLStatement("SELECT InvoiceDate FROM Invoices ORDER BY InvoiceDate", ref numInvoices);
            return dataSet;
        }

        /// <summary>
        /// Gets sorted dataset of invoice numbers
        /// </summary>
        /// <returns></returns>
        public DataSet GetSortedInvoiceNums() {
            int numInvoices = 0;
            // get ordered invoice numbers
            dataSet = dataAccess.ExecuteSQLStatement("SELECT InvoiceNum FROM Invoices ORDER BY InvoiceNum", ref numInvoices);
            return dataSet;
        }
        #endregion

        #region Get Invoice List
        /// <summary>
        /// Gets dataset of all invoices
        /// </summary>
        /// <returns></returns>
        public DataSet GetFullInvoiceList() {
            int numInvoices = 0;
            dataSet = dataAccess.ExecuteSQLStatement("SELECT * FROM Invoices", ref numInvoices);
            return dataSet;
        }

        /// <summary>
        /// Gets dataset of invoices based on query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataSet GetLimitedInvoiceList(string query) {
            int numInvoices = 0; ;
            dataSet = dataAccess.ExecuteSQLStatement(query, ref numInvoices);
            return dataSet;
        }
        #endregion

    }
}
