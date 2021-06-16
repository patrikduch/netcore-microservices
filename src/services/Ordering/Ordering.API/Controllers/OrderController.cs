using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Commands.CheckoutOrder;
using Ordering.Application.Features.Commands.DeleteOrder;
using Ordering.Application.Features.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Ordering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediatR;

        /// <summary>
        ///  Initializes a new instance of the webapi <seealso cref="OrderController"/>.
        /// </summary>
        /// <param name="mediatR">Mediator object dependency.</param>
        public OrderController(IMediator mediatR)
        {
            _mediatR = mediatR ?? throw new ArgumentNullException(nameof(mediatR));
        }


        /// <summary>
        /// Get orders by owner's username.
        /// </summary>
        /// <param name="userName">Owner's username.</param>
        /// <returns></returns>
        [HttpGet("{userName}", Name = "GetOrder")]
        [ProducesResponseType(typeof(IEnumerable<OrdersVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrdersVm>>> GetOrdersByUserName(string userName)
        {
            var query = new GetOrdersListQuery(userName);
            var orders = await _mediatR.Send(query);
            return Ok(orders);
        }

        /// <summary>
        /// Checkout specified order.
        /// </summary>
        /// <param name="command">Comannd for altering specified order.</param>
        /// <returns></returns>
        [HttpPost(Name = "CheckoutOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CheckoutOrder([FromBody] CheckoutOrderCommand command)
        {
            var result = await _mediatR.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Update specified order.
        /// </summary>
        /// <param name="command">Comannd for altering specified order.</param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            await _mediatR.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete order by numeric order's identifier.
        /// </summary>
        /// <param name="id">Numeric order identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var command = new DeleteOrderCommand() { Id = id };
            await _mediatR.Send(command);
            return NoContent();
        }
    }
}
