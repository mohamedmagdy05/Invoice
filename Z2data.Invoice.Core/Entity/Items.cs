using System;
using System.Collections.Generic;
using System.Text;

namespace Z2data.Invoice.Core.Entity
{
    public class Items
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public DateTime? ItemDate { get; set; }
        public int CategoryID { get; set; }

    }
}
