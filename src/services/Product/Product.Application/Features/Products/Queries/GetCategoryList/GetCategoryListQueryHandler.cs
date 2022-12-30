//---------------------------------------------------------------------------
// <copyright file="GetCategoryListQuery.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Features.Products.Queries.GetCategoryList;

using MediatR;
using Product.Application.Contracts.Services;
using Product.Application.Dtos;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// CQRS query handler class for fetching list of categories.
/// </summary>
public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, List<CategoryDto>>
{
    private readonly ICategoryService _categoryService;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="GetCategoryListQueryHandler"/>.
    /// </summary>
    public GetCategoryListQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    /// <summary>
    /// Handler functionality for fetching list of product categories from the database.
    /// </summary>
    /// <param name="request">Incoming request object.</param>
    /// <param name="cancellationToken">Cancelation token object dependency.</param>
    /// <returns>Asynchronous task with collection <seealso cref="CategoryDto"/> objects.</returns>
    public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
    {
        return await _categoryService.GetCategoryList();
    }
}
