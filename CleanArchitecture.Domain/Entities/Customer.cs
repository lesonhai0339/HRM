using CleanArchitecture.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Customer
    {
        public Guid     Id { get; set; } 
        public string   Name { get; set; } = string.Empty;
        public string   PhoneNumber { get; set; } = string.Empty;
        public string   Address { get; set; }= string.Empty;
        public string   Password { get; set; } = null!;
        public Role     Role { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        public virtual ICollection<Sale>    Sales { get; set; }= new List<Sale>();
    }
}
