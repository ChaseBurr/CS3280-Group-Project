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
                // variables
                string sItemCode = "";
                string sItemDesc = "";
                int iCost = 0;

                // Check for null values
                if (txtbItemName.Text == "")
                {
                    tbMessage.Text = "Item Code cannot be empty";
                    tbMessage.Foreground = Brushes.Red;
                }

                // tryparse on text string from txtbItemCost.Text
                else if (Int32.TryParse(txtbItemCost.Text, out iCost) == false)
                {
                    // error message for cost
                    tbMessage.Text = "Cost is not in numeric format";
                    tbMessage.Foreground = Brushes.Red;
                }

                else if(txtbItemDescription.Text == "")
                {
                    tbMessage.Text = "Item Description cannot be empty";
                    tbMessage.Foreground = Brushes.Red;
                }

                else
                {
                    sItemCode = txtbItemName.Text;
                    sItemDesc = txtbItemDescription.Text;

                    // Logic needs to validate Item id does not exist already
                    if (itemsLogic.Add(sItemCode, sItemDesc, iCost))
                    {
                        bItemListUpdated = true;
                        tbMessage.Text = $"{sItemCode} Added" + System.Environment.NewLine +
                                        $"Cost: {iCost}" + System.Environment.NewLine +
                                        $"Description: {sItemDesc}";
                        tbMessage.Foreground = Brushes.Black;

                        // update items list
                        lstItems.ItemsSource = itemsLogic.Items();
                    }
                    else
                    {
                        bItemListUpdated = false;
                        tbMessage.Text = $"Error adding {sItemCode}" + System.Environment.NewLine +
                                        "Item may already exist in the database or a general error occurred";
                        tbMessage.Foreground = Brushes.Red;
                    }
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
                // variables
                string sItemCode = "";

                // Check for null values
                if (txtbItemName.Text == "")
                {
                    tbMessage.Text = "Item Code must be selected";
                    tbMessage.Foreground = Brushes.Red;
                }

                else
                {
                    // pass in the item code from the selection
                    sItemCode = txtbItemName.Text;

                    // Logic should not allow deletion if the item exists in an invoice
                    // Display error if error in deletion
                    if (itemsLogic.Delete(sItemCode))
                    {
                        bItemListUpdated = true;
                        tbMessage.Text = $"{sItemCode} Deleted from Items";
                        tbMessage.Foreground = Brushes.Black;

                        // update items list
                        lstItems.ItemsSource = itemsLogic.Items();
                    }
                    else
                    {
                        bItemListUpdated = false;
                        tbMessage.Text = $"Error deleting {sItemCode} from Items";
                        tbMessage.Foreground = Brushes.Red;

                        // list the invoices the item is on from the itemsLogic.dsItemOnInvoices
                        if (itemsLogic.dsItemOnInvoices.Tables[0].Rows.Count > 0)
                        {
                            tbMessage.Text = $"{sItemCode} Exists in the following invoices: " + System.Environment.NewLine;
                            
                            // append the invoice numbers
                            foreach (DataRow row in itemsLogic.dsItemOnInvoices.Tables[0].Rows)
                            {
                                tbMessage.Text += $"{row[0].ToString()}" + System.Environment.NewLine;
                            } 
                        }
                    }
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
                // pass in the data
                string sItemCode = "";
                string sItemDesc = "";
                int iCost = 0;

                // Check for null values
                if (txtbItemName.Text == "")
                {
                    tbMessage.Text = "Item Code cannot be empty";
                    tbMessage.Foreground = Brushes.Red;
                }

                // tryparse on text string from txtbItemCost.Text
                else if (Int32.TryParse(txtbItemCost.Text, out iCost) == false)
                {
                    // error message for cost
                    tbMessage.Text = "Cost is not in numeric format";
                    tbMessage.Foreground = Brushes.Red;
                }

                else if (txtbItemDescription.Text == "")
                {
                    tbMessage.Text = "Item Description cannot be empty";
                    tbMessage.Foreground = Brushes.Red;
                }

                else
                {
                    sItemCode = txtbItemName.Text;
                    sItemDesc = txtbItemDescription.Text;

                    // Logic should not allow edit of the code.
                    // Only allows edit of the description and cost.
                    if (itemsLogic.Update(sItemCode, sItemDesc, iCost))
                    {
                        bItemListUpdated = true;
                        tbMessage.Text = $"{sItemCode} Updated" + System.Environment.NewLine +
                                        $"Cost: {iCost}" + System.Environment.NewLine +
                                        $"Description: {sItemDesc}";
                        tbMessage.Foreground = Brushes.Black;

                        // update items list
                        lstItems.ItemsSource = itemsLogic.Items();
                    }
                    else
                    {
                        bItemListUpdated = false;
                        tbMessage.Text = $"Error updating {sItemCode}" + System.Environment.NewLine +
                                        "Item may not exist in the database or a general error occurred";
                        tbMessage.Foreground = Brushes.Red;
                    }
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
                // populate the Add/ Edit / Delete form window
                if (lstItems.SelectedItem != null)
                {
                    clsItem Item = (clsItem)lstItems.SelectedItem;
                    txtbItemName.Text = Item.sItemName;
                    txtbItemDescription.Text = Item.sItemDesc;
                    txtbItemCost.Text = Item.iItemCost.ToString();
                }
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
