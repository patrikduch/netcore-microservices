namespace Web.Mvc.ApiServices;

using Models;
using NetMicroservices.ServiceConfig.Nuget;

public interface IProductService
{
    Task<ServiceResponse<List<Product>>> GetProductAsync(Guid id);
}
