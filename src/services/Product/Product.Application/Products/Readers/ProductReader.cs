//-----------------------------------------------------------------------------------
// <copyright file="ProductReader.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//-----------------------------------------------------------------------------------
namespace Product.Application.Products.Readers;

using Dtos;
using Interfaces;
using Product.Application.Products.Interfaces.Readers;

/// <summary>
/// Encapsulation of read functionality in context of products.
/// </summary>
public class ProductReader: IProductReader
{
    private readonly IProductReaderEf _productReaderEf;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="ProductReader"/>.
    /// </summary>
    public ProductReader(IProductReaderEf productReaderEf)
    {
        _productReaderEf = productReaderEf;
    }

    /// <summary>
    /// Get prodduct by identifier.
    /// </summary>
    /// <param name="productId">Product unique idenfifier.</param>
    /// <returns>Product information.</returns>
    public Task<ProductDetailDto?> GetProductDetail(Guid productId)
    {
        return _productReaderEf.FetchProductDetail(productId);
    }

    /// <summary>
    /// Get products without any restrictions.
    /// </summary>
    /// <returns>Collection of <seealso cref="ProductDto"/>.</returns>
    public Task<List<ProductDto>> GetProducts()
    {
        return _productReaderEf.FetchProducts();
    }

    /// <summary>
    /// Get products by particular category.
    /// </summary>
    /// <param name="categoryUrl">Category url that will be used to filter the results.</param>
    /// <returns></returns>
    public Task<List<ProductDto>> GetProducts(string categoryUrl)
    {
        return _productReaderEf.FetchProducts(categoryUrl);
    }

    /// <summary>
    /// Search products by particular keyword aka "searchText".
    /// </summary>
    /// <param name="searchText">Search text that will be used for filtering the search results.</param>
    /// <returns>Collection of products.</returns>
    public Task<List<ProductDto>> SearchProducts(string searchText)
    {
        return _productReaderEf.SearchProducts(searchText);
    }

    /// <summary>
    /// Get search suggestion by search text.
    /// </summary>
    /// <param name="searchText">Search text that will be used for filtering purposes.</param>
    /// <returns>Collection of strings, which represents product name suggestions.</returns>
    public Task<List<string>> GetProductSearchSuggestions(string searchText)
    {
        return _productReaderEf.FetchProductSearchSuggestions(searchText);
    }
}
