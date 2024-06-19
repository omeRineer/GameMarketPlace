using Core.Entities.Abstract;
using Core.Entities.Concrete.ProcessGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Main
{
    public class SliderContent : BaseEntity<Guid>, IEntity
    {
        public int SliderTypeId { get; set; }
        public string? Header { get; set; }
        public string? To { get; set; }
        public bool IsActive { get; set; }

        public TypeLookup SliderType { get; set; }
    }
}
