using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Game.Dto
{
    public class CreateGameDto
    {
        public Guid CategoryId { get; set; }
        public int? DeveloperId { get; set; }
        public int? DistributorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public CreateGameImage Cover { get; set; }
    }

    public class CreateGameImage
    {
        public string FileName { get; set; }
        public string Base64 { get; set; }
    }
}
