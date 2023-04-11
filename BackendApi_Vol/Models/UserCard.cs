using System;
using System.Collections.Generic;

namespace BackendApi_Vol.Models
{
    public partial class UserCard
    {
        public UserCard()
        {
            Payments = new HashSet<Payment>();
        }

        public int IdCard { get; set; }
        public int NumberCard { get; set; }
        public int IdUser { get; set; }
        public bool? IsDelete { get; set; }

        public virtual SiteUser IdUserNavigation { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
