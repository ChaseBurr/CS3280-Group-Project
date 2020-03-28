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

namespace CS3280_Group_Project.Items
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        public wndMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Opens the search window when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchForInvoice(object sender, RoutedEventArgs e)
        {
            try
            {
                wndSearch search = new wndSearch();
                App.Current.MainWindow = search;
                search.Show();

                MainMenuGrid.Visibility = Visibility.Hidden;

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void AddInvoice(object sender, RoutedEventArgs e)
        {

        }

        private void EditInvoice(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteInvoice(object sender, RoutedEventArgs e)
        {

        }
    }
}
