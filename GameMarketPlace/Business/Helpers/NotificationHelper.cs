using MA = Core.Entities.Concrete.Notification;
using Core.Utilities.ResultTool;
using Core.Utilities.ServiceTools;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enum.Type;
using GameStore.Enterprise.Shared.MessageModels;

namespace Business.Helpers
{
    public static class NotificationHelper
    {
        readonly static IBus Bus;

        static NotificationHelper()
        {
            Bus = StaticServiceProvider.GetService<IBus>();
        }

        public static async Task PublishAsync(string title, NotificationTypeEnum notificationType, object content)
        {
            await Bus.Publish(new CreateNotificationMessage
            {
                Type = notificationType,
                Title = title,
                Content = content
            });
        }
    }
}
