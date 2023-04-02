namespace Product.Application.Categories.Interfaces;

using Dtos;

public interface ICategoryReader
{
    Task<List<CategoryDto>> GetCategoryList();
}
