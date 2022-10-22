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
/// Entity configuration for  <seealso cref="ProjectDetail"/>.
/// </summary>
public class ProjectDetailConfiguration : IEntityTypeConfiguration<ProjectDetail>
{
    public void Configure(EntityTypeBuilder<ProjectDetail> builder)
    {
        builder.ToTable("projectdetail");
    }
}
