using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Group_Project.Items
{
    /// <summary>
    /// Item object for interaction with
    /// </summary>
    public class clsItem
    {
        /// <summary>
        /// property for Item name
        /// </summary>
        public string sItemName { get; set; }

        /// <summary>
        /// property for Item description
        /// </summary>
        public string sItemDesc { get; set; }

        /// <summary>
        /// property for Item cost
        /// </summary>
        public int iItemCost { get; set; }
    }

    /// <summary>
    /// IComparer for sorting the item name
    /// </summary>
    public class clsItemComparer : IComparer<clsItem>
    {
        /// <summary>
        /// Compares the item objects name
        /// </summary>
        /// <param name="itemL"></param>
        /// <param name="itemR"></param>
        /// <returns></returns>
        public int Compare(clsItem itemL, clsItem itemR)
        {
            try
            {
                // compares the string and returns the int for sorting back to caller
                return (itemL.sItemName.CompareTo(itemR.sItemName));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
