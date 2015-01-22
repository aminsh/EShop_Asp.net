using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Model
{
    public class EntityBasic : Entity
    {
        [Required(ErrorMessage = "کد الزامی میباشد")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "کد باید مابین 1 تا 50 کاراکتر باشد")]
        [Display(Name = "کد",Order = 2)]
        
        public virtual String No { get; set; }

        [Required(ErrorMessage = "نام الزامی میباشد")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "نام باید مابین 3 تا 50 کاراکتر باشد")]
        [Display(Name = "نام",Order = 3)]
        public virtual String Name { get; set; }

    }
}
