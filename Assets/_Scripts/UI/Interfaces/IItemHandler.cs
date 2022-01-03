using UnityEngine;

namespace FeelFreeGames.Evaluation.UI
{
    /// <summary>
    /// Provides animations for handling items.
    /// </summary>
    public interface IItemHandler
    {
        /// <summary>
        /// Move selection marker (with currently handled item) to a given position.
        /// </summary>
        /// <param name="position">target position</param>
        void SelectSlot(Vector3 position);
        
        /// <summary>
        /// Trigger animation for picking up an item from a slot.
        /// </summary>
        /// <param name="item">the item that should be picked up</param>
        /// <remarks><paramref name="item"/> is used to get the item icon sprite</remarks>
        void PickUpItem(IItem item);
        
        /// <summary>
        /// Trigger animation for dropping an item into a slot.
        /// </summary>
        /// <param name="onFinishedHandlingItem"> delegate that is invoked after the animation is done</param>
        void DropItem(InventorySlotComponent.OnFinishedHandlingItem onFinishedHandlingItem);
        
        /// <summary>
        /// Delete and hide the icon of an item currently being handled.
        /// </summary>
        void DeleteItem();
    }
}