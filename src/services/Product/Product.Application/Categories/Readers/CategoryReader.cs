namespace Product.Application.Categories.Readers;

using Dtos;
using Interfaces;
using Product.Application.Contracts.Readers;

public class CategoryReader : ICategoryReader
{
    private readonly ICategoryReaderEf _categoryReaderEf;

    public CategoryReader(ICategoryReaderEf categoryReaderEf)
    {
        _categoryReaderEf = categoryReaderEf;
    }

    public Task<List<CategoryDto>> GetCategoryList()
    {
        return _categoryReaderEf.FetchCategoryList();
    }
}
