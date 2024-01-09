using CleanArchitecture.Application.Sales.DeleteSale;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Sales.DeleteSale
{
    public class DeleteSaleCommandHandler : IRequestHandler<DeleteSaleCommand, Guid>
    {
        private readonly ISaleRepository _repository;

        public DeleteSaleCommandHandler(ISaleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = await _repository.FindByIdAsync(request.SaleId, cancellationToken);

            if (sale != null)
            {
                _repository.Remove(sale);
                await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return sale.Id;
            }

            return Guid.Empty;
        }
    }
}
