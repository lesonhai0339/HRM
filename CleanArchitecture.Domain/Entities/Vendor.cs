using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Vendor
    {
        public Guid     Id { get;set; }
        public string   Name { get; set; } = null!;

        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
