using System;

namespace FeelFreeGames.Evaluation.UI
{
    public class InventorySlot : IInventorySlot, IInventorySlotEvents
    {
        event Action<IItem> IInventorySlotEvents.ItemSet
        {
            add => ItemSet += value;
            remove => ItemSet -= value;
        }
        
        IItem IInventorySlot.CurrentItem => _currentItem;
        bool IInventorySlot.Interactable { get; set; }


        private IItem _currentItem;
        private Action<IItem> ItemSet;

        void IInventorySlot.SetItem(IItem item)
        {
            _currentItem = item;
            ItemSet?.Invoke(item);
        }

        void IInventorySlot.ClearSlot()
        {
            _currentItem = null;
            ItemSet?.Invoke(null);
        }


    }
}