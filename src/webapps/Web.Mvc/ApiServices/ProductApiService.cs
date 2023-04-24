namespace Web.Mvc.ApiServices;

using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

public class ProductApiService : IProductApiService
{
    public Task<IEnumerable<ProductModel>> GetProducts()
    {
        throw new System.NotImplementedException();
    }

    public Task GetProduct(string id)
    {
        throw new System.NotImplementedException();
    }

    public Task<ProductModel> CreateProduct(ProductModel product)
    {
        throw new System.NotImplementedException();
    }

    public Task<ProductModel> IUpdateProduct(ProductModel product)
    {
        throw new System.NotImplementedException();
    }

    public Task DeleteProduct(string id)
    {
        throw new System.NotImplementedException();
    }
}
