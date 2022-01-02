using System;

namespace FeelFreeGames.Evaluation.UI
{
    public interface IInventorySlotEvents
    {
        event Action<IItem> ItemPickedUp;
        event Action <IItem> ItemDropped;
        event Action <IItem> ItemPickUpCancelled;
        event Action<IItem> ItemSet;
        event Action ItemDeleted;
        event Action SlotSelected;
    }
}