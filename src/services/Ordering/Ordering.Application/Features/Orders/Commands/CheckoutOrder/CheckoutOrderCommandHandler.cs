using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contacts.Infrastructure;
using Ordering.Application.Contacts.Persistence;
using Ordering.Application.Models;
using Ordering.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Commands.CheckoutOrder
{
    /// <summary>
    /// CQRS command handler for <seealso cref="CheckoutOrderCommand"/> class object.
    /// </summary>
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _mailService;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;

        /// <summary>
        /// Sending a brand new e-mail.
        /// </summary>
        /// <param name="order">Input <seealso cref="Order"/>object.</param>
        /// <returns>Asynchronous task.</returns>
        private async Task SendMail(Order order)
        {
            var email = new Email() { To = "duchpatrik@icloud.com", Body = $"Order was created.", Subject = "Order was created" };

            try
            {
                await _mailService.SendEmailAsync(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Order {order.Id} failed due to an error with the mail service: {ex.Message}");
            }
        }


        /// <summary>
        /// Initializes a new instance of the <seealso cref="CheckoutOrderCommandHandler"/>.
        /// </summary>
        /// <param name="orderRepository">Order data repository.</param>
        /// <param name="mapper">Domain mapper service dependency.</param>
        /// <param name="mailService">E-mail service dependency.</param>
        /// <param name="logger">Logger functionality dependency.</param>
        public CheckoutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IEmailService mailService, ILogger<CheckoutOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Command handler functionality for <seealso cref="CheckoutOrderCommand"/>.
        /// </summary>
        /// <param name="request">Incoming request object.</param>
        /// <param name="cancellationToken">Cancelation object.</param>
        /// <returns></returns>
        public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Order>(request);
            var newOrder = await _orderRepository.AddAsync(orderEntity);

            _logger.LogInformation($"Order {newOrder.Id} is successfully created.");

            return newOrder
                .Id;
        }
    }
}
