using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Enum.Type;
using Entities.Models.Notification.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class NotificationService : INotificationService
    {
        public Task<IResult> CreateAsync(CreateNotificationRequest createNotificationRequest)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> PublishAsync(string title, NotificationTypeEnum notificationType, object content)
        {
            throw new NotImplementedException();
        }
    }
}
