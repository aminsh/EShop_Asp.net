using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class ProductCategory : Entity
    {
        public virtual String Title { get; set; }

        public virtual String ImageUrl { get; set; }

        public virtual String ImageUrlThumb
        {
            get
            {
                var physicalPath = Path.GetDirectoryName(ImageUrl);
                string thumbfilename =
                        Path.GetFileNameWithoutExtension(ImageUrl)
                        + "_Thumb"
                        + Path.GetExtension(ImageUrl);

                return physicalPath + @"\" + thumbfilename;
            }
        }

        [Association("Product_Category", "ID", "ProductCategoryID")]
        public ICollection<Product> Products { get; set; }
    }
}
