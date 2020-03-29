using CS3280_Group_Project.Items;
using CS3280_Group_Project.Search;
using System;
using System.Collections.Generic;
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
		/// holds the list of items
		/// </summary>
		private List<clsItem> items;
        #endregion

        /// <summary>
        /// adds invoice to db
        /// </summary>
        public void AddInvoice()
        {
			try
			{
				// add invoice to db
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

		/// <summary>
		/// removes item from grid
		/// </summary>
		public void RemoveItem(object i)
		{
			try
			{
				// remove item from grid
			}
			catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " " + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}

    }

}
