

using System;
using System.Collections.Generic;

using System.Text;

namespace AC.ExtendedRenderer.Toolkit.KryptonOutlookGrid
{
    /// <summary>
    /// List of IOutlookGridGroups
    /// </summary>
    public class OutlookGridGroupCollection
    {
        #region "Variables"
        private IOutlookGridGroup parentGroup;
        private List<IOutlookGridGroup> groupList;
        #endregion

        #region "Constructor"
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parentGroup">Parent group , if any</param>
        public OutlookGridGroupCollection(IOutlookGridGroup parentGroup)
        {
            groupList = new List<IOutlookGridGroup>();
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or Sets the parent group
        /// </summary>
        public IOutlookGridGroup ParentGroup
		{
			get
			{
				return this.parentGroup;
			}
			internal set
			{
				this.parentGroup = value;
			}
		}

        /// <summary>
        /// Gets the list of IOutlookGridGroup.
        /// </summary>
        public List<IOutlookGridGroup> List
        {
            get
            {
                return groupList;
            }
        }

        /// <summary>
        /// Gets the number of groups
        /// </summary>
        public int Count
        {
            get
            {
                return groupList.Count;
            }
        }

        #endregion

        #region "Public methods"

        /// <summary>
        /// Gets the Group object
        /// </summary>
        /// <param name="index">Index in the list of groups.</param>
        /// <returns>The IOutlookGridGroup.</returns>
        public IOutlookGridGroup this[int index]
        {
            get
            {
                return groupList[index];
            }
        }

        /// <summary>
        /// Adds a new group
        /// </summary>
        /// <param name="group">The IOutlookGridGroup.</param>
        public void Add(IOutlookGridGroup group)
		{
            groupList.Add(group);
		}

        /// <summary>
        /// Sorts the groups
        /// </summary>
        public void Sort()
        {
            groupList.Sort();
        }

        /// <summary>
        /// Find a group by its value
        /// </summary>
        /// <param name="value">The value of the group</param>
        /// <returns>The IOutlookGridGroup.</returns>
        public IOutlookGridGroup FindGroup(object value)
        {
            return groupList.Find(c => c.Value.Equals(value));
        }

        #endregion

        #region "Internals"

        internal void Clear()
        {
            parentGroup = null;
            //If a group is collapsed the rows will not appear. Then if we clear the group the rows should not remain "collapsed"
            for (int i = 0; i < groupList.Count; i++)
            {
                groupList[i].Collapsed = false;
            }
            groupList.Clear();
        }

        #endregion
    }
}
