using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Game.View
{
    public class GameDetailViewModel
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? CoverPath { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
