using Microsoft.EntityFrameworkCore;
using Sistema.Las.Infra.Mapeamentos;

namespace Sistema.Las.Infra.Contextos
{
    public class SistemaLasContexto : DbContext
    {
        public SistemaLasContexto(DbContextOptions<SistemaLasContexto> opcoes) : base(opcoes) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
