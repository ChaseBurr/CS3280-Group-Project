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
        /// Dataset containing all invoices
        /// </summary>
        DataSet dataSet;
        
        /// <summary>
        /// List of invoice numbers
        /// </summary>
        List<string> invoiceNumbers = new List<string>();

        /// <summary>
        /// List of invoice dates
        /// </summary>
        List<string> invoiceDates = new List<string>();

        /// <summary>
        /// List of invoice costs
        /// </summary>
        List<string> invoiceCosts = new List<string>();
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for clsSearchSQL
        /// </summary>
        public clsSearchSQL() {
            // access to data
            int numInvoices = 0;
            clsDataAccess dataAccess = new clsDataAccess();
            dataSet = dataAccess.ExecuteSQLStatement("SELECT * FROM Invoices", ref numInvoices);

            // store lists to populate displays
            DataTable table = dataSet.Tables[0];
            foreach (DataRow row in table.Rows) {
                invoiceNumbers.Add(row.ItemArray[0].ToString());
                invoiceDates.Add(row.ItemArray[1].ToString());
                invoiceCosts.Add(row.ItemArray[2].ToString());
            }

        }
        #endregion

        #region Getters
        public List<string> GetInvoiceNumbers() {
            return invoiceNumbers;
        }

        public List<string> GetInvoiceDates() {
            return invoiceDates;
        }

        public List<string> GetInvoiceCosts() {
            return invoiceCosts;
        }

        public DataSet GetDataSet() {
            return dataSet;
        }
        #endregion

    }
}
