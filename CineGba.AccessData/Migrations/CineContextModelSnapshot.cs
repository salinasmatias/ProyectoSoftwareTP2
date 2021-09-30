﻿// <auto-generated />
using System;
using CineGba.AccessData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CineGba.AccessData.Migrations
{
    [DbContext(typeof(CineContext))]
    partial class CineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CineGba.Domain.Entities.Funcion", b =>
                {
                    b.Property<int>("FuncionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan?>("Horario")
                        .IsRequired()
                        .HasColumnType("time");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.Property<int>("SalaId")
                        .HasColumnType("int");

                    b.HasKey("FuncionId");

                    b.HasIndex("PeliculaId");

                    b.HasIndex("SalaId");

                    b.ToTable("Funciones");
                });

            modelBuilder.Entity("CineGba.Domain.Entities.Pelicula", b =>
                {
                    b.Property<int>("PeliculaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Sinopsis")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("PeliculaId");

                    b.ToTable("Peliculas");

                    b.HasData(
                        new
                        {
                            PeliculaId = 1,
                            Poster = "https://i.blogs.es/ec18b1/batman-robin-poster/450_1000.jpg",
                            Sinopsis = "Batman and Robin try to prevent the evil pair of Mr Freeze and Poison Ivy from freezing the town. While doing so, they also try hard to continue their partnership.",
                            Titulo = "Batman & Robin",
                            Trailer = "https://www.youtube.com/watch?v=0-GIJSZ2GAk"
                        },
                        new
                        {
                            PeliculaId = 2,
                            Poster = "https://m.media-amazon.com/images/I/71kgvHY5G1L._AC_SY679_.jpg",
                            Sinopsis = "An extraterrestrial hedgehog is discovered by a scientist with evil intentions and plans to use his superpowers for his selfish needs.",
                            Titulo = "Sonic The Hedgehog",
                            Trailer = "https://www.youtube.com/watch?v=szby7ZHLnkA"
                        },
                        new
                        {
                            PeliculaId = 3,
                            Poster = "https://cdn.europosters.eu/image/750/posters/lord-of-the-rings-fellowship-i11723.jpg",
                            Sinopsis = "A young hobbit, Frodo, who has found the One Ring that belongs to the Dark Lord Sauron, begins his journey with eight companions to Mount Doom, the only place where it can be destroyed.",
                            Titulo = "The Lord of the Rings",
                            Trailer = "https://www.youtube.com/watch?v=V75dMMIW2B4"
                        },
                        new
                        {
                            PeliculaId = 4,
                            Poster = "https://m.media-amazon.com/images/I/A1T+lZ6iUZL._SL1500_.jpg",
                            Sinopsis = "Eight-year-old Kevin is accidentally left behind when his family leaves for France. At first, he is happy to be in charge, but when thieves try to break into his home, he tries to put up a fight.",
                            Titulo = "Home Alone",
                            Trailer = "https://www.youtube.com/watch?v=jEDaVHmw7r4"
                        },
                        new
                        {
                            PeliculaId = 5,
                            Poster = "https://oldies-cdn.freetls.fastly.net/i/boxart/w340/a-z/x/xwb4310d.jpg?v=3",
                            Sinopsis = "Three martial arts warriors journey to a faraway island to engage in battle to save the Earth. Their aim is to make sure that truth triumphs in the fight against evil.",
                            Titulo = "Mortal Kombat",
                            Trailer = "https://www.youtube.com/watch?v=JHIfHL5UgFs"
                        },
                        new
                        {
                            PeliculaId = 6,
                            Poster = "https://m.media-amazon.com/images/I/61VX0X7EGDL._SY445_.jpg",
                            Sinopsis = "Superstar LeBron James and his young son, Dom, get trapped in digital space by a rogue AI. To get home safely, LeBron teams up with Bugs Bunny, Daffy Duck and the rest of the Looney Tunes gang",
                            Titulo = "Space Jam",
                            Trailer = "https://www.youtube.com/watch?v=oKNy-MWjkcU"
                        },
                        new
                        {
                            PeliculaId = 7,
                            Poster = "https://m.media-amazon.com/images/I/713KEd-8jyL._AC_SL1500_.jpg",
                            Sinopsis = "Harry Potter, an eleven-year-old orphan, discovers that he is a wizard and is invited to study at Hogwarts. Even as he escapes a dreary life and enters a world of magic, he finds trouble awaiting him.",
                            Titulo = "Harry Potter",
                            Trailer = "https://www.youtube.com/watch?v=mNgwNXKBEW0"
                        },
                        new
                        {
                            PeliculaId = 8,
                            Poster = "https://m.media-amazon.com/images/I/41i1SGdPdML._AC_.jpg",
                            Sinopsis = "Released in 1940, represented Disney's boldest experiment to date. Bringing to life his vision of blending animated imagery with classical music. ",
                            Titulo = "Fantasia",
                            Trailer = "https://www.youtube.com/watch?v=sHUtZuSTSvA"
                        },
                        new
                        {
                            PeliculaId = 9,
                            Poster = "https://m.media-amazon.com/images/I/61fcSo4JxiL._AC_SY500_.jpg",
                            Sinopsis = "Forever alone in a crowd, failed comedian Arthur Fleck seeks connection as he walks the streets of Gotham City. Arthur wears two masks",
                            Titulo = "Joker",
                            Trailer = "https://www.youtube.com/watch?v=zAGVQLHvwOY"
                        },
                        new
                        {
                            PeliculaId = 10,
                            Poster = "https://images-na.ssl-images-amazon.com/images/I/91n9OKbLDSL.jpg",
                            Sinopsis = "Belle, a village girl, embarks on a journey to save her father from a creature that has locked him in his dungeon. Eventually, she learns that the creature is an enchanted prince who has been cursed.",
                            Titulo = "Beauty and the Beast",
                            Trailer = "https://www.youtube.com/watch?v=e3Nl_TCQXuw"
                        });
                });

            modelBuilder.Entity("CineGba.Domain.Entities.Sala", b =>
                {
                    b.Property<int>("SalaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.HasKey("SalaId");

                    b.ToTable("Salas");

                    b.HasData(
                        new
                        {
                            SalaId = 1,
                            Capacidad = 5
                        },
                        new
                        {
                            SalaId = 2,
                            Capacidad = 15
                        },
                        new
                        {
                            SalaId = 3,
                            Capacidad = 35
                        });
                });

            modelBuilder.Entity("CineGba.Domain.Entities.Ticket", b =>
                {
                    b.Property<Guid>("TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FuncionId")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TicketId", "FuncionId")
                        .HasName("Ticket");

                    b.HasIndex("FuncionId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("CineGba.Domain.Entities.Funcion", b =>
                {
                    b.HasOne("CineGba.Domain.Entities.Pelicula", "Pelicula")
                        .WithMany("Funciones")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CineGba.Domain.Entities.Sala", "Sala")
                        .WithMany("Funciones")
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pelicula");

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("CineGba.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("CineGba.Domain.Entities.Funcion", "Funcion")
                        .WithMany("Tickets")
                        .HasForeignKey("FuncionId")
                        .HasConstraintName("FuncionId")
                        .IsRequired();

                    b.Navigation("Funcion");
                });

            modelBuilder.Entity("CineGba.Domain.Entities.Funcion", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("CineGba.Domain.Entities.Pelicula", b =>
                {
                    b.Navigation("Funciones");
                });

            modelBuilder.Entity("CineGba.Domain.Entities.Sala", b =>
                {
                    b.Navigation("Funciones");
                });
#pragma warning restore 612, 618
        }
    }
}
