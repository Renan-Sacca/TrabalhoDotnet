using Microsoft.EntityFrameworkCore;
using ProjetoAcademico.Domain.Entities.Base;
using ProjetoAcademico.Domain.Interfaces.Repositories.Base;
using ProjetoAcademico.Infra.Data.Context;

namespace ProjetoAcademico.Infra.Data.Repositories.Base;

public class RepositoryBase<TEntity>(ProjetoAcademicoContext context) : IRepositoryBase<TEntity>
    where TEntity : EntityBase
{
    protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();

    public IEnumerable<TEntity> Listar()
    {
        return DbSet.AsEnumerable();
    }

    public TEntity? Obter(Guid id)
    {
        return DbSet.Find(id);
    }

    public void Adicionar(TEntity entity)
    {
        DbSet.Add(entity);
    }

    public void Atualizar(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public void Remover(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    public void Commit()
    {
        context.SaveChanges();
    }
}