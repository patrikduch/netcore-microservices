using Customer.Application.Features.Queries.GetOrderList;
using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using System;
using System.Collections.Generic;

namespace Customer.Application.Features.Queries.GetAllCustomers
{
    /// <summary>
    /// 
    /// </summary>
    public class GetPersonsListQuery : IRequest<Result<List<PersonVm>>>
    {
      
    }
}
