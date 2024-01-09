using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;


        public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _repository.FindByIdAsync(request.ProductId, cancellationToken);

            if (existingProduct == null)
            {
                throw new NotFoundException($"Product with ID {request.ProductId} not found.");
            }

            existingProduct.Name = request.NewProductName;
            existingProduct.Price = request.NewPrice;

            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ProductDto>(existingProduct);
        }
    }
}
