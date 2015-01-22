using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class User:Entity
   {
       [Display(Name = "نام")]
       public virtual String FirstName { get; set; }

       [Display(Name = "نام خانوادگی")]
       public virtual String LastName { get; set; }

       [Display(Name = "نام کاربری")]
       public virtual String Username { get; set; }

       [Display(Name = "کلمه عبور")]
       public virtual String Password { get; set; }

       public virtual String Email { get; set; }

       public virtual String Phone { get; set; }

       public virtual String Address { get; set; }

       [Association("User_Role", "RoleID", "ID", IsForeignKey = true)]
       [ForeignKey("RoleID")]
       public virtual Role Role { get; set; }

       public virtual Int32 RoleID { get; set; }

       public virtual String FullName { get { return FirstName + " " + LastName; } }

       //public virtual ICollection<Order> Orders { get; set; }
   }
}
