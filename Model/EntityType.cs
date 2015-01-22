using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EntityType : Entity
    {
        [Required(ErrorMessage = "شرح الزامی میباشد")]
        [StringLength(50,MinimumLength = 3,ErrorMessage = "طول شرح باید مابین 3 تا 50 کاراکتر باشد")]
        public virtual String Des { get; set; }

        [Display(AutoGenerateField = false)]
        public virtual String FullName
        {
            get { return Des; }
        }

        [Display(AutoGenerateField = false)]
        public virtual String ShortName
        {
            get { return Des; }
        }
    }
}
