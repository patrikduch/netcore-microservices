using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Exceptions;
using Ordering.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Commands.DeleteOrder
{
    /// <summary>
    /// CQRS handler functionality for removing orders.
    /// </summary>
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteOrderCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="DeleteOrderCommandHandler"/>.
        /// </summary>
        /// <param name="orderRepository"><seealso cref="IOrderRepository"/>. data repository dependency.</param>
        /// <param name="mapper">Domain to Application object mapper dependency.</param>
        /// <param name="logger">Logger functionality dependency.</param>
        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<DeleteOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Execution of DeleteOrderCommandHandler 
        /// </summary>
        /// <param name="request">Incoming request that is handled by this CQRS command handler.</param>
        /// <param name="cancellationToken">Cancelation token object handler.</param>
        /// <returns>Single CQRS asynchronous Unit.</returns>
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToDelete = await _orderRepository.GetByIdAsync(request.Id);
            if (orderToDelete == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            await _orderRepository.DeleteAsync(orderToDelete);

            _logger.LogInformation($"Order {orderToDelete.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}
