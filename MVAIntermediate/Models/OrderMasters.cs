using System;
using System.Collections.Generic;

namespace MVAIntermediate.Models
{
    public partial class OrderMasters
    {
        public int OrderNo { get; set; }
        public string TableId { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public string WaiterName { get; set; }
    }
}
