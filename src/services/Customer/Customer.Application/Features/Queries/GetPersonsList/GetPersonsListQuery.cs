using Customer.Application.Features.Queries.GetOrderList;
using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using System.Collections.Generic;

namespace Customer.Application.Features.Queries.GetAllCustomers
{
    /// <summary>
    /// CQRS query object for fetching list of customers.
    /// </summary>
    public class GetPersonsListQuery : IRequest<Result<List<PersonVm>>>
    {
      
    }
}
