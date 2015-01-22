using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product : Entity
    {
        public virtual String Title { get; set; }

        public virtual String Description { get; set; }

        public virtual Int32 Price { get; set; }

        public virtual String ImageUrl { get; set; }

        [Association("Product_Category", "ProductCategoryID", "ID", IsForeignKey = true)]
        [ForeignKey("ProductCategoryID")]
        public ProductCategory ProductCategory { get; set; }

        public Int32 ProductCategoryID { get; set; }
    }

    
}
