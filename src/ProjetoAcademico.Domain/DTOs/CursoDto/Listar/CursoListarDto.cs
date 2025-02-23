namespace ProjetoAcademico.Domain.DTOs.CursoDto.Listar;

public class CursoListarDto
{
    public Guid Id { get; set; }
    public required string Nome { get; set; }
    public required string Periodo { get; set; }
}