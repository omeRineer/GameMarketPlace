using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.SystemRequirement.ViewModels
{
    public class SystemRequirementViewModel
    {
        public Guid Id { get; set; }
        public int SystemRequirementTypeId { get; set; }
        public string SystemRequirementTypeName { get; set; }
        public string? OS { get; set; }
        public string? Processor { get; set; }
        public string? Ram { get; set; }
        public string? DisplayCard { get; set; }
        public string? Storage { get; set; }
    }
}
