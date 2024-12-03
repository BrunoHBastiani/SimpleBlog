using Microsoft.AspNetCore.SignalR;
using SimpleBlog.Application.Interfaces;

namespace SimpleBlog.API.Notification
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendNotificationAsync(string title)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveNewPostNotification", $"Novo post disponível: {title}");
        }
    }
}
