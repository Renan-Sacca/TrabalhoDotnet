﻿using ProjetoAcademico.Domain.Enumerators;

namespace ProjetoAcademico.Domain.DTOs.CursoDto.Obter;

public class CursoObterDto
{
    public Guid Id { get; set; }
    public required string Nome { get; set; }
    public EnumPeriodo Periodo { get; set; }
    public string? Descricao { get; set; }
    public int CargaHoraria { get; set; }
    public int QuantidadeMaximaAlunos { get; set; }
}