using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Model
{
    [XmlInclude(typeof(Report))]
    public class Entity
    {
        [Display(Name = "شناسه", Order = 1)]
        [Key]
        [ReadOnly(true)]
        public virtual Int32 ID { get; set; }

        [Display(AutoGenerateField = false)]
        [ConcurrencyCheck]
        [Timestamp]
        public virtual Byte[] EntityToken { get; set; }
    }
}
