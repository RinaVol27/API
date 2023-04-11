using System;
using System.Collections.Generic;

namespace BackendApi_Vol.Models
{
    public partial class OrderContent
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int IdOrder { get; set; }
        public int CountProduct { get; set; }
        public string Packaging { get; set; } = null!;
        public bool? IsDelete { get; set; }

        public virtual UserOrder IdOrderNavigation { get; set; } = null!;
        public virtual Product IdProductNavigation { get; set; } = null!;
        public virtual ProductPackaging PackagingNavigation { get; set; } = null!;
    }
}
