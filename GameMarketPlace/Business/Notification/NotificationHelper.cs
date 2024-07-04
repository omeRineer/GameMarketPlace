using MA = Core.Entities.Concrete.Notification;
using Core.Utilities.ResultTool;
using Core.Utilities.ServiceTools;
using Entities.Enum.Type;
using Entities.Models.Notification.Rest;
using GameStore.Enterprise.Shared.MessageModels;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Notification
{
    public static class NotificationHelper
    {
        readonly static DbContext Context;
        readonly static IBus Bus;

        static NotificationHelper()
        {
            Context = StaticServiceProvider.GetService<DbContext>();
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

        private static async Task CreateAsync(MA.Notification notification)
        {
            await Context.Set<MA.Notification>().AddAsync(notification);
            await Context.SaveChangesAsync();
        }
    }
}
