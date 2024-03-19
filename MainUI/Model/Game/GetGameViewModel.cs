using MainUI.Model.Category;

namespace UserInterface.Model.Game
{
    public record GetGameViewModel(Guid id,
                                   GetCategoryViewModel Category,
                                   string? description,
                                   decimal price,
                                   DateTime releaseDate);
}
