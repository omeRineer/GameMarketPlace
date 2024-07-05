using Core.Entities.Concrete.ProcessGroups.Enums.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.DTO.Enterprise
{
    public class CreateNotificationMessage
    {
        public NotificationTypeEnum Type { get; set; }
        public string Title { get; set; }
        public object Content { get; set; }
    }
}
