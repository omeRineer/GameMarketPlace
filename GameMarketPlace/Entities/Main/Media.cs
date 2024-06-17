using Core.Entities.Abstract;
using Core.Entities.Concrete.ProcessGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Main
{
    public class Media : BaseEntity<Guid>, IEntity
    {
        public int MediaTypeId { get; set; }
        public Guid EntityId { get; set; }
        public string MediaPath { get; set; }

        public TypeLookup MediaType { get; set; }
    }
}
