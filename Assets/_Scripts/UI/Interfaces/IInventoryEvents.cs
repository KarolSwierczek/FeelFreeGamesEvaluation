using System;

namespace FeelFreeGames.Evaluation.UI
{
    public interface IInventoryEvents
    {
        event Action<IItem> ItemSelected;
        event Action ItemPickedUp;
        event Action ItemDeleted;
        event Action NewItemsDrawn;
        event Action ItemDropped;
        event Action ItemSwapped;
        event Action ItemPickUpCancelled;

        //todo: check event types
    }
}