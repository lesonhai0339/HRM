using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
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
        private readonly ICurrentUserService _currentUser;
        public GetAllShopQueryHandler(IShopRepository shopRepository, IMapper mapper, ICurrentUserService currentUser)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<List<ShopDto>> Handle(GetAllShopQuery request, CancellationToken cancellationToken)
        {
            var user = _currentUser.UserId;
            if(user == null)
            {
                throw new NotFoundException("Does Not Authorize");
            }
            var listShop = await _shopRepository.FindAllAsync(cancellationToken);
            if(listShop == null)
            {
                throw new NotFoundException("Does Not Any Shop");
            }
            return listShop.MapToCustomerDtoList(_mapper);
        }
    }
}
