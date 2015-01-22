using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    [XmlRoot("Report")]
    //[XmlInclude(typeof(SqlCommandType))]
    public class Report 
    {
        [XmlAttribute("ID")]
        public virtual Int32 ID { get; set; }
        [XmlAttribute("Title")]
        public virtual String Title { get; set; }
        [XmlAttribute("Des")]
        public virtual String Des { get; set; }
        [XmlAttribute("SqlText")]
        public virtual String SqlText { get; set; }
        [XmlAttribute("Parameter")]
        public virtual String Parameter { get; set; }
        [XmlAttribute("SqlCommandType")]   
        public virtual String SqlCommandType { get; set; }
        [XmlAttribute("FileName")]
        public virtual String FileName { get; set; }

    }

 
    public enum SqlCommandType
    {
        [XmlEnum(Name = "Query")]
        Query,
        [XmlEnum(Name = "StoredProcedure")]
        StoredProcedure,
        [XmlEnum(Name = "Command")]
        Command
    }

   
}
