//---------------------------------------------------------------------------
// <copyright file="IProductRepository.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Contracts;

using NetMicroservices.SqlWrapper.Nuget;
using Product.Domain.Entities;

public interface IProductRepository : IAsyncRepository<ProductEntity>
{
}
