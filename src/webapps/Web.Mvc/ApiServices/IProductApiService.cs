namespace Web.Mvc.ApiServices;

using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

public interface IProductApiService
{
    Task<IEnumerable<ProductModel>> GetProducts();

    Task GetProduct(string id);

    Task<ProductModel> CreateProduct(ProductModel product);

    Task<ProductModel> IUpdateProduct(ProductModel product);

    Task DeleteProduct(string id);
}
