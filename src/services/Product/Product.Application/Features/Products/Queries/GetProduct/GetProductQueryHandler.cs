//---------------------------------------------------------------------------
// <copyright file="GetProductQueryHandler.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Features.Products.Queries.GetProduct;

using AutoMapper;
using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using Product.Application.Contracts;
using Product.Application.Dtos;
using System.Threading;
using System.Threading.Tasks;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ServiceResponse<ProductDto>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetProductQueryHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<ServiceResponse<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<ProductDto>();
        var product = await _productRepository.GetByIdAsync(request.ProductId);

        if (product is null)
        {
            response.Success = false;
            response.Message = "Sorry, but this product does not exists.";
        } else
        {
            response.Data = _mapper.Map<ProductDto>(product);
        }

        return response;
    }
}
