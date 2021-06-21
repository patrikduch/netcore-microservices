using Customer.Application.Features.Queries.GetAllCustomers;
using Customer.Application.Features.Queries.GetOrderList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetMicroservices.ServiceConfig.Nuget;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediatR;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="CustomerController"/>.
        /// </summary>
        /// <param name="mediatR">Mediator dependency object.</param>
        public CustomerController(IMediator mediatR)
        {
            _mediatR = mediatR ?? throw new ArgumentNullException(nameof(mediatR));
        }


        /// <summary>
        /// Get the list of customers.
        /// </summary>
        /// <returns>Collection of all customers.</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<Result<PersonVm>>> GetPersonsList()
        {
            var query = new GetPersonsListQuery();
            var personsList = await _mediatR.Send(query);

            return Ok(personsList);
        }
    }
}
