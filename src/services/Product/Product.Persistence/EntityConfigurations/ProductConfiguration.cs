//---------------------------------------------------------------------------
// <copyright file="ProductConfiguration.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Persistence.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Entities;

/// <summary>
/// Entity configuration for  <seealso cref="ProductEntity"/>.
/// </summary>
public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("product");
        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.Name).HasColumnName("name");
        builder.Property(p => p.Description).HasColumnName("description");
        builder.Property(p => p.ImgUrl).HasColumnName("imgurl");
        builder.HasOne(p => p.Category).WithMany(c => c.Products);


        var bookCategory = Guid.Parse("91d21fc5-3c84-499d-b0f9-7b297738533c");
        var movieCategory = Guid.Parse("a5a546aa-4d13-4318-b4de-04dbf94259be");
        var videogamesCategory = Guid.Parse("139abf65-bb9b-4d41-96d8-6c623542ae8d");


        builder.HasData(
            new ProductEntity
            {
                Id = Guid.Parse("ba7656a5-0429-4dec-b3ff-e8b09012b632"),
                Name = "The Hitchhiker's Guide to the Galaxy",
                Description = "The Hitchhiker's Guide to the Galaxy[note 1] (sometimes referred to as HG2G,[1] HHGTTG,[2] H2G2,[3] or tHGttG) is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including stage shows, novels, comic books, a 1981 TV series, a 1984 text-based computer game, and 2005 feature film.",
                ImgUrl = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",     
                CategoryId = bookCategory,
            },

            new ProductEntity
            {
                Id = Guid.Parse("6da738f1-9e86-4bd3-be73-74bd24d0986f"),
                Name = "Ready Player One",
                Description = "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune. Cline sold the rights to publish the novel in June 2010, in a bidding war to the Crown Publishing Group (a division of Random House).[1] The book was published on August 16, 2011.[2] An audiobook was released the same day; it was narrated by Wil Wheaton, who was mentioned briefly in one of the chapters.[3][4]Ch. 20 In 2012, the book received an Alex Award from the Young Adult Library Services Association division of the American Library Association[5] and won the 2011 Prometheus Award.[6]",
                ImgUrl = "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg",     
                CategoryId = bookCategory
            
            },
            new ProductEntity 
            { 
                Id = Guid.Parse("2b635271-8f13-4a63-a0e9-104d6506718d"), 
                Name = "Nineteen Eighty-Four", 
                Description = "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the totalitarian government in the novel after Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within politics and the ways in which they are manipulated.", 
                ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/c/c3/1984first.jpg",       
                CategoryId = bookCategory 
            }, 
            new ProductEntity 
            { 
                Id = Guid.Parse("b34b571b-edfd-4188-ab06-545ffb6a627d"), 
                Name = "The Matrix", 
                Description = "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.", 
                ImgUrl = "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg",      
                CategoryId = movieCategory 
            }, 
            new ProductEntity 
            { 
                Id = Guid.Parse("535852cd-5d28-4bd1-8852-7076618462c6"), 
                Name = "Back to the Future", 
                Description = "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.", 
                ImgUrl = "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg",       
                CategoryId = movieCategory
             },
            new ProductEntity
            {
                Id = Guid.Parse("d5925cb3-00be-4724-a478-04fb436be7f1"),
                Name = "Toy Story",
                Description = "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.",
                ImgUrl = "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg",      
                CategoryId = movieCategory
            }, 
            new ProductEntity 
            { 
                Id = Guid.Parse("aacd2960-09c0-43eb-8e5b-1264804b3e1e"), 
                Name = "Half-Life 2", 
                Description = "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.", 
                ImgUrl = "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg", 
                CategoryId = videogamesCategory, 
            }, 
            new ProductEntity 
            { 
                Id = Guid.Parse("af8a4784-44cc-47e2-a2a3-8ef3363c1815"), 
                Name = "Diablo II", 
                Description = "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.", 
                ImgUrl = "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png", 
                CategoryId = videogamesCategory, 
            }, 
            new ProductEntity 
            {
                Id = Guid.Parse("2346bc18-4a78-422a-b8db-33195ac3ed3f"), 
                Name = "Day of the Tentacle", 
                Description = "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.", 
                ImgUrl = "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg", 
                CategoryId = videogamesCategory, 
            },
            new ProductEntity
            {
                Id = Guid.Parse("4f498e40-e6cc-43d9-bf0f-284e20da7e6a"),
                Name = "Xbox",
                Description = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
                ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg",
                CategoryId = videogamesCategory,
            }, 
            new ProductEntity 
            { 
                Id = Guid.NewGuid(), 
                Name = "Super Nintendo Entertainment System", 
                Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", 
                ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg", 
                CategoryId = videogamesCategory 
            }
          );
        /*

        builder.HasData(new ProductEntity
            {
               Id = Guid.NewGuid(),
               Name = "The Hitchhiker's Guide to the Galaxy",
               Description = "The Hitchhiker's Guide to the Galaxy[note 1] (sometimes referred to as HG2G,[1] HHGTTG,[2] H2G2,[3] or tHGttG) is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including stage shows, novels, comic books, a 1981 TV series, a 1984 text-based computer game, and 2005 feature film.",
               ImgUrl = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
               //Price = 9.9m,        
               CategoryId = bookCategory,
            },
            new ProductEntity
            {
               Id = Guid.NewGuid(),
               Name = "Ready Player One",
               Description = "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune. Cline sold the rights to publish the novel in June 2010, in a bidding war to the Crown Publishing Group (a division of Random House).[1] The book was published on August 16, 2011.[2] An audiobook was released the same day; it was narrated by Wil Wheaton, who was mentioned briefly in one of the chapters.[3][4]Ch. 20 In 2012, the book received an Alex Award from the Young Adult Library Services Association division of the American Library Association[5] and won the 2011 Prometheus Award.[6]",
               ImgUrl = "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg",
               //Price = 7.99m,        
               CategoryId = bookCategory
           },
           new ProductEntity
           {
              Id = Guid.NewGuid(),
              Name = "Nineteen Eighty-Four",
              Description = "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the totalitarian government in the novel after Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within politics and the ways in which they are manipulated.",
              ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/c/c3/1984first.jpg",
               //Price = 6.99m,        
              CategoryId = bookCategory
           },
           new ProductEntity
           {
              Id = Guid.NewGuid(),
              Name = "The Matrix",
              Description = "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.",
              ImgUrl = "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg",
              //Price = 4.99m,        
              CategoryId = movieCategory
           },
           new ProductEntity
           {
              Id = Guid.NewGuid(),
              Name = "Back to the Future",
              Description = "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.",
              ImgUrl = "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg",
              //Price = 3.99m,        
              CategoryId = movieCategory
           },
           new ProductEntity
           {
              Id = Guid.NewGuid(),
              Name = "Toy Story",
              Description = "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.",
              ImgUrl = "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg",
              //Price = 2.99m,        
              CategoryId = movieCategory
           },
           new ProductEntity
           {
              Id = Guid.NewGuid(),
              Name = "Half-Life 2",
              Description = "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.",
              ImgUrl = "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg",
              //Price = 49.99m,
              CategoryId = videogamesCategory,

           },
           new ProductEntity
           {
             Id = Guid.NewGuid(),
             Name = "Diablo II",
             Description = "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.",
             ImgUrl = "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png",
             //Price = 9.99m,
             CategoryId = videogamesCategory,
           },
           new ProductEntity
           {
             Id = Guid.NewGuid(),
             Name = "Day of the Tentacle",
             Description = "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.",
             ImgUrl = "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg",
             //Price = 14.99m,
             CategoryId = videogamesCategory,
           },
           new ProductEntity
           {
             Id = Guid.NewGuid(),
             Name = "Xbox",
             Description = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
             ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg",
             //Price = 159.99m,
             CategoryId = videogamesCategory,
           },
           new ProductEntity
           {
             Id = Guid.NewGuid(),
             Name = "Super Nintendo Entertainment System",
             Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
             ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg",
             //Price = 79.99m,
             CategoryId = videogamesCategory   
        }); */
    }
}
