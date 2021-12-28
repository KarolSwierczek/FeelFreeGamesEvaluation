using System;

namespace FeelFreeGames.Evaluation.UI
{
    public interface IInventoryEvents
    {
        event Action<IInventorySlotEvents[]> SlotsCreated;
        event Action<IItem> ItemSelected;
    }
}