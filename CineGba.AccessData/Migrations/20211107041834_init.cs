using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CineGba.AccessData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Sinopsis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaId);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    FuncionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.FuncionId);
                    table.ForeignKey(
                        name: "FK_Funciones_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "SalaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionId = table.Column<int>(type: "int", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Ticket", x => new { x.TicketId, x.FuncionId });
                    table.ForeignKey(
                        name: "FuncionId",
                        column: x => x.FuncionId,
                        principalTable: "Funciones",
                        principalColumn: "FuncionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "Poster", "Sinopsis", "Titulo", "Trailer" },
                values: new object[,]
                {
                    { 1, "https://i.imgur.com/849x64V.png", "Batman and Robin try to prevent the evil pair of Mr Freeze and Poison Ivy from freezing the town. While doing so, they also try hard to continue their partnership.", "Batman & Robin", "https://www.youtube.com/embed/0-GIJSZ2GAk" },
                    { 2, "https://i.imgur.com/hh4JaDH.jpeg", "An extraterrestrial hedgehog is discovered by a scientist with evil intentions and plans to use his superpowers for his selfish needs.", "Sonic The Hedgehog", "https://www.youtube.com/embed/szby7ZHLnkA" },
                    { 3, "https://i.imgur.com/7QBZevA.jpeg", "A young hobbit, Frodo, who has found the One Ring that belongs to the Dark Lord Sauron, begins his journey with eight companions to Mount Doom, the only place where it can be destroyed.", "The Lord of the Rings", "https://www.youtube.com/embed/V75dMMIW2B4" },
                    { 4, "https://i.imgur.com/BnTjRXU.png", "Eight-year-old Kevin is accidentally left behind when his family leaves for France. At first, he is happy to be in charge, but when thieves try to break into his home, he tries to put up a fight.", "Home Alone", "https://www.youtube.com/embed/jEDaVHmw7r4" },
                    { 5, "https://i.imgur.com/IMeO4OZ.jpeg", "Three martial arts warriors journey to a faraway island to engage in battle to save the Earth. Their aim is to make sure that truth triumphs in the fight against evil.", "Mortal Kombat", "https://www.youtube.com/embed/JHIfHL5UgFs" },
                    { 6, "https://i.imgur.com/idli8Ss.jpeg", "Superstar LeBron James and his young son, Dom, get trapped in digital space by a rogue AI. To get home safely, LeBron teams up with Bugs Bunny, Daffy Duck and the rest of the Looney Tunes gang", "Space Jam", "https://www.youtube.com/embed/oKNy-MWjkcU" },
                    { 7, "https://i.imgur.com/pUke7Lk.jpeg", "Harry Potter, an eleven-year-old orphan, discovers that he is a wizard and is invited to study at Hogwarts. Even as he escapes a dreary life and enters a world of magic, he finds trouble awaiting him.", "Harry Potter", "https://www.youtube.com/embed/mNgwNXKBEW0" },
                    { 8, "https://i.imgur.com/Qm81aaH.png", "Released in 1940, represented Disney's boldest experiment to date. Bringing to life his vision of blending animated imagery with classical music. ", "Fantasia", "https://www.youtube.com/embed/sHUtZuSTSvA" },
                    { 9, "https://i.imgur.com/BVHSdFE.jpeg", "Forever alone in a crowd, failed comedian Arthur Fleck seeks connection as he walks the streets of Gotham City. Arthur wears two masks", "Joker", "https://www.youtube.com/embed/zAGVQLHvwOY" },
                    { 10, "https://i.imgur.com/Vd7q1sM.jpeg", "Belle, a village girl, embarks on a journey to save her father from a creature that has locked him in his dungeon. Eventually, she learns that the creature is an enchanted prince who has been cursed.", "Beauty and the Beast", "https://www.youtube.com/embed/e3Nl_TCQXuw" },
                    { 11, "https://i.imgur.com/DUnzJNM.jpeg", "Hiro, a robotics prodigy, joins hands with Baymax in order to avenge his brother's death. They then team up with Hiro's friends to form a team of high-tech heroes.", "Big Hero 6", "https://www.youtube.com/embed/z3biFxZIJOQ" },
                    { 12, "https://i.imgur.com/iekJ7Pj.jpeghttps://i.imgur.com/iekJ7Pj.jpeg", "Alice, now 19 years old, follows a rabbit in a blue coat to a magical wonderland from her dreams where she is reunited with her friends who make her realise her true destiny.", "Alice in Wonderland", "https://www.youtube.com/embed/KLIqErnQCuw" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaId", "Capacidad" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 2, 15 },
                    { 3, 35 }
                });

            migrationBuilder.InsertData(
                table: "Funciones",
                columns: new[] { "FuncionId", "Fecha", "Horario", "PeliculaId", "SalaId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 9, 0, 0, 0), 1, 1 },
                    { 20, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 9, 0, 0, 0), 6, 3 },
                    { 16, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 10, 0, 0, 0), 9, 3 },
                    { 12, new DateTime(2021, 11, 11, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 11, 0, 0, 0), 12, 3 },
                    { 10, new DateTime(2021, 11, 9, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 15, 0, 0, 0), 11, 3 },
                    { 8, new DateTime(2021, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 13, 0, 0, 0), 8, 3 },
                    { 6, new DateTime(2021, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 19, 0, 0, 0), 6, 3 },
                    { 21, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 11, 0, 0, 0), 2, 2 },
                    { 19, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 16, 0, 0, 0), 7, 2 },
                    { 17, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 17, 0, 0, 0), 8, 2 },
                    { 22, new DateTime(2021, 11, 21, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 13, 0, 0, 0), 2, 3 },
                    { 14, new DateTime(2021, 11, 13, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 22, 0, 0, 0), 10, 2 },
                    { 7, new DateTime(2021, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 13, 0, 0, 0), 7, 2 },
                    { 18, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 19, 0, 0, 0), 8, 1 },
                    { 15, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 17, 0, 0, 0), 9, 1 },
                    { 13, new DateTime(2021, 11, 12, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 18, 0, 0, 0), 10, 1 },
                    { 9, new DateTime(2021, 11, 8, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 13, 0, 0, 0), 11, 1 },
                    { 5, new DateTime(2021, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 22, 0, 0, 0), 5, 1 },
                    { 4, new DateTime(2021, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 19, 0, 0, 0), 4, 1 },
                    { 3, new DateTime(2021, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 16, 0, 0, 0), 3, 1 },
                    { 2, new DateTime(2021, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 13, 0, 0, 0), 2, 1 },
                    { 11, new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 14, 0, 0, 0), 12, 2 },
                    { 23, new DateTime(2021, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 9, 0, 0, 0), 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_PeliculaId",
                table: "Funciones",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalaId",
                table: "Funciones",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FuncionId",
                table: "Tickets",
                column: "FuncionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
