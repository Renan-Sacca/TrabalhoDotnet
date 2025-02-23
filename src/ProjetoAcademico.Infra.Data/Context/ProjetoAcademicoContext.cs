using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProjetoAcademico.Domain.Entities;
using ProjetoAcademico.Infra.CrossCutting.NotificationPattern.DTOs;

namespace ProjetoAcademico.Infra.Data.Context
{
    public class ProjetoAcademicoContext : DbContext
    {
        public ProjetoAcademicoContext(DbContextOptions<ProjetoAcademicoContext> options) 
            : base(options)
        {
        }

        public DbSet<Curso> CursoSet { get; set; }
        public DbSet<Professor> ProfessorSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            //modelBuilder.ApplyConfiguration(new CursoConfiguration()); // Mapeamento 1 a 1
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Mapeamento de forma geral

            base.OnModelCreating(modelBuilder);
        }
    }
}
