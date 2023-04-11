using System;
using System.Collections.Generic;

namespace BackendApi_Vol.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        public string Category { get; set; } = null!;
        public string Information { get; set; } = null!;
        public bool? IsDelete { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
