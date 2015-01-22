using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order :Entity
    {
        public virtual Int32 No { get; set; }

        public virtual DateTime Date { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        public virtual Int32 UserID { get; set; }

        public virtual String Description { get; set; }

        public virtual OrderType OrderType { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }

    public enum OrderType
    {
        Basket,
        Order,
        Fixed,
        Cancel
    }
}
