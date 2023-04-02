//---------------------------------------------------------------------------
// <copyright file="CategoryReaderTests.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Tests.Persistence.Readers;

using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Product.Persistence.Contexts;
using Product.Persistence.Readers;

public class CategoryReaderTests
{
    private readonly CategoryReader _categoryReader;
    private readonly Mock<IMapper> _mapper = new();

    public CategoryReaderTests()
    {
        var options = new DbContextOptionsBuilder<ProductContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        IMock<ProductContext> productCtx = new Mock<ProductContext>(options);

        _categoryReader = new CategoryReader(_mapper.Object, productCtx.Object);
    }

    [Fact]
    public async Task FetchCategories_CannotBeFetched_ReturnsNull()
    {
        var actual = await _categoryReader.FetchCategoryList();

        actual.Should().BeNull();
    }
}
