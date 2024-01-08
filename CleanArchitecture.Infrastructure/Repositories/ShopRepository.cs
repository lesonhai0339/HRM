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
    public class ShopRepository : RepositoryBase<Shop, Shop, ApplicationDbContext>, IShopRepository
    {
        public ShopRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<Shop?> FindById(Guid Id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.Id == Id, cancellationToken);
        }
    }
}
