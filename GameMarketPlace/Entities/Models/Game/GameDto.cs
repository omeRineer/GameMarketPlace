using Entities.Dto.Category;
using Entities.Dto.SystemRequirement;
using System;
using System.Collections.Generic;

namespace Entities.Dto.Game
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public CategoryDto Category { get; set; }
        public SystemRequirementDto SystemRequirement { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    public record GameDeleteDto(Guid Id);
}
