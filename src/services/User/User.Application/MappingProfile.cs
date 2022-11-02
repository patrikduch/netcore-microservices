//---------------------------------------------------------------------------
// <copyright file="MappingProfile.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace User.Application;

using AutoMapper;
using User.Application.Dtos;
using User.Application.Features.Auth.Commands.UserRegistration;
using User.Domain.Entities;


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
        CreateMap<UserEntity, SignInUserDto>().ReverseMap();
        CreateMap<UserRegistrationDto, UserRegistrationCommand>().ReverseMap();
        CreateMap<UserRegistrationDto, UserEntity>().ReverseMap();
    }
}
