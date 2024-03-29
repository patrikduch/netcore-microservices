﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Product.Persistence.Contexts;

#nullable disable

namespace Product.Persistence.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Product.Domain.Entities.CategoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.HasKey("Id")
                        .HasName("id");

                    b.ToTable("category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("91d21fc5-3c84-499d-b0f9-7b297738533c"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Books",
                            Url = "books"
                        },
                        new
                        {
                            Id = new Guid("a5a546aa-4d13-4318-b4de-04dbf94259be"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Movies",
                            Url = "movies"
                        },
                        new
                        {
                            Id = new Guid("139abf65-bb9b-4d41-96d8-6c623542ae8d"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Video Games",
                            Url = "video-games"
                        });
                });

            modelBuilder.Entity("Product.Domain.Entities.ProductEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("imgurl");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("product", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ba7656a5-0429-4dec-b3ff-e8b09012b632"),
                            CategoryId = new Guid("91d21fc5-3c84-499d-b0f9-7b297738533c"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Hitchhiker's Guide to the Galaxy[note 1] (sometimes referred to as HG2G,[1] HHGTTG,[2] H2G2,[3] or tHGttG) is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including stage shows, novels, comic books, a 1981 TV series, a 1984 text-based computer game, and 2005 feature film.",
                            ImgUrl = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
                            Name = "The Hitchhiker's Guide to the Galaxy"
                        },
                        new
                        {
                            Id = new Guid("6da738f1-9e86-4bd3-be73-74bd24d0986f"),
                            CategoryId = new Guid("91d21fc5-3c84-499d-b0f9-7b297738533c"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune. Cline sold the rights to publish the novel in June 2010, in a bidding war to the Crown Publishing Group (a division of Random House).[1] The book was published on August 16, 2011.[2] An audiobook was released the same day; it was narrated by Wil Wheaton, who was mentioned briefly in one of the chapters.[3][4]Ch. 20 In 2012, the book received an Alex Award from the Young Adult Library Services Association division of the American Library Association[5] and won the 2011 Prometheus Award.[6]",
                            ImgUrl = "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg",
                            Name = "Ready Player One"
                        },
                        new
                        {
                            Id = new Guid("2b635271-8f13-4a63-a0e9-104d6506718d"),
                            CategoryId = new Guid("91d21fc5-3c84-499d-b0f9-7b297738533c"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the totalitarian government in the novel after Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within politics and the ways in which they are manipulated.",
                            ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/c/c3/1984first.jpg",
                            Name = "Nineteen Eighty-Four"
                        },
                        new
                        {
                            Id = new Guid("b34b571b-edfd-4188-ab06-545ffb6a627d"),
                            CategoryId = new Guid("a5a546aa-4d13-4318-b4de-04dbf94259be"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.",
                            ImgUrl = "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg",
                            Name = "The Matrix"
                        },
                        new
                        {
                            Id = new Guid("535852cd-5d28-4bd1-8852-7076618462c6"),
                            CategoryId = new Guid("a5a546aa-4d13-4318-b4de-04dbf94259be"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.",
                            ImgUrl = "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg",
                            Name = "Back to the Future"
                        },
                        new
                        {
                            Id = new Guid("d5925cb3-00be-4724-a478-04fb436be7f1"),
                            CategoryId = new Guid("a5a546aa-4d13-4318-b4de-04dbf94259be"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.",
                            ImgUrl = "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg",
                            Name = "Toy Story"
                        },
                        new
                        {
                            Id = new Guid("aacd2960-09c0-43eb-8e5b-1264804b3e1e"),
                            CategoryId = new Guid("139abf65-bb9b-4d41-96d8-6c623542ae8d"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.",
                            ImgUrl = "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg",
                            Name = "Half-Life 2"
                        },
                        new
                        {
                            Id = new Guid("af8a4784-44cc-47e2-a2a3-8ef3363c1815"),
                            CategoryId = new Guid("139abf65-bb9b-4d41-96d8-6c623542ae8d"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.",
                            ImgUrl = "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png",
                            Name = "Diablo II"
                        },
                        new
                        {
                            Id = new Guid("2346bc18-4a78-422a-b8db-33195ac3ed3f"),
                            CategoryId = new Guid("139abf65-bb9b-4d41-96d8-6c623542ae8d"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.",
                            ImgUrl = "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg",
                            Name = "Day of the Tentacle"
                        },
                        new
                        {
                            Id = new Guid("4f498e40-e6cc-43d9-bf0f-284e20da7e6a"),
                            CategoryId = new Guid("139abf65-bb9b-4d41-96d8-6c623542ae8d"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
                            ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg",
                            Name = "Xbox"
                        },
                        new
                        {
                            Id = new Guid("8eb4489a-b2dc-415c-b9a2-f946a01a2c0e"),
                            CategoryId = new Guid("139abf65-bb9b-4d41-96d8-6c623542ae8d"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
                            ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg",
                            Name = "Super Nintendo Entertainment System"
                        });
                });

            modelBuilder.Entity("Product.Domain.Entities.ProductTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("product-type", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("19f1c737-eae6-4bcf-b32f-45203e07282c"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Default"
                        },
                        new
                        {
                            Id = new Guid("f4a6c9cc-cd6e-42d4-87be-f83e2cf2826b"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Paperback"
                        },
                        new
                        {
                            Id = new Guid("751287ba-53f6-4874-b7b2-dc7b39ff6e9f"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "E-Book"
                        },
                        new
                        {
                            Id = new Guid("14ad27fb-2e94-407b-8e52-3376dc8f25fc"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Audiobook"
                        },
                        new
                        {
                            Id = new Guid("d1a105d9-ac4e-405a-8460-e54cd799d588"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Stream"
                        },
                        new
                        {
                            Id = new Guid("5fb75212-e4eb-4b55-91f6-be056920398e"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Blu-ray"
                        },
                        new
                        {
                            Id = new Guid("a0cc00af-f1c2-46be-9c5e-a6f4e0f69069"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "VHS"
                        },
                        new
                        {
                            Id = new Guid("2527d791-fecd-4721-8c91-a90a4f6f702a"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "PC"
                        },
                        new
                        {
                            Id = new Guid("170955ba-98b9-47d2-bc0c-f2962ecba9c2"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "PlayStation"
                        },
                        new
                        {
                            Id = new Guid("247c1e97-6a59-4473-94a4-f58564ea399f"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Xbox"
                        });
                });

            modelBuilder.Entity("Product.Domain.Entities.ProductVariantEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductTypeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("numeric(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric(18,2)");

                    b.HasKey("Id", "ProductId", "ProductTypeId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("product-variant", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("bbf02f5f-6b6e-4e7e-a81d-fe504492b2bf"),
                            ProductId = new Guid("2346bc18-4a78-422a-b8db-33195ac3ed3f"),
                            ProductTypeId = new Guid("f4a6c9cc-cd6e-42d4-87be-f83e2cf2826b"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginalPrice = 19.99m,
                            Price = 9.99m
                        },
                        new
                        {
                            Id = new Guid("30a38fb1-ab79-447e-9f4a-860c8bbd62b4"),
                            ProductId = new Guid("2346bc18-4a78-422a-b8db-33195ac3ed3f"),
                            ProductTypeId = new Guid("751287ba-53f6-4874-b7b2-dc7b39ff6e9f"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginalPrice = 0m,
                            Price = 7.99m
                        },
                        new
                        {
                            Id = new Guid("3969771f-5401-4076-9880-be48be42306d"),
                            ProductId = new Guid("2346bc18-4a78-422a-b8db-33195ac3ed3f"),
                            ProductTypeId = new Guid("14ad27fb-2e94-407b-8e52-3376dc8f25fc"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginalPrice = 29.99m,
                            Price = 19.99m
                        },
                        new
                        {
                            Id = new Guid("5157a815-4955-490b-b7fb-75ff32a9e1e9"),
                            ProductId = new Guid("6da738f1-9e86-4bd3-be73-74bd24d0986f"),
                            ProductTypeId = new Guid("f4a6c9cc-cd6e-42d4-87be-f83e2cf2826b"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginalPrice = 14.99m,
                            Price = 7.99m
                        },
                        new
                        {
                            Id = new Guid("c7828d23-5241-433b-830d-3590dea897ee"),
                            ProductId = new Guid("2b635271-8f13-4a63-a0e9-104d6506718d"),
                            ProductTypeId = new Guid("f4a6c9cc-cd6e-42d4-87be-f83e2cf2826b"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginalPrice = 0m,
                            Price = 6.99m
                        },
                        new
                        {
                            Id = new Guid("e3bca2da-6722-48bc-8a00-76f9e6cc3cd8"),
                            ProductId = new Guid("b34b571b-edfd-4188-ab06-545ffb6a627d"),
                            ProductTypeId = new Guid("d1a105d9-ac4e-405a-8460-e54cd799d588"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginalPrice = 0m,
                            Price = 3.99m
                        },
                        new
                        {
                            Id = new Guid("57f2bd76-ddc9-438d-85b1-609b7fcf7e45"),
                            ProductId = new Guid("b34b571b-edfd-4188-ab06-545ffb6a627d"),
                            ProductTypeId = new Guid("5fb75212-e4eb-4b55-91f6-be056920398e"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginalPrice = 0m,
                            Price = 9.99m
                        },
                        new
                        {
                            Id = new Guid("1f892f4e-4cf9-4f2c-bfde-3d245d11375e"),
                            ProductId = new Guid("b34b571b-edfd-4188-ab06-545ffb6a627d"),
                            ProductTypeId = new Guid("a0cc00af-f1c2-46be-9c5e-a6f4e0f69069"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginalPrice = 0m,
                            Price = 19.99m
                        },
                        new
                        {
                            Id = new Guid("036ffc29-a1f8-40fa-af2a-b70783eb0242"),
                            ProductId = new Guid("535852cd-5d28-4bd1-8852-7076618462c6"),
                            ProductTypeId = new Guid("d1a105d9-ac4e-405a-8460-e54cd799d588"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginalPrice = 0m,
                            Price = 3.99m
                        },
                        new
                        {
                            Id = new Guid("97aa65f7-a29d-462b-adc1-7a9bcd37e45b"),
                            ProductId = new Guid("d5925cb3-00be-4724-a478-04fb436be7f1"),
                            ProductTypeId = new Guid("d1a105d9-ac4e-405a-8460-e54cd799d588"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginalPrice = 0m,
                            Price = 2.99m
                        },
                        new
                        {
                            Id = new Guid("7720567c-3101-4a77-baf7-428bb4e34869"),
                            ProductId = new Guid("2346bc18-4a78-422a-b8db-33195ac3ed3f"),
                            ProductTypeId = new Guid("2527d791-fecd-4721-8c91-a90a4f6f702a"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginalPrice = 29.99m,
                            Price = 19.99m
                        },
                        new
                        {
                            Id = new Guid("a5ad5e66-3d27-460f-97f1-be72ae934b19"),
                            ProductId = new Guid("aacd2960-09c0-43eb-8e5b-1264804b3e1e"),
                            ProductTypeId = new Guid("170955ba-98b9-47d2-bc0c-f2962ecba9c2"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginalPrice = 0m,
                            Price = 69.99m
                        },
                        new
                        {
                            Id = new Guid("480ae336-a674-42fe-aedd-5e60bdcec77e"),
                            ProductId = new Guid("aacd2960-09c0-43eb-8e5b-1264804b3e1e"),
                            ProductTypeId = new Guid("247c1e97-6a59-4473-94a4-f58564ea399f"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginalPrice = 59.99m,
                            Price = 49.99m
                        },
                        new
                        {
                            Id = new Guid("966574b6-ccea-4a39-a983-77b70b45ee9c"),
                            ProductId = new Guid("af8a4784-44cc-47e2-a2a3-8ef3363c1815"),
                            ProductTypeId = new Guid("2527d791-fecd-4721-8c91-a90a4f6f702a"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginalPrice = 24.99m,
                            Price = 9.99m
                        },
                        new
                        {
                            Id = new Guid("1d36ec7f-e0a5-44c4-b6e3-3e6a2495dc88"),
                            ProductId = new Guid("2346bc18-4a78-422a-b8db-33195ac3ed3f"),
                            ProductTypeId = new Guid("2527d791-fecd-4721-8c91-a90a4f6f702a"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginalPrice = 0m,
                            Price = 14.99m
                        },
                        new
                        {
                            Id = new Guid("966574b6-ccea-4a39-a983-77b70b45ee9c"),
                            ProductId = new Guid("4f498e40-e6cc-43d9-bf0f-284e20da7e6a"),
                            ProductTypeId = new Guid("19f1c737-eae6-4bcf-b32f-45203e07282c"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginalPrice = 299m,
                            Price = 159.99m
                        },
                        new
                        {
                            Id = new Guid("966574b6-ccea-4a39-a983-77b70b45ee9c"),
                            ProductId = new Guid("8eb4489a-b2dc-415c-b9a2-f946a01a2c0e"),
                            ProductTypeId = new Guid("19f1c737-eae6-4bcf-b32f-45203e07282c"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginalPrice = 399m,
                            Price = 79.99m
                        });
                });

            modelBuilder.Entity("Product.Domain.Entities.ProductEntity", b =>
                {
                    b.HasOne("Product.Domain.Entities.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Product.Domain.Entities.ProductVariantEntity", b =>
                {
                    b.HasOne("Product.Domain.Entities.ProductEntity", "Product")
                        .WithMany("ProductVariants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Product.Domain.Entities.ProductTypeEntity", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("Product.Domain.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Product.Domain.Entities.ProductEntity", b =>
                {
                    b.Navigation("ProductVariants");
                });
#pragma warning restore 612, 618
        }
    }
}
