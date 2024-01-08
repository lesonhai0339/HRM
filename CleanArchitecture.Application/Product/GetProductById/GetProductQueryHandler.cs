using CleanArchitecture.Application.Orders.GetOrderById;
using CleanArchitecture.Application.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Domain.Repositories;

namespace CleanArchitecture.Application.Product.GetProductById
{
    public class GetProductQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindByIdAsync(request.Id, cancellationToken);
            if (product == null)
            {
                throw new NotImplementedException();
            }
            return product.MapToProductDto(_mapper);
        }
    }
}
