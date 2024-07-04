using System;

namespace Entities.Models.SystemRequirement.Dto
{
    public class SystemRequirementDto
    {
        public Guid Id { get; set; }
        public int SystemRequirementTypeId { get; set; }
        public string SystemRequirementTypeName { get; set; }
        //public GameDto Game { get; set; }
        public string OS { get; set; }
        public string Processor { get; set; }
        public string Ram { get; set; }
        public string DisplayCard { get; set; }
        public string Storage { get; set; }
    }
}
