using System;
using System.Collections.Generic;
using System.Data;
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

namespace CS3280_Group_Project.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        /// <summary>
        /// Flag indicating update to Items occurred
        /// </summary>
        public bool ItemListUpdated
        {
            get { return bItemListUpdated; }
        }

        /// <summary>
        /// Flag for indicating update to Items
        /// </summary>
        private bool bItemListUpdated;

        /// <summary>
        /// object instance of the items logic class
        /// </summary>
        private clsItemsLogic itemsLogic;

        /// <summary>
        /// Constructor
        /// </summary>
        public wndItems()
        {
            try
            {
                InitializeComponent();
                itemsLogic = new clsItemsLogic();
                bItemListUpdated = false;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Add Item button click event for adding items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // TODO: pass in the data
                string sItemCode = txtbItemName.Text;
                string sItemDesc = txtbItemDescription.Text;

                // TODO: tryparse on text string from txtbItemCost.Text
                int iCost = 0;

                // TODO: calls business logic of clsItemsLogic.cs
                    // Logic needs to validate Item id does not exist already
                if (itemsLogic.Add(sItemCode, sItemDesc, iCost))
                {
                    bItemListUpdated = true;
                    lblMessage.Content = $"{sItemCode} Added with Description: {sItemDesc}, Code: {iCost}";

                    // update items list
                    lstItems.ItemsSource = itemsLogic.Items();
                }
                else
                {
                    bItemListUpdated = false;
                    lblMessage.Content = $"Error adding {sItemCode}";
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Delete Item button click event for record deletion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // TODO: pass in the item code from the selection
                string sItemCode = txtbItemName.Text;

                // TODO: calls business logic of clsItemsLogic.cs. 
                // Logic should not allow deletion if the item exists in an invoice
                // Display error if error in deletion
                if (itemsLogic.Delete(sItemCode))
                {
                    bItemListUpdated = true;
                    lblMessage.Content = $"{sItemCode} Deleted from Items";

                    // update items list
                    lstItems.ItemsSource = itemsLogic.Items();
                }
                else
                {
                    bItemListUpdated = false;
                    lblMessage.Content = $"Error deleting {sItemCode} from Items";

                    // TODO: list the invoices the item is on from the itemsLogic.dsItemOnInvoices
                    lblMainMessage.Content = $"{sItemCode} Exists in the following invoices: .......";
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Edit Item button click event for editing Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // TODO: pass in the data
                string sItemCode = txtbItemName.Text;
                string sItemDesc = txtbItemDescription.Text;

                // TODO: tryparse on text string from txtbItemCost.Text
                int iCost = 0;

                // TODO: calls business logic of clsItemsLogic.cs
                // Logic should not allow edit of the code.
                // Only allows edit of the description and cost.
                if (itemsLogic.Update(sItemCode, sItemDesc, iCost))
                {
                    bItemListUpdated = true;
                    lblMessage.Content = $"{sItemCode} updated Description: {sItemDesc}, Cost: {iCost}";
                    
                    // update items list
                    lstItems.ItemsSource = itemsLogic.Items();
                }
                else
                {
                    bItemListUpdated = false;
                    lblMessage.Content = $"Error updating {sItemCode}";
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Shows user the exception
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
        }

        /// <summary>
        /// List view selection event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // TODO: populate the Add/ Edit / Delete form window
                clsItem Item = (clsItem) lstItems.SelectedItem;
                txtbItemName.Text = Item.sItemName;
                txtbItemDescription.Text = Item.sItemDesc;
                txtbItemCost.Text = Item.iItemCost.ToString();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Window closing event 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                // TODO: handle any notifications (if needed) back to main window
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Window loaded event used for setting default settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Initialize variables
                bItemListUpdated = false;

                // update items list
                lstItems.ItemsSource = itemsLogic.Items();

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
