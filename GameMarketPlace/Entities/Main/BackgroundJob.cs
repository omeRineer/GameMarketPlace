using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Main
{
    public class BackgroundJob : BaseEntity<int>, IEntity
    {
        public string JobName { get; set; }
        public string Cron { get; set; }
        public bool IsActive { get; set; }
    }
}
