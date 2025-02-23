using ProjetoAcademico.Domain.DTOs.Common;
using ProjetoAcademico.Domain.DTOs.CursoDto.Adicionar;
using ProjetoAcademico.Domain.DTOs.CursoDto.Atualizar;
using ProjetoAcademico.Domain.DTOs.CursoDto.Listar;
using ProjetoAcademico.Domain.DTOs.CursoDto.Obter;

namespace ProjetoAcademico.Domain.Interfaces.Services
{
    public interface IServiceCurso
    {
        ServiceResponse<IEnumerable<CursoListarDto>> Listar();
        ServiceResponse<CursoObterDto> Obter(Guid id);
        ServiceResponse<BaseResponse> Adicionar(CursoAdicionarDto cursoDto);
        ServiceResponse<BaseResponse> Atualizar(CursoAtualizarDto cursoDto);
        ServiceResponse<BaseResponse> Remover(Guid id);
    }
}
