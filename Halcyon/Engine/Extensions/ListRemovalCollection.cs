//-----------------------------------------------------------------------------
// ListRemovalCollection.cs
//-----------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Halcyon
{
    /// <summary>
    /// A collection with an additional feature to isolate the
    /// removal of the objects.
    /// </summary>
    public class ListRemovalCollection<T> : List<T>
    {
        /// <summary>
        /// The list of objects to be removed on the next ApplyPendingRemovals().
        /// </summary>
        private List<T> pendingRemovals;

        /// <summary>
        /// Constructs a new collection.
        /// </summary>
        public ListRemovalCollection()
        {
            pendingRemovals = new List<T>();
        }

        /// <summary>
        /// Queue an item for removal.
        /// </summary>
        /// <param name="item"></param>
        public void QueuePendingRemoval(T item)
        {
            pendingRemovals.Add(item);
        }


        /// <summary>
        /// Remove all of the "garbage" objects from this collection.
        /// </summary>
        public void ApplyPendingRemovals()
        {
            for (int i = 0; i < pendingRemovals.Count; i++)
            {
                Remove(pendingRemovals[i]);
            }
            pendingRemovals.Clear();
        }
    }
}
