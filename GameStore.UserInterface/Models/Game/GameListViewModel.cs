namespace GameStore.UserInterface.Models.Game
{
    public class GameListViewModel
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? CoverPath { get; set; }
    }
}
