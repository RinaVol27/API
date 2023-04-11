using System;
using System.Collections.Generic;

namespace BackendApi_Vol.Models
{
    public partial class UserOrder
    {
        public UserOrder()
        {
            OrderContents = new HashSet<OrderContent>();
        }

        public int IdOrder { get; set; }
        public int IdUser { get; set; }
        public int? AssemblyPeriod { get; set; }
        public int IdPayment { get; set; }
        public int IdDelivery { get; set; }
        public DateTime OrderDate { get; set; }
        public string? Information { get; set; }
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string House { get; set; } = null!;
        public int? Entrance { get; set; }
        public int? NumFloor { get; set; }
        public int? Apartment { get; set; }
        public int IndexUs { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Delivery IdDeliveryNavigation { get; set; } = null!;
        public virtual Payment IdPaymentNavigation { get; set; } = null!;
        public virtual SiteUser IdUserNavigation { get; set; } = null!;
        public virtual ICollection<OrderContent> OrderContents { get; set; }
    }
}
