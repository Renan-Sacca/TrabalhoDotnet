namespace ProjetoAcademico.Infra.CrossCutting.NotificationPattern.DTOs;

public class Notification(string property, string message)
{
    public string Property { get; private set; } = property;
    public string Message { get; private set; } = message;
}