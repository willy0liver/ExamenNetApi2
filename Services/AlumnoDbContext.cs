using Examen2.Entities;
using Microsoft.EntityFrameworkCore;

namespace Examen2.Services
{
    public class AlumnoDbContext : DbContext
    {
        public AlumnoDbContext(DbContextOptions options) : base(options) { }
        public DbSet<AlumnoItem> AlumnoItems { get; set; }
    }
}
