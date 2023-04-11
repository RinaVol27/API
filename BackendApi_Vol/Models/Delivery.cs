using System;
using System.Collections.Generic;

namespace BackendApi_Vol.Models
{
    public partial class Delivery
    {
        public Delivery()
        {
            UserOrders = new HashSet<UserOrder>();
        }

        public int IdDelivery { get; set; }
        public string DeliveryMethod { get; set; } = null!;
        public int? IdCourier { get; set; }
        public int? IdTransport { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Courier? IdCourierNavigation { get; set; }
        public virtual Transport? IdTransportNavigation { get; set; }
        public virtual ICollection<UserOrder> UserOrders { get; set; }
    }
}
