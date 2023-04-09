//-----------------------------------------------------------------------------------
// <copyright file="ProductServiceTests.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//-----------------------------------------------------------------------------------
namespace Product.Tests.Persistence.Services;

using Application.Products.Interfaces;
using Application.Products.Dtos;
using FluentAssertions;
using Product.Persistence.Services;
using Moq;

/// <summary>
/// Unit tests for <seealso cref="ProductService"/>.
/// </summary>
public class ProductServiceTests
{
    private readonly Mock<IProductReader> _productReader = new();
    private readonly ProductService _productService;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="ProductServiceTests"/>.
    /// </summary>
    public ProductServiceTests()
    {
        _productService = new ProductService(_productReader.Object);
    }

    [Fact]
    public async Task GetProductDetail_SuccessFlow_ReturnsProductDetail()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var categoryId = Guid.NewGuid();
        var productVarians = new List<ProductDetailVariantDto>
        {
            new(Guid.NewGuid(), 250, 200, Guid.NewGuid(), new ProductTypeItemDto("Test"))

        };

        var productDetail = new ProductDetailDto(productId, "Product name", "Product description", "productImgUrl",
            categoryId, productVarians);

        _productReader.Setup(p => p.GetProductDetail(productId)).ReturnsAsync(productDetail);

        var actual = await _productService.GetProductDetail(productId);

        actual.Should().NotBeNull();
        actual.Should().BeEquivalentTo(productDetail);
    }

    [Fact]
    public async Task GetProductDetail_InvalidProductId_ReturnsNull()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var categoryId = Guid.NewGuid();

        var productDetail = new ProductDetailDto(productId, "Product name", "Product description", "productImgUrl",
            categoryId, null!);

        _productReader.Setup(p => p.GetProductDetail(Guid.NewGuid())).ReturnsAsync(productDetail);

        var actual = await _productService.GetProductDetail(productId);

        actual.Should().BeNull();
    }


    [Fact]
    public async Task GetProducts_SuccessFlow_ReturnsProductCollection()
    {
        // Arrange

        _productReader.Setup(p => p.GetProducts()).ReturnsAsync(new List<ProductDto>()
        {
            new(Guid.NewGuid(), "Product#1", "Product description", "http://image.url", Guid.NewGuid(), new List<ProductVariantDto>() )
        });

        // Act
        var actual = await _productService.GetProducts();

        // Assert
        actual.Should().HaveCountGreaterOrEqualTo(1);
    }


    [Fact]
    public async Task GetProducts_EmptyList_ReturnsEmptyCollection()
    {
        // Arrange

        _productReader.Setup(p => p.GetProducts()).ReturnsAsync(new List<ProductDto>());

        // Act
        var actual = await _productService.GetProducts();

        // Assert
        actual.Should().HaveCount(0);
    }


    [Fact]
    public async Task GetProductsByCategory_SuccessFlow_ReturnsProductCollection()
    {
        // Arrange

        var categoryUrl = "phones";
        
        _productReader.Setup(p => p.GetProducts(categoryUrl)).ReturnsAsync(new List<ProductDto>
        {
            new(Guid.NewGuid(), "Iphone X", "Iphone phone", "iphone.png", Guid.NewGuid(), new List<ProductVariantDto>()),
            new(Guid.NewGuid(), "Iphone 5S", "Old Iphone phone", "iphone-old.png", Guid.NewGuid(), new List<ProductVariantDto>()),
        });


        // Act
        var actual = await _productService.GetProductsByCategory(categoryUrl: "phones");

        // Assert
        actual.Should().HaveCountGreaterOrEqualTo(1);
    }


    [Fact]
    public async Task GetProductsByCategory_IncorrectCategoryName_ReturnsNull()
    {
        // Arrange

        var categoryUrl = "phones";

        _productReader.Setup(p => p.GetProducts(categoryUrl)).ReturnsAsync(new List<ProductDto>
        {
            new(Guid.NewGuid(), "Iphone X", "Iphone phone", "iphone.png", Guid.NewGuid(), new List<ProductVariantDto>()),
            new(Guid.NewGuid(), "Iphone 5S", "Old Iphone phone", "iphone-old.png", Guid.NewGuid(), new List<ProductVariantDto>()),
        });


        // Act
        var actual = await _productService.GetProductsByCategory(categoryUrl: "incorrect-category");

        // Assert
        actual.Should().BeNull();
    }
}
