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
        /// ItemLogic object to access item info
        /// </summary>
        private clsItemsLogic ItemLogic;

        private clsItem NewInvoice;

        /// <summary>
        /// DataSet object to hold data from db
        /// </summary>
        public DataSet ds;

        /// <summary>
        /// holds the selected item description
        /// </summary>
        private string sSelectedItem;

        private ObservableCollection<clsItem> SelectedItems;

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
                SelectedItems = new ObservableCollection<clsItem>();

                // Populate cbItemList
                List<clsItem> item = ItemLogic.Items();
                cbItemList.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = item });
                cbItemList.DisplayMemberPath = "sItemDesc";

                // TODO:
                // TODO:
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

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
                //TODO: Pass in this for the object returned
                search = new wndSearch();
                App.Current.MainWindow = search;
                search.Show();

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

        #region Main menu grid view
        /// <summary>
        /// Add invoice to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddInvoice(object sender, RoutedEventArgs e)
        {
            try
            {
                //TODO: enable everything needed
                cbItemList.IsEnabled = true;
                btnCancel.IsEnabled = true;
                btnAddInvoice.IsEnabled = false;

                NewInvoice = new clsItem();


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
                // TODO: Changes grids and fills the empty values with selected invoice
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

        #endregion

        #region Invoice View Window

        #region Button event handling
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
        /// Saves invoice to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveInvoiceClick(object sender, RoutedEventArgs e)
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
        /// Add items to the datagrid based off user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItemToGrid(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #endregion

        #endregion

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
                tbQuantity.IsEnabled = true;

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Changes values based off user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuantityInput(object sender, TextCompositionEventArgs e)
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
        /// Update total cost when quantity is changed
        /// </summary>
        private void UpdateTotal()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void btnAddItemToGrid(object sender, RoutedEventArgs e)
        {
            try
            {
                if(sSelectedItem != "")
                {
                    btnDeleteItem.IsEnabled = true;
                    clsItem selected = (clsItem)cbItemList.SelectedItem;

                    clsItem Item = new clsItem();
                    Item.sItemDesc = selected.sItemDesc;
                    Item.sItemName = selected.sItemName;
                    Item.iItemCost = selected.iItemCost;

                    SelectedItems.Add(Item);

                    UpdateDataGrid(SelectedItems);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void UpdateDataGrid(ObservableCollection<clsItem> Item)
        {
            dgItemList.ItemsSource = null;
            dgItemList.ItemsSource = Item;
        }

        private void dgItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            clsItem item = (clsItem)dgItemList.SelectedItem;
            int cost = item.iItemCost;
            SelectedItems.RemoveAt(dgItemList.SelectedIndex);
            UpdateDataGrid(SelectedItems);
        }
    }
}
