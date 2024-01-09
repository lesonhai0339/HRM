using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Shops.Commands.Update
{
    public class UpdateShopCommandHandler : IRequestHandler<UpdateShopCommand, ShopDto>
    {
        private readonly IShopRepository _shopRepository;
        private readonly IMapper _mapper;

        public UpdateShopCommandHandler(IShopRepository shopRepository, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
        }

        public async Task<ShopDto> Handle(UpdateShopCommand request, CancellationToken cancellationToken)
        {
            var shop = await _shopRepository.FindById(request.Id);
            if (shop == null) 
            {
                throw new NotFoundException("Shop Does Not Exist");
            }
            shop.Name = request.Name;
            shop.Address = request.Address;
            shop.PhoneNumber = request.PhoneNumber;
            _shopRepository.Update(shop);
            await _shopRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return shop.MapToShopDto(_mapper);
        }
    }
}
