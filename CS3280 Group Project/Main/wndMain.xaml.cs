using CS3280_Group_Project.Main;
using CS3280_Group_Project.Search;
using CS3280_Group_Project.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Diagnostics;
using System.Data;
using System.Collections.ObjectModel;

namespace CS3280_Group_Project.Items
{
    
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        #region Attributes
        /// <summary>
        /// Object that holds all the logic behind the main window ui
        /// </summary>
        private clsMainLogic Logic;

        /// <summary>
        /// sql object for the main ui
        /// </summary>
        private clsMainSQL sql;

        /// <summary>
        /// Holds search window for getting selected invoiceID
        /// </summary>
        private wndSearch search;

        /// <summary>
        /// holds the search logic
        /// </summary>
        private clsSearchLogic SearchLogic;

        /// <summary>
        /// ItemLogic object to access item info
        /// </summary>
        private clsItemsLogic ItemLogic;

        /// <summary>
        /// holds the new invoice information
        /// </summary>
        private clsItem NewInvoice;

        /// <summary>
        /// DataSet object to hold data from db
        /// </summary>
        public DataSet ds;

        /// <summary>
        /// holds the selected item description
        /// </summary>
        private string sSelectedItem;

        /// <summary>
        /// holds the state of selecting invoice or create a new one
        /// </summary>
        bool bSelectedInvoice = false;

        public string sInvoiceID;

        /// <summary>
        /// holds the total cost
        /// </summary>
        private double cost;

        /// <summary>
        /// holds a list of clsItems
        /// </summary>
        private List<clsItem> SelectedItems;

        /// <summary>
        /// Default constructor for wndMain
        /// </summary>
        public wndMain()
        {
            try
            {
                InitializeComponent();
                Logic = new clsMainLogic();
                sql = new clsMainSQL();
                ItemLogic = new clsItemsLogic();
                ds = new DataSet();
                SelectedItems = new List<clsItem>();
                SearchLogic = new clsSearchLogic();

                // Populate cbItemList
                List<clsItem> item = ItemLogic.Items();
                cbItemList.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = item });
                cbItemList.DisplayMemberPath = "sItemDesc";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #endregion

