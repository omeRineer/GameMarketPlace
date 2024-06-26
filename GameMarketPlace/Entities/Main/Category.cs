using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Main
{
    public class Category : BaseEntity<Guid>, IEntity
    {
        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
