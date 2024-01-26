using GameStore.UI.Model.Category;

namespace GameStore.UI.Model.Game
{
    public record GetGameViewModel(Guid id,
                                   GetCategoryViewModel Category,
                                   string? description,
                                   decimal price,
                                   DateTime releaseDate);
}
