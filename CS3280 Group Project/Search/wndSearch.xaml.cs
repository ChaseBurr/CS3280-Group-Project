using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CS3280_Group_Project;
using CS3280_Group_Project.Items;
using CS3280_Group_Project.Search;
using System.Data;

namespace CS3280_Group_Project.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {

        clsSearchSQL searchSQL = new clsSearchSQL();
        public string invoiceID { get; set; }

        public wndSearch()
        {
            InitializeComponent();
            PopulateDropdowns();
            PopulateDataGrid();
        }

        /// <summary>
        /// Clear selections in dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, RoutedEventArgs e) {
            InvoiceNumber.SelectedItem = null;
            InvoiceDate.SelectedItem = null;
            InvoiceCharge.SelectedItem = null;
            
        }

        /// <summary>
        /// Close window and send invoice back to main screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectButton_Click(object sender, RoutedEventArgs e) {
            invoiceID = "5001";
        }

        /// <summary>
        /// 
        /// </summary>
        private void PopulateDropdowns() {
            foreach (string invoiceNum in searchSQL.GetInvoiceNumbers()) {
                InvoiceNumber.Items.Add(invoiceNum);
            }
            foreach (string invoiceDate in searchSQL.GetInvoiceDates()) {
                InvoiceDate.Items.Add(invoiceDate.Substring(0, 9));
            }
            foreach (string invoiceCost in searchSQL.GetInvoiceCosts()) {
                InvoiceCharge.Items.Add("$" + invoiceCost);
            }
        }

        private void PopulateDataGrid() {
            InvoiceDataGrid.AutoGenerateColumns = true;
            InvoiceDataGrid.DataContext = searchSQL.GetDataSet().Tables[0].DefaultView;
        }

        /*
        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            if ((sender as MenuItem).Header.ToString() == "Items" &&) {
                wndItems window = new wndItems();
                window.Show();
            } else if ((sender as MenuItem).Header.ToString() == "Search") {
                wndSearch window = new wndSearch();
                window.Show();
            }
        }
        */
    }
}
