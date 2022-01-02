using UnityEngine;

namespace FeelFreeGames.Evaluation.UI
{
    public interface IItemHandler
    {
        void SelectSlot(Vector3 position);
        void PickUpItem(IItem item, Vector3 position);
        void DropItem(InventorySlotComponent.OnFinishedHandlingItem onFinishedHandlingItem);
        void DeleteItem();
    }
}