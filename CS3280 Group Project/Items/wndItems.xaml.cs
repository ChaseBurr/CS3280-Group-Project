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
        /// Constructor
        /// </summary>
        public wndItems()
        {
            InitializeComponent();
            bItemListUpdated = false;
        }

        /// <summary>
        /// Add Item button click event for adding items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            // TODO: calls business logic of clsItemsLogic.cs
                // Logic needs to validate Item id does not exist already
        }

        /// <summary>
        /// Delete Item button click event for record deletion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            // TODO: calls business logic of clsItemsLogic.cs. 
                // Logic should not allow deletion if the item exists in an invoice
                // Display error if error in deletion
        }

        /// <summary>
        /// Edit Item button click event for editing Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditItem_Click(object sender, RoutedEventArgs e)
        {
            // TODO: calls business logic of clsItemsLogic.cs
                // Logic should not allow edit of the code.
                // Only allows edit of the description and cost.
        }

        /// <summary>
        /// List view selection event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: populate the Add/ Edit / Delete form window
        }

        /// <summary>
        /// Window closing event 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // TODO: handle any notifications (if needed) back to main window
        }

        /// <summary>
        /// Window loaded event used for setting default settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bItemListUpdated = false;
        }        
    }
}
