//---------------------------------------------------------------------------
// <copyright file="GetCategoryListUseCaseHandler.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Categories.Handlers;

using Contracts.Services;
using Dtos;
using MediatR;
using UseCases;

/// <summary>
/// CQRS query handler class for fetching list of categories.
/// </summary>
public class GetCategoryListUseCaseHandler : IRequestHandler<GetCategoryListUseCase, List<CategoryDto>>
{
    private readonly ICategoryService _categoryService;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="GetCategoryListUseCaseHandler"/>.
    /// </summary>
    public GetCategoryListUseCaseHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    /// <summary>
    /// Handler functionality for fetching list of product categories from the database.
    /// </summary>
    /// <param name="request">Incoming request object.</param>
    /// <param name="cancellationToken">Cancellation token object dependency.</param>
    /// <returns>Asynchronous task with collection <seealso cref="CategoryDto"/> objects.</returns>
    public async Task<List<CategoryDto>> Handle(GetCategoryListUseCase request, CancellationToken cancellationToken)
    {
        return await _categoryService.GetCategoryList();
    }
}
