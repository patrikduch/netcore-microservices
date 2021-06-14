using AutoMapper;
using MediatR;
using Ordering.Application.Contacts.Persistence;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    /// <summary>
    /// Mediator handler of <seealso cref="GetOrdersListQuery"/> object. 
    /// </summary>
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrdersVm>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="GetOrdersListQueryHandler"/> request query handler mediator object.
        /// </summary>
        /// <param name="orderRepository">Data repository</param>
        /// <param name="mapper"></param>
        public GetOrdersListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        /// <summary>
        /// Handler for <seealso cref="GetOrdersListQuery"/> object. 
        /// </summary>
        /// <param name="request">Incoming <seealso cref="GetOrdersListQuery"/> object.</param>
        /// <param name="cancellationToken">Cancelation token object.</param>
        /// <returns></returns>
        public async Task<List<OrdersVm>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetOrdersByUserName(request.Username);
            return _mapper.Map<List<OrdersVm>>(orderList);
        }
    }

}
