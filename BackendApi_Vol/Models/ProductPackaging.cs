using System;
using System.Collections.Generic;

namespace BackendApi_Vol.Models
{
    public partial class ProductPackaging
    {
        public ProductPackaging()
        {
            OrderContents = new HashSet<OrderContent>();
        }

        public string Packaging { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quality { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<OrderContent> OrderContents { get; set; }
    }
}
