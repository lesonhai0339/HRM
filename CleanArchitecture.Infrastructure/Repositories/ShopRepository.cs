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
    }
}
