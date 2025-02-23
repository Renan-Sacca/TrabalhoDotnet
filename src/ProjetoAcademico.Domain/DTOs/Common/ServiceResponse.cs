using ProjetoAcademico.Infra.CrossCutting.NotificationPattern.DTOs;
using ProjetoAcademico.Infra.CrossCutting.NotificationPattern.Interface;

namespace ProjetoAcademico.Domain.DTOs.Common;

public class ServiceResponse<T> where T : class
{
    public bool Sucesso { get; set; }
    public T? Dados { get; set; }
    public IReadOnlyCollection<Notification> Notificacoes { get; set; }

    public ServiceResponse(T? dados, INotifiable notificacoes)
    {
        Sucesso = notificacoes.IsValid();
        Dados = dados;
        Notificacoes = notificacoes.Notifications;
    }

    public ServiceResponse(INotifiable notificacoes)
    {
        Sucesso = false;
        Dados = null;
        Notificacoes = notificacoes.Notifications;
    }
}