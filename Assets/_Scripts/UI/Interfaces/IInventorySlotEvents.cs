using System;

namespace FeelFreeGames.Evaluation.UI
{
    public interface IInventorySlotEvents
    {
        event Action<IItem> ItemSet;
        event Action SlotSelected;
        event Action SlotDeselected;
    }
}