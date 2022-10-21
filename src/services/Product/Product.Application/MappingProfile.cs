//---------------------------------------------------------------------------
// <copyright file="MappingProfile.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------

using AutoMapper;
using Product.Application.Dtos;
using Product.Domain.Entities;

namespace Product.Application;

/// <summary>
/// Mapping profiles of domain object to the application objects.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <seealso cref="MappingProfile"/> configuration.
    /// </summary>
    public MappingProfile()
    {
        CreateMap<ProductEntity, ProductDto>().ReverseMap();
        CreateMap<CategoryEntity, CategoryDto>().ReverseMap();
    }
}