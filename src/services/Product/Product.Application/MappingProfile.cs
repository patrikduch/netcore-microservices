//---------------------------------------------------------------------------
// <copyright file="MappingProfile.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application;

using AutoMapper;
using Product.Application.Dtos;
using Product.Domain.Entities;

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
        CreateMap<ProductEntity, ProductDetailDto>().ReverseMap();
        CreateMap<ProductTypeEntity, ProductTypeItemDto>().ReverseMap();
        CreateMap<ProductVariantEntity, ProductVariantDto>().ReverseMap();
        CreateMap<CategoryEntity, CategoryDto>().ReverseMap();
    }
}