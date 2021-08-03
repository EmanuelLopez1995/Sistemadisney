using Microsoft.EntityFrameworkCore;
using SistemaDisney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDisney.Data
{
    public class DisneyDbContext: DbContext
    {
        public DisneyDbContext(DbContextOptions<DisneyDbContext> options) : base(options){ }


        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
