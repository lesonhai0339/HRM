using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Shops.Commands.Create
{
    public class CreateShopCommandHandler : IRequestHandler<CreateShopCommand, ShopDto>
    {
        private readonly IShopRepository _shopRepository;
        private readonly IMapper _mapper;

        public CreateShopCommandHandler(IShopRepository shopRepository, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
        }

        public async Task<ShopDto> Handle(CreateShopCommand request, CancellationToken cancellationToken)
        {
            var shop = new Shop
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
            };
            _shopRepository.Add(shop);
            await _shopRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return shop.MapToShopDto(_mapper);
        }
    }
}
