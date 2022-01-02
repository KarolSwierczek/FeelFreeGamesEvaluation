using System;
using UnityEngine;

namespace FeelFreeGames.Evaluation.UI
{
    public interface IItemHandlerEvents
    {
        event Action<Sprite, ItemHandler.ItemAnimationEventArgs> ItemPickedUp;
        event Action<InventorySlotComponent.OnFinishedHandlingItem, ItemHandler.ItemAnimationEventArgs> ItemDropped;
        event Action ItemDeleted;
        event Action<ItemHandler.SelectionAnimationEventArgs> SelectionMoved;
    }
}