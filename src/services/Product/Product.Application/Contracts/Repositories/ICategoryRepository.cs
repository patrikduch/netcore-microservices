//---------------------------------------------------------------------------
// <copyright file="ICategoryRepository.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Contracts.Repositories;

using NetMicroservices.SqlWrapper.Nuget;
using Product.Domain.Entities;

/// <summary>
/// Data layer contract for <seealso cref="CategoryEntity"/>.
/// </summary>
public interface ICategoryRepository : IAsyncRepository<CategoryEntity>
{

}
