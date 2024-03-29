﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using User.Persistence.Contexts;

#nullable disable

namespace User.Persistence.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20221104102050_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("User.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("b491c6d3-1747-485e-a64f-b80d9b1277e8"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "patrikduch@test.com",
                            PasswordHash = new byte[] { 171, 206, 35, 238, 154, 252, 183, 232, 136, 145, 46, 120, 46, 109, 199, 41, 61, 52, 60, 72, 211, 22, 14, 19, 43, 139, 139, 109, 193, 147, 160, 179, 59, 123, 78, 76, 95, 226, 16, 101, 134, 48, 177, 191, 63, 10, 166, 243, 162, 248, 208, 211, 50, 165, 250, 218, 85, 99, 47, 65, 186, 228, 234, 69 },
                            PasswordSalt = new byte[] { 115, 179, 226, 112, 196, 173, 244, 184, 176, 67, 214, 219, 91, 58, 76, 55, 53, 173, 140, 191, 21, 153, 228, 104, 13, 17, 112, 89, 238, 113, 190, 76, 54, 160, 116, 233, 199, 20, 149, 154, 93, 134, 89, 47, 21, 27, 60, 0, 138, 161, 15, 21, 107, 225, 113, 205, 153, 156, 227, 165, 118, 204, 181, 94, 164, 15, 165, 89, 82, 134, 160, 38, 215, 151, 208, 199, 237, 174, 2, 135, 11, 219, 24, 34, 132, 25, 250, 243, 37, 158, 182, 197, 236, 125, 45, 64, 194, 89, 159, 10, 99, 214, 128, 134, 183, 164, 247, 242, 211, 55, 226, 246, 196, 2, 6, 96, 63, 38, 145, 0, 63, 119, 238, 74, 205, 147, 6, 200 }
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
