//---------------------------------------------------------------------------
// <copyright file="CategoryReaderTests.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------

namespace Product.Tests.UnitTests.Persistence.Services;

using Application.Categories.Dtos;
using Application.Categories.Interfaces;
using FluentAssertions;
using Moq;
using Product.Persistence.Services;

public class CategoryServiceTests
{
    private readonly Mock<ICategoryReader> _categoryReader = new();

    public CategoryServiceTests()
    {
        _categoryReader.Setup(c => c.GetCategoryList()).ReturnsAsync(new List<CategoryDto>());
    }

    [Fact]
    public async Task FetchCategories_CannotBeFetched_ReturnsNull()
    {
        var categoryService = new CategoryService(_categoryReader.Object);
        var actual = await categoryService.GetCategoryList();
        actual.Should().HaveCount(0);
    }
}
