//---------------------------------------------------------------------------
// <copyright file="GetCategoryListQuery.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Features.Products.Queries.GetCategoryList;

using MediatR;
using Product.Application.Dtos;

/// <summary>
/// CQRS query for fetching list of categories.
/// </summary>
public class GetCategoryListQuery : IRequest<List<CategoryDto>>
{
}
