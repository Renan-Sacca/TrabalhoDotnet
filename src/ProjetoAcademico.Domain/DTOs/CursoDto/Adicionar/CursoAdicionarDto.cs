using ProjetoAcademico.Domain.Enumerators;

namespace ProjetoAcademico.Domain.DTOs.CursoDto.Adicionar;

public class CursoAdicionarDto
{
    public string Nome { get; set; } = string.Empty;
    public EnumPeriodo Periodo { get; set; }
    public string? Descricao { get; set; }
    public int CargaHoraria { get; set; }
    public int QuantidadeMaximaAlunos { get; set; }
}