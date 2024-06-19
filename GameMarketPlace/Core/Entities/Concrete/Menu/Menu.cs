using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete.Menu
{
    public class Menu : BaseEntity<Guid>, IEntity
    {
        public Guid? ParentMenuId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int? Priority { get; set; }
        public string To { get; set; }
        public string Icon { get; set; }

        public Menu ParentMenu { get; set; }

    }
}
