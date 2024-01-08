using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Shops.Querys.GetAll
{
    public class GetAllShopQueryHandler : IRequestHandler<GetAllShopQuery, List<ShopDto>>
    {

        private readonly IShopRepository  _shopRepository;
        private readonly IMapper _mapper;

        public GetAllShopQueryHandler(IShopRepository shopRepository, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
        }

        public async Task<List<ShopDto>> Handle(GetAllShopQuery request, CancellationToken cancellationToken)
        {
            var listShop = await _shopRepository.FindAllAsync(cancellationToken);
            if(listShop == null)
            {
                throw new NotFoundException("Does Not Any Shop");
            }
            return listShop.MapToCustomerDtoList(_mapper);
        }
    }
}
