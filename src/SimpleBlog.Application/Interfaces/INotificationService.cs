namespace SimpleBlog.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendNotificationAsync(string title);
    }
}
