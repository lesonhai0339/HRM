using AutoMapper;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Orders.GetOrderById
{
    public class GetOrderQueryHandler: IRequestHandler<GetOrderQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public GetOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order= await _orderRepository.FindByIdAsync(request.Id, cancellationToken);
            if (order == null)
            {
                throw new NotImplementedException();
            }
            return order.MapToOrderDto(_mapper);
        }
    }
}
