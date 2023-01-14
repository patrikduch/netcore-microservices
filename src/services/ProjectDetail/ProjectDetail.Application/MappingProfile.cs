//--------------------------------------------------------------------------------
// <copyright file="MappingProfile.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
// -------------------------------------------------------------------------------
namespace ProjectDetail.Application;

using AutoMapper;
using ProjectDetail.Application.Dtos;
using ProjectDetail.Domain;

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
        CreateMap<ProjectDetailEntity, ProjectDetailDto>().ReverseMap();
    }
}