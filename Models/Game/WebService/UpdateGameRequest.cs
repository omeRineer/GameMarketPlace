using DTO = Core.Entities.DTO.File;
using System;

namespace Models.Game.WebService
{
    public class UpdateGameRequest
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public int? DeveloperId { get; set; }
        public int? DistributorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DTO.File Cover { get; set; }
    }
}
