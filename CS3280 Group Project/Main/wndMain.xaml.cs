using CS3280_Group_Project.Main;
using CS3280_Group_Project.Search;
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
        /// Holds search window for getting selected invoiceID
        /// </summary>
        private wndSearch search;

        public wndMain()
        {
            try
            {
                InitializeComponent();
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
                //TODO: Swap grids and allow the user to enter invoice information

                InvoiceGrid.Visibility = Visibility.Visible;
                MainMenuGrid.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

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
                //TODO: Set default quantity to 1
                //TODO: Update listbox with item
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

        
    }
}
