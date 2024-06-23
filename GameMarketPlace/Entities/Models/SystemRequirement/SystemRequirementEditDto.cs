using System;

namespace Entities.Dto.SystemRequirement
{
    public class SystemRequirementEditDto
    {
        public Guid Id { get; set; }
        public int SystemRequirementTypeId { get; set; }
        public Guid GameId { get; set; }
        public string? OS { get; set; }
        public string? Processor { get; set; }
        public string? Ram { get; set; }
        public string? DisplayCard { get; set; }
        public string? Storage { get; set; }
    }
}
