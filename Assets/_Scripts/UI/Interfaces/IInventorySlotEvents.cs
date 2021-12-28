using System;

namespace FeelFreeGames.Evaluation.UI
{
    public interface IInventorySlotEvents
    {
        event Action<IItem> ItemSet;
    }
}