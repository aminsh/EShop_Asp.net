using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Vote : Entity
    {
        public virtual String Title { get; set; }

        public virtual ICollection<VoteItem> VoteItems { get; set; }
    }

    public class VoteItem : Entity
    {
        public virtual String Title { get; set; }

        [ForeignKey("VoteID")]
        public virtual Vote Vote { get; set; }

        public virtual Int32 VoteID { get; set; }
    }

    public class VoteUser : Entity
    {
        [ForeignKey("VoteItemID")]
        public virtual VoteItem VoteItem { get; set; }
        
        public virtual Int32 VoteItemID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        public virtual Int32 UserID { get; set; }
    }
}
