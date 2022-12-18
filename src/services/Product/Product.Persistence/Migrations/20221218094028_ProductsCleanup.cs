using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Persistence.Migrations
{
    public partial class ProductsCleanup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("28d1b809-9f07-4382-98c3-27fd5c1c52ad"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("2b344d6e-7baf-4b1a-af55-afadc7dd9efd"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("2cae1e22-9735-402c-8fab-16de3cfbeebc"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("3ff56c89-1ad2-4dad-a056-171ea26fe18a"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("83ef251c-9238-4395-a383-f25533a84102"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("90286ab1-2cd6-496d-85bf-8a842997c784"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("a3a1fe06-743f-4d77-ad6b-2fbe6a4df6dd"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("ab0e8bec-3df1-4069-8b81-d3a93bbc35e2"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("aeb9ce41-f488-4edb-85ef-a87b4faa2a13"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("c04bec76-fc48-424a-ac5c-36feab8e60cd"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("e738c433-a408-4177-b7cf-8633cbb9eac6"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "CategoryId", "CreatedAt", "CreatedBy", "description", "imgurl", "LastModifiedBy", "LastModifiedDate", "name" },
                values: new object[,]
                {
                    { new Guid("28d1b809-9f07-4382-98c3-27fd5c1c52ad"), new Guid("139abf65-bb9b-4d41-96d8-6c623542ae8d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.", "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png", null, null, "Diablo II" },
                    { new Guid("2b344d6e-7baf-4b1a-af55-afadc7dd9efd"), new Guid("139abf65-bb9b-4d41-96d8-6c623542ae8d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.", "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg", null, null, "Half-Life 2" },
                    { new Guid("2cae1e22-9735-402c-8fab-16de3cfbeebc"), new Guid("a5a546aa-4d13-4318-b4de-04dbf94259be"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.", "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg", null, null, "The Matrix" },
                    { new Guid("3ff56c89-1ad2-4dad-a056-171ea26fe18a"), new Guid("139abf65-bb9b-4d41-96d8-6c623542ae8d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.", "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg", null, null, "Xbox" },
                    { new Guid("83ef251c-9238-4395-a383-f25533a84102"), new Guid("a5a546aa-4d13-4318-b4de-04dbf94259be"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.", "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg", null, null, "Toy Story" },
                    { new Guid("90286ab1-2cd6-496d-85bf-8a842997c784"), new Guid("a5a546aa-4d13-4318-b4de-04dbf94259be"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.", "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg", null, null, "Back to the Future" },
                    { new Guid("a3a1fe06-743f-4d77-ad6b-2fbe6a4df6dd"), new Guid("139abf65-bb9b-4d41-96d8-6c623542ae8d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg", null, null, "Super Nintendo Entertainment System" },
                    { new Guid("ab0e8bec-3df1-4069-8b81-d3a93bbc35e2"), new Guid("139abf65-bb9b-4d41-96d8-6c623542ae8d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.", "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg", null, null, "Day of the Tentacle" },
                    { new Guid("aeb9ce41-f488-4edb-85ef-a87b4faa2a13"), new Guid("91d21fc5-3c84-499d-b0f9-7b297738533c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the totalitarian government in the novel after Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within politics and the ways in which they are manipulated.", "https://upload.wikimedia.org/wikipedia/commons/c/c3/1984first.jpg", null, null, "Nineteen Eighty-Four" },
                    { new Guid("c04bec76-fc48-424a-ac5c-36feab8e60cd"), new Guid("91d21fc5-3c84-499d-b0f9-7b297738533c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune. Cline sold the rights to publish the novel in June 2010, in a bidding war to the Crown Publishing Group (a division of Random House).[1] The book was published on August 16, 2011.[2] An audiobook was released the same day; it was narrated by Wil Wheaton, who was mentioned briefly in one of the chapters.[3][4]Ch. 20 In 2012, the book received an Alex Award from the Young Adult Library Services Association division of the American Library Association[5] and won the 2011 Prometheus Award.[6]", "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg", null, null, "Ready Player One" },
                    { new Guid("e738c433-a408-4177-b7cf-8633cbb9eac6"), new Guid("91d21fc5-3c84-499d-b0f9-7b297738533c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Hitchhiker's Guide to the Galaxy[note 1] (sometimes referred to as HG2G,[1] HHGTTG,[2] H2G2,[3] or tHGttG) is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including stage shows, novels, comic books, a 1981 TV series, a 1984 text-based computer game, and 2005 feature film.", "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg", null, null, "The Hitchhiker's Guide to the Galaxy" }
                });
        }
    }
}
