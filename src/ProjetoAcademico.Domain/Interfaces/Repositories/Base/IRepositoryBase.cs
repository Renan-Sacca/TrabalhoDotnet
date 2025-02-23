using ProjetoAcademico.Domain.Entities.Base;

namespace ProjetoAcademico.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        IEnumerable<TEntity> Listar();
        TEntity? Obter(Guid id);
        void Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        void Remover(TEntity entity);
        void Commit();
    }
}
