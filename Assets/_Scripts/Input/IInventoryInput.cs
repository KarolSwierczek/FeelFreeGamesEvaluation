using System;
using UnityEngine;

namespace FeelFreeGames.Evaluation.Input
{
    public interface IInventoryInput : IInput
    {
        event Action<Vector2Int> MoveSelection;
        
        event Action DrawNewItems;
        event Action DeleteItem;
        
        event Action PickUpItem;
        event Action DropItem;
        event Action CancelPickUp;
        
        void OnItemPickedUp();
        void OnItemDropped();
    }
}