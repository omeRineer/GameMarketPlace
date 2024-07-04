using Core.Entities.Abstract;
using Core.Entities.Concrete.ProcessGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete.Notification
{
    public class Notification : BaseEntity<Guid>, IEntity
    {
        public string TicketNumber { get; set; }
        public int TypeId { get; set; }
        public string Title { get; set; }
        public object Content { get; set; }

        public TypeLookup Type { get; set; }
    }
}
