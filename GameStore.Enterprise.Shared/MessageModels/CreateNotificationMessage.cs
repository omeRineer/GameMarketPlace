using Entities.Enum.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Enterprise.Shared.MessageModels
{
    public class CreateNotificationMessage
    {
        public NotificationTypeEnum Type { get; set; }
        public string Title { get; set; }
        public object Content { get; set; }
    }
}
