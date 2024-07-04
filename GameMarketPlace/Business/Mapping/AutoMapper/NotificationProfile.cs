using AutoMapper;
using Core.Entities.Concrete.Notification;
using Entities.Models.Notification.Rest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.AutoMapper
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<CreateNotificationRequest, Notification>()
                .ForMember(d => d.Content, s => s.MapFrom(x => JsonConvert.SerializeObject(x.Content)));
        }
    }
}
