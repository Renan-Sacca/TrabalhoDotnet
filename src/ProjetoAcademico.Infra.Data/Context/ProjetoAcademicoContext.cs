using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProjetoAcademico.Domain.Entities;
using ProjetoAcademico.Infra.CrossCutting.NotificationPattern.DTOs;
using ProjetoAcademico.Infra.Data.Configurations;

namespace ProjetoAcademico.Infra.Data.Context
{
    public class ProjetoAcademicoContext(
        DbContextOptions<ProjetoAcademicoContext> options) : DbContext(options)
    {
        public DbSet<Curso> CursoSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new CursoConfiguration()); // Mapeamento 1 a 1
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Mapeamento de forma geral

            base.OnModelCreating(modelBuilder);
        }
    }
}
