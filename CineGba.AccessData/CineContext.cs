using CineGba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CineGba.AccessData
{
    public class CineContext : DbContext
    {
        public CineContext() { }

        public CineContext(DbContextOptions<CineContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(e => e.PeliculaId);

                entity.Property(e => e.Poster)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Sinopsis)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Trailer)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.HasKey(e => e.SalaId);

                entity.Property(e => e.Capacidad)
                    .IsRequired();
            });

            modelBuilder.Entity<Funcion>(entity =>
            {
                entity.HasKey(e => e.FuncionId);

                entity.Property(e => e.Fecha)
                    .IsRequired();

                entity.Property(e => e.Horario)
                    .IsRequired();

                entity.HasOne(d => d.Pelicula)
                    .WithMany(p => p.Funciones)
                    .HasForeignKey(d => d.PeliculaId);

                entity.HasOne(d => d.Sala)
                    .WithMany(p => p.Funciones)
                    .HasForeignKey(d => d.SalaId);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => new { e.TicketId, e.FuncionId })
                    .HasName("Ticket");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.HasOne(d => d.Funcion)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.FuncionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FuncionId");
            });


            //INSERTS

            modelBuilder.Entity<Sala>().HasData(
                new Sala
                {
                    SalaId = 1,
                    Capacidad = 5
                },
                new Sala
                {
                    SalaId = 2,
                    Capacidad = 15
                },
                new Sala
                {
                    SalaId = 3,
                    Capacidad = 35
                }
            );

            modelBuilder.Entity<Pelicula>().HasData(
                new Pelicula
                {
                    PeliculaId = 1,
                    Titulo = "Batman and Robin",
                    Poster = "https://i.imgur.com/849x64V.png",
                    Sinopsis = "Batman and Robin try to prevent the evil pair of Mr Freeze and Poison Ivy from freezing the town. While doing so, they also try hard to continue their partnership.",
                    Trailer = "https://www.youtube.com/embed/0-GIJSZ2GAk"
                },
                new Pelicula
                {
                    PeliculaId = 2,
                    Titulo = "Sonic The Hedgehog",
                    Poster = "https://i.imgur.com/hh4JaDH.jpeg",
                    Sinopsis = "An extraterrestrial hedgehog is discovered by a scientist with evil intentions and plans to use his superpowers for his selfish needs.",
                    Trailer = "https://www.youtube.com/embed/szby7ZHLnkA"
                },
                new Pelicula
                {
                    PeliculaId = 3,
                    Titulo = "The Lord of the Rings",
                    Poster = "https://i.imgur.com/7QBZevA.jpeg",
                    Sinopsis = "A young hobbit, Frodo, who has found the One Ring that belongs to the Dark Lord Sauron, begins his journey with eight companions to Mount Doom, the only place where it can be destroyed.",
                    Trailer = "https://www.youtube.com/embed/V75dMMIW2B4"
                },
                new Pelicula
                {
                    PeliculaId = 4,
                    Titulo = "Home Alone",
                    Poster = "https://i.imgur.com/BnTjRXU.png",
                    Sinopsis = "Eight-year-old Kevin is accidentally left behind when his family leaves for France. At first, he is happy to be in charge, but when thieves try to break into his home, he tries to put up a fight.",
                    Trailer = "https://www.youtube.com/embed/jEDaVHmw7r4"
                },
                new Pelicula
                {
                    PeliculaId = 5,
                    Titulo = "Mortal Kombat",
                    Poster = "https://i.imgur.com/IMeO4OZ.jpeg",
                    Sinopsis = "Three martial arts warriors journey to a faraway island to engage in battle to save the Earth. Their aim is to make sure that truth triumphs in the fight against evil.",
                    Trailer = "https://www.youtube.com/embed/JHIfHL5UgFs"
                },
                new Pelicula
                {
                    PeliculaId = 6,
                    Titulo = "Space Jam",
                    Poster = "https://i.imgur.com/idli8Ss.jpeg",
                    Sinopsis = "Superstar LeBron James and his young son, Dom, get trapped in digital space by a rogue AI. To get home safely, LeBron teams up with Bugs Bunny, Daffy Duck and the rest of the Looney Tunes gang",
                    Trailer = "https://www.youtube.com/embed/oKNy-MWjkcU"
                },
                new Pelicula
                {
                    PeliculaId = 7,
                    Titulo = "Harry Potter",
                    Poster = "https://i.imgur.com/pUke7Lk.jpeg",
                    Sinopsis = "Harry Potter, an eleven-year-old orphan, discovers that he is a wizard and is invited to study at Hogwarts. Even as he escapes a dreary life and enters a world of magic, he finds trouble awaiting him.",
                    Trailer = "https://www.youtube.com/embed/mNgwNXKBEW0"
                },
                new Pelicula
                {
                    PeliculaId = 8,
                    Titulo = "Fantasia",
                    Poster = "https://i.imgur.com/Qm81aaH.png",
                    Sinopsis = "Released in 1940, represented Disney's boldest experiment to date. Bringing to life his vision of blending animated imagery with classical music. ",
                    Trailer = "https://www.youtube.com/embed/sHUtZuSTSvA"
                },
                new Pelicula
                {
                    PeliculaId = 9,
                    Titulo = "Joker",
                    Poster = "https://i.imgur.com/BVHSdFE.jpeg",
                    Sinopsis = "Forever alone in a crowd, failed comedian Arthur Fleck seeks connection as he walks the streets of Gotham City. Arthur wears two masks",
                    Trailer = "https://www.youtube.com/embed/zAGVQLHvwOY"
                },
                new Pelicula
                {
                    PeliculaId = 10,
                    Titulo = "Beauty and the Beast",
                    Poster = "https://i.imgur.com/Vd7q1sM.jpeg",
                    Sinopsis = "Belle, a village girl, embarks on a journey to save her father from a creature that has locked him in his dungeon. Eventually, she learns that the creature is an enchanted prince who has been cursed.",
                    Trailer = "https://www.youtube.com/embed/e3Nl_TCQXuw"
                },
                new Pelicula
                {
                    PeliculaId = 11,
                    Titulo = "Big Hero 6",
                    Poster = "https://i.imgur.com/DUnzJNM.jpeg",
                    Sinopsis = "Hiro, a robotics prodigy, joins hands with Baymax in order to avenge his brother's death. They then team up with Hiro's friends to form a team of high-tech heroes.",
                    Trailer = "https://www.youtube.com/embed/z3biFxZIJOQ"
                },
                new Pelicula
                {
                    PeliculaId = 12,
                    Titulo = "Alice in Wonderland",
                    Poster = "https://i.imgur.com/iekJ7Pj.jpeghttps://i.imgur.com/iekJ7Pj.jpeg",
                    Sinopsis = "Alice, now 19 years old, follows a rabbit in a blue coat to a magical wonderland from her dreams where she is reunited with her friends who make her realise her true destiny.",
                    Trailer = "https://www.youtube.com/embed/KLIqErnQCuw"
                }
            );

            modelBuilder.Entity<Funcion>().HasData(
                new Funcion
                {
                    FuncionId = 1,
                    PeliculaId = 1,
                    SalaId = 1,
                    Fecha = DateTime.Today.Date,
                    Horario = new TimeSpan(9,0,0)
                },
                new Funcion
                {
                    FuncionId = 2,
                    PeliculaId = 2,
                    SalaId = 1,
                    Fecha = DateTime.Today.Date,
                    Horario = new TimeSpan(13, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 3,
                    PeliculaId = 3,
                    SalaId = 1,
                    Fecha = DateTime.Today.Date,
                    Horario = new TimeSpan(16, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 4,
                    PeliculaId = 4,
                    SalaId = 1,
                    Fecha = DateTime.Today.Date,
                    Horario = new TimeSpan(19, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 5,
                    PeliculaId = 5,
                    SalaId = 1,
                    Fecha = DateTime.Today.Date,
                    Horario = new TimeSpan(22, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 6,
                    PeliculaId = 6,
                    SalaId = 3,
                    Fecha = DateTime.Today.Date,
                    Horario = new TimeSpan(19, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 7,
                    PeliculaId = 7,
                    SalaId = 2,
                    Fecha = DateTime.Today.Date,
                    Horario = new TimeSpan(13, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 8,
                    PeliculaId = 8,
                    SalaId = 3,
                    Fecha = DateTime.Today.Date,
                    Horario = new TimeSpan(13, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 9,
                    PeliculaId = 11,
                    SalaId = 1,
                    Fecha = DateTime.Today.AddDays(1),
                    Horario = new TimeSpan(13, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 10,
                    PeliculaId = 11,
                    SalaId = 3,
                    Fecha = DateTime.Today.AddDays(2),
                    Horario = new TimeSpan(15, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 11,
                    PeliculaId = 12,
                    SalaId = 2,
                    Fecha = DateTime.Today.AddDays(3),
                    Horario = new TimeSpan(14, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 12,
                    PeliculaId = 12,
                    SalaId = 3,
                    Fecha = DateTime.Today.AddDays(4),
                    Horario = new TimeSpan(11, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 13,
                    PeliculaId = 10,
                    SalaId = 1,
                    Fecha = DateTime.Today.AddDays(5),
                    Horario = new TimeSpan(18, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 14,
                    PeliculaId = 10,
                    SalaId = 2,
                    Fecha = DateTime.Today.AddDays(6),
                    Horario = new TimeSpan(22, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 15,
                    PeliculaId = 9,
                    SalaId = 1,
                    Fecha = DateTime.Today.AddDays(7),
                    Horario = new TimeSpan(17, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 16,
                    PeliculaId = 9,
                    SalaId = 3,
                    Fecha = DateTime.Today.AddDays(8),
                    Horario = new TimeSpan(10, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 17,
                    PeliculaId = 8,
                    SalaId = 2,
                    Fecha = DateTime.Today.AddDays(9),
                    Horario = new TimeSpan(17, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 18,
                    PeliculaId = 8,
                    SalaId = 1,
                    Fecha = DateTime.Today.AddDays(10),
                    Horario = new TimeSpan(19, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 19,
                    PeliculaId = 7,
                    SalaId = 2,
                    Fecha = DateTime.Today.AddDays(11),
                    Horario = new TimeSpan(16, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 20,
                    PeliculaId = 6,
                    SalaId = 3,
                    Fecha = DateTime.Today.AddDays(12),
                    Horario = new TimeSpan(9, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 21,
                    PeliculaId = 2,
                    SalaId = 2,
                    Fecha = DateTime.Today.AddDays(13),
                    Horario = new TimeSpan(11, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 22,
                    PeliculaId = 2,
                    SalaId = 3,
                    Fecha = DateTime.Today.AddDays(14),
                    Horario = new TimeSpan(13, 0, 0)
                },
                new Funcion
                {
                    FuncionId = 23,
                    PeliculaId = 1,
                    SalaId = 3,
                    Fecha = DateTime.Today.Date,
                    Horario = new TimeSpan(9, 0, 0)
                }
            );
        }

        public virtual DbSet<Funcion> Funciones { get; set; }
        public virtual DbSet<Pelicula> Peliculas { get; set; }
        public virtual DbSet<Sala> Salas { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
    }
}
