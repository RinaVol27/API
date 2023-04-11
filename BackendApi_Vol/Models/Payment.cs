using System;
using System.Collections.Generic;

namespace BackendApi_Vol.Models
{
    public partial class Payment
    {
        public Payment()
        {
            UserOrders = new HashSet<UserOrder>();
        }

        public int IdPayment { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public string? Currency { get; set; }
        public int IdCard { get; set; }
        public bool? IsDelete { get; set; }

        public virtual UserCard IdCardNavigation { get; set; } = null!;
        public virtual ICollection<UserOrder> UserOrders { get; set; }
    }
}
