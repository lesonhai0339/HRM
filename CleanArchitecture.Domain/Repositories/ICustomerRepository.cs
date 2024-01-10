using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repositories
{
    public interface ICustomerRepository: IEFRepository<Customer, Customer>
    {
        Task<List<Customer>> FindAll(CancellationToken cancellationToken = default);
        Task<Customer?> FindById(Guid Id, CancellationToken cancellationToken = default);
        Task<Customer?> FindByName(string Named, CancellationToken cancellationToken = default);
    }
}
