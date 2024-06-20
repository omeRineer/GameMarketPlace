using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Main
{
    public class Blog : BaseEntity<Guid>, IEntity
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public int ReaderCount { get; set; }
        public bool Status { get; set; }
    }
}
