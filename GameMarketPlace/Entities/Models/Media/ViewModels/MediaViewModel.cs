using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Media.ViewModels
{
    public class MediaViewModel
    {
        public Guid EntityId { get; set; }
        public int MediaTypeId { get; set; }
        public string MediaType { get; set; }
        public string MediaPath { get; set; }
    }
}
