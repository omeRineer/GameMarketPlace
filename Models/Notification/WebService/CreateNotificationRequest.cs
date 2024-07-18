using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Notification.WebService
{
    public class CreateNotificationRequest
    {
        public int TypeId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
