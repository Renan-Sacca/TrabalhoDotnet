using ProjetoAcademico.Domain.DTOs.Common;
using ProjetoAcademico.Domain.DTOs.CursoDto.Adicionar;
using ProjetoAcademico.Domain.DTOs.CursoDto.Atualizar;
using ProjetoAcademico.Domain.DTOs.CursoDto.Listar;
using ProjetoAcademico.Domain.DTOs.CursoDto.Obter;
using ProjetoAcademico.Domain.Entities;
using ProjetoAcademico.Domain.Enumerators;
using ProjetoAcademico.Domain.Interfaces.Repositories;
using ProjetoAcademico.Domain.Interfaces.Services;
using ProjetoAcademico.Infra.CrossCutting.NotificationPattern;

namespace ProjetoAcademico.Domain.Services
{
    public class ServiceCurso(IRepositoryCurso repositoryCurso) : Notifiable, IServiceCurso
    {
        public ServiceResponse<IEnumerable<CursoListarDto>> Listar()
        {
            var cursos = repositoryCurso.Listar();
            var cursosDto = cursos.Select(curso => new CursoListarDto
            {
                Id = curso.Id,
                Nome = curso.Nome,
                Periodo = curso.Periodo switch
                {
                    EnumPeriodo.Manha => "Manhã",
                    EnumPeriodo.Tarde => "Tarde",
                    _ => "Noite"
                }
            });

            return new ServiceResponse<IEnumerable<CursoListarDto>>(cursosDto, this);
        }

        public ServiceResponse<CursoObterDto> Obter(Guid id)
        {
            var curso = repositoryCurso.Obter(id);
            if (curso is null) // ou if (curso == null)
            {
                AddNotification("Curso", "Curso não encontrado");
                return new ServiceResponse<CursoObterDto>(this);
            }

            var cursoDto = new CursoObterDto()
            {
                Id = curso.Id,
                Nome = curso.Nome,
                Descricao = curso.Descricao,
                CargaHoraria = curso.CargaHoraria,
                QuantidadeMaximaAlunos = curso.QuantidadeMaximaAlunos,
                Periodo = curso.Periodo
            };

            return new ServiceResponse<CursoObterDto>(cursoDto, this);
        }

        public ServiceResponse<BaseResponse> Adicionar(CursoAdicionarDto cursoDto)
        {
            var validation = new CursoAdicionarDtoValidator().Validate(cursoDto);
            if (!validation.IsValid)
            {
                AddNotifications(validation.Errors);
                return new ServiceResponse<BaseResponse>(this);
            }

            var curso = new Curso(
                cursoDto.Nome,
                cursoDto.Periodo,
                cursoDto.Descricao,
                cursoDto.CargaHoraria,
                cursoDto.QuantidadeMaximaAlunos);

            repositoryCurso.Adicionar(curso);
            repositoryCurso.Commit();

            return new ServiceResponse<BaseResponse>(
                new BaseResponse(curso.Id, "Curso Adicionado com Sucesso."), 
                this);
        }

        public ServiceResponse<BaseResponse> Atualizar(CursoAtualizarDto cursoDto)
        {
            var validation = new CursoAtualizarDtoValidator().Validate(cursoDto);
            if (!validation.IsValid)
            {
                AddNotifications(validation.Errors);
                return new ServiceResponse<BaseResponse>(this);
            }

            var curso = repositoryCurso.Obter(cursoDto.Id);
            if (curso is null)
            {
                AddNotification("Curso", "Curso não encontrado");
                return new ServiceResponse<BaseResponse>(this);
            }

            curso.Atualizar(
                cursoDto.Nome,
                cursoDto.Periodo,
                cursoDto.Descricao,
                cursoDto.CargaHoraria,
                cursoDto.QuantidadeMaximaAlunos
            );

            repositoryCurso.Commit();

            return new ServiceResponse<BaseResponse>(new BaseResponse(curso.Id, "Curso Atualizado com Sucesso."), this);
        }

        public ServiceResponse<BaseResponse> Remover(Guid id)
        {
            var curso = repositoryCurso.Obter(id);
            if (curso is null)
            {
                AddNotification("Curso", "Curso não encontrado");
                return new ServiceResponse<BaseResponse>(this);
            }

            repositoryCurso.Remover(curso);
            repositoryCurso.Commit();

            return new ServiceResponse<BaseResponse>(new BaseResponse(id, "Curso Removido com Sucesso."), this);
        }
    }
}
