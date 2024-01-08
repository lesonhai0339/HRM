using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Shops.Commands.Delete
{
    public class DeleteShopCommandHandler : IRequestHandler<DeleteShopCommand, bool>
    {
        private readonly IShopRepository _shopRepository;

        public DeleteShopCommandHandler(IShopRepository shopRepository, IMapper mapper)
        {
            _shopRepository = shopRepository;
        }

        public async Task<bool> Handle(DeleteShopCommand request, CancellationToken cancellationToken)
        {
            var shop = await _shopRepository.FindById(request.Id);
            if (shop == null || shop.Products.Any()  || shop.Sales.Any())
            {
                return false;
            }
            _shopRepository.Remove(shop);
            await _shopRepository.UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
