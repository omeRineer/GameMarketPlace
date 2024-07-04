using Core.Utilities.ResultTool;
using Entities.Enum.Type;
using Entities.Models.Notification.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface INotificationService
    {
        Task<IResult> CreateAsync(CreateNotificationRequest createNotificationRequest);
    }
}
