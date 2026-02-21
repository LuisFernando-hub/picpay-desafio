namespace picpay_desafio.Services.Notification
{
    public class NotificationService : INotificationService
    {
        public NotificationService() { }
        public async Task SendNotification()
        {
            await Task.Delay(1000);
            Console.WriteLine("Notification Client !");
        }
    }
}
