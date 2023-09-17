using Core.Entities.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entities.Main
{
    public class Game : BaseEntity<Guid>, IEntity
    {
        public Guid CategoryId { get; set; }
        public int? DeveloperId { get; set; }
        public int? DistributorId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }


        public Category Category { get; set; }
        public ICollection<SystemRequirement> SystemRequirements { get; set; }
    }
}
