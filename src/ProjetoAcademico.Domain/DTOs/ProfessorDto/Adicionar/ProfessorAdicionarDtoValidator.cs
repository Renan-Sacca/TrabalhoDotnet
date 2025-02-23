using FluentValidation;

namespace ProjetoAcademico.Domain.DTOs.ProfessorDto.Adicionar
{
    public class ProfessorAdicionarDtoValidator : AbstractValidator<ProfessorAdicionarDto>
    {
        public ProfessorAdicionarDtoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres");

            RuleFor(p => p.Biografia)
                .NotEmpty().WithMessage("Biografia é obrigatória")
                .MaximumLength(1000).WithMessage("Biografia deve ter no máximo 1000 caracteres");
        }
    }
}
