using CS3280_Group_Project.Items;
using CS3280_Group_Project.Search;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Group_Project.Main
{
    class clsMainLogic
    {
		#region attributes
		/// <summary>
		/// holds sql queries
		/// </summary>
		private clsMainSQL sql;

		/// <summary>
		/// holds dataset values
		/// </summary>
		public DataSet ds;
        #endregion

        #region constructor

        /// <summary>
        /// clsMainLogic Constructor
        /// </summary>
        public clsMainLogic()
		{
			try
			{
				sql = new clsMainSQL();
				ds = new DataSet();
			}
			catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}

        #endregion

        #region logic functions
        /// <summary>
        /// adds invoice to db
        /// </summary>
        public void AddInvoice(List<clsItem> SelectedItems, double TotalCost)
        {
			try
			{
				int InvoiceNumber = sql.GetMaxInvoiceNumber() + 1;
				int LineItem = 1;
				string date = DateTime.UtcNow.ToString("MM/dd/yyyy");
				sql.InsertInvoice(date, TotalCost);
				foreach (var item in SelectedItems)
				{
					sql.InsertItem(InvoiceNumber, LineItem, item.sItemName);
					LineItem++;
				}
			}
			catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
        }

		/// <summary>
		/// removes invoice from db
		/// </summary>
		public void RemoveInvoice()
		{
			try
			{
				// remove invoice from db
			}
			catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}

		/// <summary>
		/// Adds item to the grid
		/// </summary>
		public void AddItem()
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
		/// saves invoice
		/// </summary>
		public void SaveInvoice()
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
    }

}
