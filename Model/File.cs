using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.ServiceModel.DomainServices.Server;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FileX : Entity
    {
        [Display(Name = "نام و مسیر فایل", Order = 2)]
        public virtual String FileName { get; set; }

        [Display(Name = "عنوان", Order = 3)]
        public virtual String Title { get; set; }

        [Display(Name = "ساخته شده درتاریخ", Order = 4)]
        public virtual DateTime CreatedOnDateTime { get; set; }

        [Include]
        [Association("File_User", "UserID", "ID", IsForeignKey = true)]
        [ForeignKey("UserID")]
        [Display(Name = "ساخته شده توسط", Order = 5)]
        public virtual User User { get; set; }

        public virtual Int32 UserID { get; set; }
    }
}
