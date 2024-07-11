using GameStore.Cms.Model.Base.Inputs;

namespace GameStore.Cms.Model.Game
{
    public class CreateGameModel
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public InputFile Cover { get; set; }
    }
}
