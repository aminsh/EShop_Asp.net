using System;

namespace Model
{
    public class ErrorLog:Entity
    {
        public virtual DateTime DateTime { get; set; }
        public virtual String Number { get; set; }
        public virtual String Message { get; set; }
        public virtual String Description { get; set; }
    }
}