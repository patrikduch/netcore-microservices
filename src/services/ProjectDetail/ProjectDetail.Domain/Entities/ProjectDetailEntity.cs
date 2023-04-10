﻿//------------------------------------------------------------------------------------
// <copyright file="Project.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
// -----------------------------------------------------------------------------------
namespace ProjectDetail.Domain.Entities;

using NetMicroservices.SqlWrapper.Nuget;

/// <summary>
/// Project domain entity object.
/// </summary>
public class ProjectDetailEntity : EntityBase
{
    /// <summary>
    /// Gets or sets project name.
    /// </summary>
    public string Name { get; set; }
}
