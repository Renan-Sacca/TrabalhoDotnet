using FluentValidation;

namespace ProjetoAcademico.Domain.DTOs.CursoDto.Atualizar;

public class CursoAtualizarDtoValidator : AbstractValidator<CursoAtualizarDto>
{
    public CursoAtualizarDtoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Nome é obrigatório")
            .MaximumLength(50).WithMessage("Nome deve ter no máximo 50 caracteres");

        RuleFor(x => x.Periodo)
            .NotEmpty().WithMessage("Período é obrigatório");

        RuleFor(x => x.Descricao)
            .MaximumLength(500).WithMessage("Descrição deve ter no máximo 500 caracteres");

        RuleFor(x => x.CargaHoraria)
            .NotEmpty().WithMessage("Carga horária é obrigatória")
            .GreaterThan(0).WithMessage("Carga horária deve ser maior que 0");

        RuleFor(x => x.QuantidadeMaximaAlunos)
            .NotEmpty().WithMessage("Quantidade máxima de alunos é obrigatória")
            .GreaterThan(0).WithMessage("Quantidade máxima de alunos deve ser maior que 0");
    }
}