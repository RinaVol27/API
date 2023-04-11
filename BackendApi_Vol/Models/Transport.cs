using System;
using System.Collections.Generic;

namespace BackendApi_Vol.Models
{
    public partial class Transport
    {
        public Transport()
        {
            Deliveries = new HashSet<Delivery>();
        }

        public int IdTransport { get; set; }
        public string TransportName { get; set; } = null!;
        public string? NumberTr { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
