using Business.Services.Abstract;
using MassTransit;
using Models.Enterprise;
using Models.Notification.WebService;

namespace GameStore.Enterprise.Consumer.Consumers
{
    public class CreateNotificationConsumer : IConsumer<CreateNotificationMessage>
    {
        readonly INotificationService _notificationService;

        public CreateNotificationConsumer(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task Consume(ConsumeContext<CreateNotificationMessage> context)
        {
            var message = context.Message;

            await _notificationService.CreateAsync(new CreateNotificationRequest
            {
                TypeId = (int)message.Type,
                Title = message.Title,
                Content = message.Content
            });
        }
    }
}
