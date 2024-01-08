using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Sale
    {
        public Guid     Id { get;set; }
        public decimal  Sumtotal { get; set; }

        public Guid CustomerId { get; set; }
        public Guid VendorId { get;set; }
        public Guid ShopId { get;set; }
        public Guid ProductId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Vendor   Vendor { get; set; } = null!;
        public virtual Shop     Shop { get; set; } = null!;
        public virtual Product  Product { get; set; } = null!;
    }
}
