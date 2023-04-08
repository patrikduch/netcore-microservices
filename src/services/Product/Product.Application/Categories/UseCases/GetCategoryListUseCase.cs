//---------------------------------------------------------------------------
// <copyright file="GetCategoryListUseCase.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//----------------------------------------------------------------------------
namespace Product.Application.Categories.UseCases;

using Dtos;
using MediatR;

/// <summary>
/// CQRS read action operation for fetching list of categories.
/// </summary>
public class GetCategoryListUseCase : IRequest<List<CategoryDto>>
{

}
