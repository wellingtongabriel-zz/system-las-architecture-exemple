using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Las.Domain.Categorias.Entidades;

namespace Sistema.Las.Infra.Mapeamentos
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Descricao);
        }
    }
}
