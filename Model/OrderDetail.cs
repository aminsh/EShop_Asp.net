using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderDetail :Entity
    {
        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }

        public virtual Int32 OrderID { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        public Int32 ProductID { get; set; }

        public Int32 UnitPrice { get; set; }

        public Int32 Qty { get; set; }

        public Int32 Total
        {
            get { return UnitPrice*Qty; }
        }
    }
}
