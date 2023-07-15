using NetMicroservices.ServiceConfig.Nuget;
using Web.Mvc.Models;

namespace Web.Mvc.ApiServices;

public interface IProductService
{
    Task<ServiceResponse<Product>> GetProductAsync(Guid id);
}
