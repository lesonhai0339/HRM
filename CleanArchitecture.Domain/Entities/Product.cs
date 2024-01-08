using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Product
    {
        public Guid     Id { get; set; }
        public string   Name { get; set; } = string.Empty;
        public decimal  Price { get; set; }

        public Guid CustomerId { get; set; }
        public Guid ShopId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Shop     Shop { get; set; } = null!;

        public virtual ICollection<Sale> Sales { get; set; }= new List<Sale>();
    }
}
