using Core.Entities.Abstract;
using Core.Entities.Concrete.ProcessGroups;
using System;

namespace Entities.Main
{
    public class SystemRequirement : BaseEntity<Guid>, IEntity
    {
        public int SystemRequirementTypeId { get; set; }
        public Guid GameId { get; set; }
        public string? OS { get; set; }
        public string? Processor { get; set; }
        public string? Ram { get; set; }
        public string? DisplayCard { get; set; }
        public string? Storage { get; set; }


        public TypeLookup SystemRequirementType { get; set; }
        public Game Game { get; set; }
    }
}
