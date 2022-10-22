//---------------------------------------------------------------------------
// <copyright file="ProjectDetailDto.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace ProjectDetail.Application.Dtos;

using System;

/// <summary>
/// View model class for <seealso cref="ProjectDetailDto"/> mediator design pattern.
/// </summary>
public record ProjectDetailDto(Guid Id, string Name);
