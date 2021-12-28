using System;

namespace FeelFreeGames.Evaluation.Input
{
    public interface IInventoryInput
    {
        event Action SelectRight;
        event Action SelectLeft;
        event Action SelectUp;
        event Action SelectDown;
        
        event Action DrawNewItems;
        event Action DeleteItem;
        
        event Action PickUpItem;
        event Action DropItem;
        event Action CancelPickUp;

        void OnItemPickedUp();
        void OnItemDropped();
    }
}