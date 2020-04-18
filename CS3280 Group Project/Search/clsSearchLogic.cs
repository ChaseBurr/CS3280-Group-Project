using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Group_Project.Search


{
    class clsSearchLogic
    {

        #region Class Variables
        /// <summary>
        /// Connection to database
        /// </summary>
        clsSearchSQL searchSQL = new clsSearchSQL();

        /// <summary>
        /// Used for passing invoiceID selected back to main
        /// </summary>
        public string invoiceID;

        /// <summary>
        /// List of invoice numbers
        /// </summary>
        public List<string> invoiceNumbers = new List<string>();

        /// <summary>
        /// List of invoice dates
        /// </summary>
        public List<string> invoiceDates = new List<string>();

        /// <summary>
        /// List of invoice costs
        /// </summary>
        public List<string> invoiceCosts = new List<string>();

        /// <summary>
        /// Data set of invoices fitting query
        /// </summary>
        public DataSet dataSetInvoiceList;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor populates initial invoice view
        /// </summary>
        public clsSearchLogic() {
            PopulateInvoiceList();
            dataSetInvoiceList = searchSQL.GetFullInvoiceList();
            invoiceID = "none";
        }
        #endregion

        #region Set Invoice ID
        /// <summary>
        /// Sets invoiceID based on selected invoice in wndSearch
        /// </summary>
        /// <param name="invoiceID"></param>
        public void setInvoiceID(string invoiceID) {
            this.invoiceID = invoiceID;
        }
        #endregion

        #region Combobox List Fill
        /// <summary>
        /// Populate lists to be used as ItemsSource for dropdowns
        /// </summary>
        public void PopulateInvoiceList() {
            // add sorted invoice numbers to list
            DataTable table = searchSQL.GetSortedInvoiceNums().Tables[0];
            foreach (DataRow row in table.Rows) {
                invoiceNumbers.Add(row.ItemArray[0].ToString());
            }
            // add sorted costs to list
            table = searchSQL.GetSortedCosts().Tables[0];
            foreach (DataRow row in table.Rows) {
                invoiceCosts.Add("$" + row.ItemArray[0].ToString());
            }
            // add sorted dates to list
            table = searchSQL.GetSortedDates().Tables[0];
            foreach (DataRow row in table.Rows) {
                invoiceDates.Add(row.ItemArray[0].ToString());
            }
        }
        #endregion

        #region Query Builder
        /// <summary>
        /// Takes combo box values and builds query based on values
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <param name="invoiceDate"></param>
        /// <param name="invoiceCharge"></param>
        public void BuildQueryFromSelections(string invoiceNum, string invoiceDate, string invoiceCharge) {
            string query = "SELECT * FROM INVOICES";
            // invoice num selected
            if (invoiceNum != null) {
                query += " WHERE InvoiceNum = " + invoiceNum;
            }
            if (invoiceDate != null) {
                if (invoiceNum != null) {
                    // CONVERT(DATETIME, YourColumn, 101)
                    query += " AND InvoiceDate = #" + invoiceDate.Substring(0, 9) + "#";
                } else {
                    query += " WHERE InvoiceDate = #" + invoiceDate.Substring(0, 9) + "#";
                }
            }
            if (invoiceCharge != null) {
                if (invoiceNum != null || invoiceDate != null) {
                    query += " AND TotalCost = " + invoiceCharge.Substring(1, invoiceCharge.Length - 1);
                } else {
                    query += " WHERE TotalCost = " + invoiceCharge.Substring(1, invoiceCharge.Length - 1);
                }
            }
            Console.WriteLine(query);
            dataSetInvoiceList = searchSQL.GetLimitedInvoiceList(query);
        }
        #endregion
    }
}
