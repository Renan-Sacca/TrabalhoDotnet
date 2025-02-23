using FluentValidation.Results;
using ProjetoAcademico.Infra.CrossCutting.NotificationPattern.DTOs;
using ProjetoAcademico.Infra.CrossCutting.NotificationPattern.Interface;

namespace ProjetoAcademico.Infra.CrossCutting.NotificationPattern;

public class Notifiable : INotifiable
{
    private readonly List<Notification> _notifications;

    public Notifiable()
    {
        _notifications = [];
    }

    public IReadOnlyCollection<Notification> Notifications => _notifications;

    public void AddNotification(string property, string message)
    {
        _notifications.Add(new Notification(property, message));
    }

    public void AddNotification(Notification notification)
    {
        _notifications.Add(notification);
    }

    public void AddNotifications(IReadOnlyCollection<Notification> notifications)
    {
        _notifications.AddRange(notifications);
    }

    public void AddNotifications(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors) 
        {
            AddNotification(error.PropertyName, error.ErrorMessage);
        }
    }

    public void AddNotifications(IEnumerable<ValidationFailure> failures)
    {
        foreach (var failure in failures)
        {
            AddNotification(failure.PropertyName, failure.ErrorMessage);
        }
    }

    public void ClearNotifications()
    {
        _notifications.Clear();
    }

    public bool IsInvalid() => _notifications.Count > 0;

    public bool IsValid() => _notifications.Count == 0; 
}