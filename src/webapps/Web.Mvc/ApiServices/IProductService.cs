// <copyright file="IProductService.cs" company="Patrik Duch">
// Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
namespace Web.Mvc.ApiServices;

using Models;
using NetMicroservices.ServiceConfig.Nuget;

public interface IProductService
{
    Task<ServiceResponse<List<Product>>> GetProductAsync(Guid id);
}
