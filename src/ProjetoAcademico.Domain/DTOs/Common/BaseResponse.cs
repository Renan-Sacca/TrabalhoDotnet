namespace ProjetoAcademico.Domain.DTOs.Common;

public class BaseResponse(Guid id, string mensagem)
{
    public Guid Id { get; set; } = id;
    public string Mensagem { get; set; } = mensagem;
}