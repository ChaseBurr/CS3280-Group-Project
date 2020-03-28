using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CS3280_Group_Project.Search
{

    class clsSearchSQL {
        DataSet dataSet;
        int numInvoices;
        List<string> invoiceNumbers = new List<string>();
        List<string> invoiceDates = new List<string>();
        List<string> invoiceCosts = new List<string>();

        public clsSearchSQL() {
            // access to data
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


    }
}
