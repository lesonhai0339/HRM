using CleanArchitecture.Application.Sales.CreateSale;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Sales.CreateSale
{
    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, Guid>
    {
        private readonly ISaleRepository _repository;

        public CreateSaleCommandHandler(ISaleRepository saleRepository)
        {
            _repository = saleRepository;
        }

        public async Task<Guid> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = new CleanArchitecture.Domain.Entities.Sale
            {
                Id = request.Id,
                Sumtotal = request.Sumtotal,
                CustomerId = request.CustomerId,
                VendorId = request.VendorId,
                ShopId = request.ShopId,
                ProductId = request.ProductId
            };

            _repository.Add(sale);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return sale.Id;
        }
    }
}
