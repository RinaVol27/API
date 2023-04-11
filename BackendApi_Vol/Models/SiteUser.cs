using System;
using System.Collections.Generic;

namespace BackendApi_Vol.Models
{
    public partial class SiteUser
    {
        public SiteUser()
        {
            UserCards = new HashSet<UserCard>();
            UserOrders = new HashSet<UserOrder>();
        }

        public int IdUser { get; set; }
        public string Surname { get; set; } = null!;
        public string? NameUser { get; set; }
        public string? Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Company { get; set; }
        public string City { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<UserCard> UserCards { get; set; }
        public virtual ICollection<UserOrder> UserOrders { get; set; }
    }
}
