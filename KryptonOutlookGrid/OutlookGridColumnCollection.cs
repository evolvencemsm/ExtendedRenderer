using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AC.ExtendedRenderer.Toolkit.KryptonOutlookGrid
{
    /// <summary>
    /// List of the current columns of the OutlookGrid
    /// </summary>
    public class OutlookGridColumnCollection : List<OutlookGridColumn>
    {
        private int maxGroupOrder;

        /// <summary>
        /// Constructor
        /// </summary>
        public OutlookGridColumnCollection()
            : base()
        {
            maxGroupOrder = 0;
        }

        /// <summary>
        /// Gets the OutlookGridColumn in the list by its name
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <returns>OutlookGridColumn</returns>
        public OutlookGridColumn this[string columnName]
        {
            get
            {
                return this.Find(c => c.DataGridViewColumn.Name.Equals(columnName));
            }
        }

        public int MaxGroupOrder
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the number of columns grouped
        /// </summary>
        /// <returns>the number of columns grouped.</returns>
        public int CountGrouped()
        {
            return this.Count(c => c.IsGrouped == true);
        }

        /// <summary>
        /// Gets the list of grouped columns
        /// </summary>
        /// <returns>The list of grouped columns.</returns>
        public List<OutlookGridColumn> GroupedColumns()
        {
            return this.Where(c => c.IsGrouped).OrderBy(c => c.GroupOrder).ToList();
        }

        /// <summary>
        /// Gets the column from its real index (from the underlying DataGridViewColumn)
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The OutlookGridColumn.</returns>
        public OutlookGridColumn FindFromColumnIndex(int index)
        {
            return this.FirstOrDefault(c => c.DataGridViewColumn.Index == index);
        }

        /// <summary>
        /// Gets the index (from DataGridViewColumn) of the sorted column that is not grouped if it exists.
        /// </summary>
        /// <returns>-1 if any, the index of the underlying DataGridViewColumn otherwise</returns>
        public int FindSortedColumnNotgrouped()
        {
            var res = this.Find(c => !c.IsGrouped && (c.SortDirection != SortOrder.None));
            if (res == null)
            { 
                return -1;
            }
            else
            {
                return res.DataGridViewColumn.Index;
            }
        }

        /// <summary>
        /// Removes a groupOrder and update the groups order for all columns
        /// </summary>
        /// <param name="removed">The order that will be removed.</param>
        internal void RemoveGroupOrder(int removed)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].GroupOrder > removed)
                {
                    this[i].GroupOrder--;
                }
            }
            maxGroupOrder--;
        }
    }
}
