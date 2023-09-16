using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete.ProcessGroups
{
    public class ProcessGroup : BaseEntity<int>, IEntity
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public ICollection<StatusLookup> StatusLookup { get; set; }
        public ICollection<TypeLookup> TypeLookups { get; set; }
    }
}
