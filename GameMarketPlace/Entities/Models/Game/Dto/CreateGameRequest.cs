using Core.Entities.DTO.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Game.Dto
{
    public class CreateGameRequest
    {
        public Guid CategoryId { get; set; }
        public int? DeveloperId { get; set; }
        public int? DistributorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public File Cover { get; set; }
    }
}