        #region Menu Bar event handling
        /// <summary>
        /// Opens the search window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchForInvoice(object sender, RoutedEventArgs e)
        {
            try
            {
                search = new wndSearch(this);
                //App.Current.MainWindow = search;
                search.ShowDialog();
                
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Opens the Item window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateItems(object sender, RoutedEventArgs e)
        {
            try
            {
                wndItems items = new wndItems();
                App.Current.MainWindow = items;
                items.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #endregion

        #region Button event handling

        /// <summary>
        /// update button handling
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Add invoice to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddInvoice(object sender, RoutedEventArgs e)
        {
            try
            {
                cbItemList.IsEnabled = true;
                btnCancel.IsEnabled = true;
                btnAddInvoice.IsEnabled = false;
                dgItemList.ItemsSource = null;
                ClearUI();
                //NewInvoice = new clsItem();
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Handles the Edit Invoice Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditInvoice(object sender, RoutedEventArgs e)
        {
            try
            {
                dgItemList.IsEnabled = true;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Handles delete button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteInvoice(object sender, RoutedEventArgs e)
        {
            try
            {
                //TODO: Open Invoice view and prompt the user to confirm the deletion of the invoice
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Opens different grid when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddInvoiceClick(object sender, RoutedEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Handles click event when edit button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditInvoiceClick(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Remove invoice from database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveInvoiceClick(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Handles delete item click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clsItem item = (clsItem)dgItemList.SelectedItem;
                cost -= item.iItemCost;
                tbTotalCost.Text = cost.ToString();
                SelectedItems.RemoveAt(dgItemList.SelectedIndex);
                UpdateDataGrid(SelectedItems);
                btnDeleteItem.IsEnabled = false;

                if (SelectedItems.Count == 0)
                    btnSave.IsEnabled = false;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Handles Cancel button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // disable/enable buttons
                btnAddItem.IsEnabled = false;
                btnDeleteItem.IsEnabled = false;
                btnCancel.IsEnabled = false;
                btnEditInvoice.IsEnabled = false;
                btnDeleteInvoice.IsEnabled = false;
                cbItemList.IsEnabled = false;
                btnSave.IsEnabled = false;
                btnAddInvoice.IsEnabled = true;
                btnUpdate.IsEnabled = false;

                // reset datagrid and combobox
                cbItemList.SelectedIndex = -1;
                dgItemList.ItemsSource = null;

                InvoiceNumberLabel.Content = "Invoice # TBD";
                InvoiceDateLabel.Content = "Date: MM/DD/YYYY";
                tbTotalCost.Text = "";
                cost = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Holds the save button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Logic.AddInvoice(SelectedItems, cost);
                InvoiceNumberLabel.Content = "Invoice # " + sql.GetMaxInvoiceNumber();
                btnEditInvoice.IsEnabled = true;
                dgItemList.IsEnabled = false;
                cbItemList.IsEnabled = false;
                btnSave.IsEnabled = false;
                
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region grid handling
        /// <summary>
        /// Updates screen when the item is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                btnAddItem.IsEnabled = true;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Handle button click event to add items to the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItemToGrid(object sender, RoutedEventArgs e)
        {
            try
            {
                if(sSelectedItem != "")
                {
                    clsItem selected = (clsItem)cbItemList.SelectedItem;

                    clsItem Item = new clsItem();
                    Item.sItemDesc = selected.sItemDesc;
                    Item.sItemName = selected.sItemName;
                    Item.iItemCost = selected.iItemCost;

                    cost += selected.iItemCost;
                    tbTotalCost.Text = cost.ToString();
                    SelectedItems.Add(Item);

                    UpdateDataGrid(SelectedItems);
                    btnSave.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// updates the grid
        /// </summary>
        /// <param name="Item"></param>
        private void UpdateDataGrid(List<clsItem> Item)
        {
            try
            {
                dgItemList.ItemsSource = null;
                dgItemList.ItemsSource = Item;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Handles selection change event on data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                btnDeleteItem.IsEnabled = true;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #endregion

        /// <summary>
        /// fill in invoice that's been selected from the search
        /// </summary>
        public void FillInvoice()
        {
            if (sInvoiceID != "none")
            {
                btnEditInvoice.IsEnabled = true;
                btnCancel.IsEnabled = true;
                btnAddInvoice.IsEnabled = false;
                cbItemList.IsEnabled = true;
                dgItemList.IsEnabled = false;
                btnUpdate.IsEnabled = true;
                List<clsItem> items = new List<clsItem>();
                ds = sql.SelectInvoice(Convert.ToInt32(sInvoiceID));
                InvoiceNumberLabel.Content = "Invoice # " + sInvoiceID;
                InvoiceDateLabel.Content = ds.Tables[0].Rows[0][1].ToString();
                tbTotalCost.Text = ds.Tables[0].Rows[0][2].ToString();

                ds = sql.SelectItem(Convert.ToInt32(sInvoiceID));

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    NewInvoice = new clsItem();
                    NewInvoice.sItemName = item[0].ToString();
                    NewInvoice.sItemDesc = item[1].ToString(); ;
                    NewInvoice.iItemCost = Convert.ToInt32(item[2]);
                    items.Add(NewInvoice);
                }
                SelectedItems = items;
                UpdateDataGrid(items);
            }
        }

        /// <summary>
        /// resets ui back to normal
        /// </summary>
        private void ClearUI()
        {
            InvoiceNumberLabel.Content = "Invoice # TBD";
            InvoiceDateLabel.Content = "Date: MM/DD/YYYY";
            tbTotalCost.Text = "";
        }

        
    }
}
