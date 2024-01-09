using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repositories
{
    public interface ISaleRepository: IEFRepository<Sale, Sale>
    {
        Task<Sale?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<Sale>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default);
    }
}
