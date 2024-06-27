using Entities.Models.Category.ViewModels;
using Entities.Models.Media.ViewModels;
using Entities.Models.SystemRequirement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Game.ViewModels
{
    public class GameDetailViewModel
    {
        public Guid Id { get; set; }
        public CategoryViewModel Category { get; set; }
        public SystemRequirementViewModel SystemRequirement { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<MediaViewModel> GameMedias { get; set; }
    }
}
