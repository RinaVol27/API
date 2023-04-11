using System;
using System.Collections.Generic;

namespace BackendApi_Vol.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Products = new HashSet<Product>();
        }

        public int IdManufacturer { get; set; }
        public string ManufName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
        public string Street { get; set; } = null!;
        public string House { get; set; } = null!;
        public int? Entrance { get; set; }
        public int? NumFloor { get; set; }
        public int? Apartment { get; set; }
        public int IndexUs { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
