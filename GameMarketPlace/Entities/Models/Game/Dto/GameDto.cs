using Entities.Models.Category.Dto;
using Entities.Models.SystemRequirement.Dto;
using System;
using System.Collections.Generic;

namespace Entities.Models.Game.Dto
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public CategoryDto Category { get; set; }
        public SystemRequirementDto SystemRequirement { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    public record GameDeleteDto(Guid Id);
}
