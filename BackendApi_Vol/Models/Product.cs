using System;
using System.Collections.Generic;

namespace BackendApi_Vol.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderContents = new HashSet<OrderContent>();
        }

        public int IdProduct { get; set; }
        public string ProductName { get; set; } = null!;
        public string Category { get; set; } = null!;
        public int CountProductOnWarehouse { get; set; }
        public int CountInBox { get; set; }
        public string? Color { get; set; }
        public string? Information { get; set; }
        public string Country { get; set; } = null!;
        public int IdManufacturer { get; set; }
        public int ExpirationDate { get; set; }
        public DateTime ProductionDate { get; set; }
        public decimal Price { get; set; }
        public string? ImagePr { get; set; }
        public decimal WeightPr { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ProductCategory CategoryNavigation { get; set; } = null!;
        public virtual Manufacturer IdManufacturerNavigation { get; set; } = null!;
        public virtual ICollection<OrderContent> OrderContents { get; set; }
    }
}
