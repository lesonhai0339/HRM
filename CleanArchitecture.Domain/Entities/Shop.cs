using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Shop
    {
        public Guid   Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = string.Empty;

        public virtual ICollection<Product> Products { get; set;} = new List<Product>();
        public virtual ICollection<Sale>    Sales { get; set; }= new List<Sale>(); 
    }
}
