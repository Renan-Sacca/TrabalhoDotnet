namespace ProjetoAcademico.Domain.DTOs.ProfessorDto.Atualizar;

public class ProfessorAtualizarDto
{
    public Guid Id { get; set; }
    public required string Nome { get; set; }
    public required string Biografia { get; set; }
}
