namespace Product.Tests.IntegrationTests.Persistence;

using Domain.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Product.Persistence.Contexts;
using Product.Persistence.Repositories;

public class CategoryDataRepositoryTests
{
    private static ProductContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<ProductContext>().UseInMemoryDatabase($"Test{Guid.NewGuid()}").Options;
        var context = new ProductContext(options);
        return context;
    }

    private static void SeedTestData(ProductContext context)
    {
        // Create a list of test product categories
        var categoryList = new List<CategoryEntity>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Games",
                Products = new List<ProductEntity>(),
                Url = "/games",
                CreatedAt = new DateTime(),
                CreatedBy = "patrikduch",
                LastModifiedBy = "patrikduch",
                LastModifiedDate = new DateTime(),
            }
        };

        // Add the test products to the context and save the changes
        context.Categories?.AddRange(categoryList);
        context.SaveChanges();
    }


    [Fact]
    public async Task GetCateogries_WithNotNullDataSet_ReturnsNotEmptyCollection()
    {
        var dbContext = GetDbContext();
        SeedTestData(dbContext);

        var repo = new CategoryRepository(dbContext);
        var result = await repo.GetAllAsync();

        result.Should().NotBeEmpty();
    }
}
