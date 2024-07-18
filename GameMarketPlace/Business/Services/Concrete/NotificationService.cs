using AutoMapper;
using Business.Services.Abstract;
using MA = Core.Entities.Concrete.Notification;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Enum.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Notification.WebService;

namespace Business.Services.Concrete
{
    public class NotificationService : INotificationService
    {
        readonly INotificationRepository _notificationRepository;
        readonly IMapper _mapper;

        public NotificationService(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<IResult> CreateAsync(CreateNotificationRequest createNotificationRequest)
        {
            var mappedEntity = _mapper.Map<MA.Notification>(createNotificationRequest);

            await _notificationRepository.AddAsync(mappedEntity);
            await _notificationRepository.SaveAsync();

            return new SuccessResult();
        }

    }
}
