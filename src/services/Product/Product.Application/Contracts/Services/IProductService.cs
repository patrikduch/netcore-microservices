//---------------------------------------------------------------------------
// <copyright file="IProductService.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Contracts.Services;

using Product.Application.Dtos;

public interface IProductService
{
    Task<ProductDto> GetProductDetail(Guid productId);
}
