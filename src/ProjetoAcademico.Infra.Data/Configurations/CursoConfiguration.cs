using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAcademico.Domain.Entities;

namespace ProjetoAcademico.Infra.Data.Configurations
{
    public class CursoConfiguration : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Periodo)
                .IsRequired()
                .HasColumnType("varchar(5)");

            builder.Property(p => p.Descricao)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.Property(p => p.CargaHoraria)
                .IsRequired();

            builder.Property(p => p.QuantidadeMaximaAlunos)
                .IsRequired();

            builder.ToTable("TB_Curso");
        }
    }
}
