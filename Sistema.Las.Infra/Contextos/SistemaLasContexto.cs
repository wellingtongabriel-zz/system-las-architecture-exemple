using Microsoft.EntityFrameworkCore;

namespace Sistema.Las.Infra.Contextos
{
    public class SistemaLasContexto : DbContext
    {
        public SistemaLasContexto(DbContextOptions opcoes) : base(opcoes) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ClasseMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
