//---------------------------------------------------------------------------
// <copyright file="GetCategoryListQuery.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Features.Products.Queries.GetCategoryList;

using AutoMapper;
using MediatR;
using Product.Application.Contracts.Repositories;
using Product.Application.Dtos;
using Product.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// CQRS query handler class for fetching list of categories.
/// </summary>
public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, List<CategoryDto>>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="GetCategoryListQueryHandler"/>.
    /// </summary>
    /// <param name="mapper">Domain to Application object mapper dependency.</param>
    /// <param name="categoryRepository">Data repository for <seealso cref="CategoryEntity"/> entity.</param>
    public GetCategoryListQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    /// <summary>
    /// Handler functionality for fetching list of product categories from the database.
    /// </summary>
    /// <param name="request">Incoming request object.</param>
    /// <param name="cancellationToken">Cancelation token object dependency.</param>
    /// <returns>Asynchronous task with collection <seealso cref="CategoryDto"/> objects.</returns>
    public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
    {
        var categoryList = await _categoryRepository.GetAllAsync();

        return _mapper.Map<List<CategoryDto>>(categoryList);
    }
}
