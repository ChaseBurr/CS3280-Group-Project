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

        #region Class Variables

        /// <summary>
        /// Logic for search window
        /// </summary>
        clsSearchLogic logic = new clsSearchLogic();
            
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for wndSearch
        /// </summary>
        public wndSearch()
        {
            InitializeComponent();
            PopulateDropdowns();
            PopulateDataGrid();

        }
        #endregion

        #region Button Handlers
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
            // invoiceID is set based on the selected cell in the gridrow
            // this window is set as a class member in the main window to allow access to invoiceID
            if (InvoiceDataGrid.SelectedItem != null) {
                logic.setInvoiceID(InvoiceDataGrid.SelectedCells[0].ToString());
                this.Close();
            }
            
        }
        #endregion

        #region PopulateUIElements
        /// <summary>
        /// Populate dropdowns based on info queried in clsMainSQL.cs
        /// </summary>
        private void PopulateDropdowns() {
            InvoiceNumber.ItemsSource = logic.invoiceNumbers;
            InvoiceDate.ItemsSource = logic.invoiceDates;
            InvoiceCharge.ItemsSource = logic.invoiceCosts;
        }

        /// <summary>
        /// Populate datagrid based on info queried in clsMainSQL.cs
        /// </summary>
        private void PopulateDataGrid() {
            // get selections and pass to query builder in logic
            string invoiceNum = InvoiceNumber.SelectedItem as string;
            string invoiceDate = InvoiceDate.SelectedItem as string;
            string invoiceCharge = InvoiceCharge.SelectedItem as string;
            logic.BuildQueryFromSelections(invoiceNum, invoiceDate, invoiceCharge);
            // update data grid
            InvoiceDataGrid.AutoGenerateColumns = true;
            InvoiceDataGrid.DataContext = logic.dataSetInvoiceList.Tables[0].DefaultView;

            
        }

        /// <summary>
        /// When the selection boxes are changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceInfo_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            PopulateDataGrid();
        }

        #endregion
    }
}
