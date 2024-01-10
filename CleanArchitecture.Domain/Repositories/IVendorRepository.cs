using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repositories
{
    public interface IVendorRepository : IEFRepository<Vendor, Vendor>
    {
        Task<Vendor?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<Vendor>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default);
    }
}
