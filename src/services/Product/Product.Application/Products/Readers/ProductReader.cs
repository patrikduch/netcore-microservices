namespace Product.Application.Products.Readers;

using Dtos;
using Interfaces;
using Product.Application.Dtos;


public class ProductReader: IProductReader
{
    private readonly IProductReaderEf _productReaderEf;

    public ProductReader(IProductReaderEf productReaderEf)
    {
        _productReaderEf = productReaderEf;
    }

    public Task<ProductDetailDto?> GetProductDetail(Guid productId)
    {
        return _productReaderEf.FetchProductDetail(productId);
    }

    public Task<List<ProductDto>> GetProducts()
    {
        return _productReaderEf.FetchProducts();
    }

    public Task<List<ProductDto>> GetProducts(string categoryUrl)
    {
        return _productReaderEf.FetchProducts(categoryUrl);
    }

    public Task<List<ProductDto>> SearchProducts(string searchText)
    {
        return _productReaderEf.SearchProducts(searchText);
    }

    public Task<List<string>> GetProductSearchSuggestions(string searchText)
    {
        return _productReaderEf.FetchProductSearchSuggestions(searchText);
    }
}
