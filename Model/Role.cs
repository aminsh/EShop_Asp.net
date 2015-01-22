using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Role : Entity
    {
        public String Name { get; set; }
        public String Title { get; set; }

        //[Association("Role_User", "ID", "RoleID")]
        //public ICollection<User> Users { get; set; }
    }
}
