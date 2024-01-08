using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer, Customer, ApplicationDbContext>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<List<Customer>> FindAll(CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(cancellationToken);
        }
        public async Task<Customer?> FindById(Guid Id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x=> x.Id == Id, cancellationToken);
        }
        //public void AddCustomer(Customer customer)
        //{
        //    Add(customer);
        //}
        //public void UpdateCustomer(Customer customer)
        //{
        //    Update(customer);
        //}
        //public void DeleteCustomer(Customer customer)
        //{
        //    Remove(customer);
        //}
    }
}
