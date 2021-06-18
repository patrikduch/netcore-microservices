using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NetMicroservices.MediatorWrapper.Nuget.Exceptions;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Commands.UpdateOrder
{
    /// <summary>
    /// CQRS command handler for updating particular <seealso cref="Order"/> entity.
    /// </summary>
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateOrderCommandHandler> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<UpdateOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetByIdAsync(request.Id);
            if (orderToUpdate == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);

                _logger.LogError("Order not exists on database.");
            }

            _mapper.Map(request, orderToUpdate, typeof(UpdateOrderCommand), typeof(Order));

            //await _orderRepository.UpdateAsync(orderToUpdate);

            _logger.LogInformation($"Order {orderToUpdate.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}
