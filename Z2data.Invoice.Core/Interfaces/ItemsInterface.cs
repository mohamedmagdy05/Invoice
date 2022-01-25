using System;
using System.Collections.Generic;
using System.Text;
using Z2data.Invoice.Core.Entity;

namespace Z2data.Invoice.Core.Interfaces
{
    public interface ItemsInterface
    {
        /// <summary>
        /// Get all Items 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Items> GetItems();
        /// <summary>
        /// Get Item By id 
        /// </summary>
        /// <param name="ID">int Param</param>
        /// <returns></returns>
        Items GetItemsById(int ID);
        /// <summary>
        /// add new Items
        /// </summary>
        /// <param name="items">Object Param</param>
        Items AddItems(Items items);
        /// <summary>
        /// delete exist Items
        /// </summary>
        /// <param name="ID">int Param</param>
        Items DeleteItems(int ID);
        /// <summary>
        /// update exist Items
        /// </summary>
        /// <param name="items">Object Param</param>
        /// <returns></returns>
        Items UpdateItems(Items items);
    }
}
