using ProjetoAcademico.Domain.Entities;
using ProjetoAcademico.Domain.Interfaces.Repositories;
using ProjetoAcademico.Infra.Data.Context;
using ProjetoAcademico.Infra.Data.Repositories.Base;

namespace ProjetoAcademico.Infra.Data.Repositories;

public class RepositoryCurso(ProjetoAcademicoContext context)
    : RepositoryBase<Curso>(context), IRepositoryCurso;
