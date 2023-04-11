using System;
using System.Collections.Generic;

namespace BackendApi_Vol.Models
{
    public partial class Courier
    {
        public Courier()
        {
            Deliveries = new HashSet<Delivery>();
        }

        public int IdCourier { get; set; }
        public string Surname { get; set; } = null!;
        public string? NameCourier { get; set; }
        public string? Patronymic { get; set; }
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
        public int Rating { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
