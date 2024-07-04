using Core.DataAccess.EntityFramework;
using Core.DataAccess;
using Entities.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete.Notification;

namespace DataAccess.Concrete.EntityFramework.General
{
    public interface INotificationRepository : IEntityRepository<Notification>
    {

    }
    public class NotificationRepository : EfRepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(DbContext context) : base(context)
        {
        }
    }
}
