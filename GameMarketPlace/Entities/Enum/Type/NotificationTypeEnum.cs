using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enum.Type
{
    public enum NotificationTypeEnum
    {
        Information = ProcessGroupEnum.NotificationType + 1,
        Warning = ProcessGroupEnum.NotificationType + 2,
        Error = ProcessGroupEnum.NotificationType + 3,
        Fatal = ProcessGroupEnum.NotificationType + 4
    }
}
