//---------------------------------------------------------------------------
// <copyright file="ProjectDetailConfiguration.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------

namespace ProjectDetail.Persistence.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectDetail.Domain;

/// <summary>
/// Entity configuration for  <seealso cref="ProjectDetailEntity"/>.
/// </summary>
public class ProjectDetailConfiguration : IEntityTypeConfiguration<ProjectDetailEntity>
{
    public void Configure(EntityTypeBuilder<ProjectDetailEntity> builder)
    {
        builder.ToTable("projectdetail");
    }
}
