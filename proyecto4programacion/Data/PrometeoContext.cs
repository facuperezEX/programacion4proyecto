using Microsoft.EntityFrameworkCore;
using proyecto4programacion.Seed;

namespace proyecto4programacion.Data
{
    public class PrometeoContext : DbContext
    {
        public PrometeoContext(DbContextOptions<PrometeoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EstadoSeed());
        }
    }
}
