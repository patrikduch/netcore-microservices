using AutoMapper;
using Customer.Application.Contracts;
using Customer.Application.Features.Queries.GetAllCustomers;
using Customer.Application.Features.Queries.GetOrderList;
using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServiceBase = NetMicroservices.ServiceConfig.Nuget.ServiceBase;

namespace Customer.Application.Features.Queries.GetPersonsList
{
    public class GetPersonsListQueryHandler : ServiceBase, IRequestHandler<GetPersonsListQuery, Result<List<PersonVm>>>
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;
       
        public GetPersonsListQueryHandler(IMapper mapper, IPersonRepository personRepository)
        {
            _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<List<PersonVm>>> Handle(GetPersonsListQuery request, CancellationToken cancellationToken)
        {
            var personList = await _personRepository.GetAllAsync();

            return Ok(_mapper.Map<List<PersonVm>>(personList));
        }
    }
}
