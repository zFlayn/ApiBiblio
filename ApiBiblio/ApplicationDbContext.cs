using ApiBiblio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiBiblio
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext (DbContextOptions options) : base(options)
        {

        }

        public DbSet<Libro> Libros { get; set; }
    }
}
