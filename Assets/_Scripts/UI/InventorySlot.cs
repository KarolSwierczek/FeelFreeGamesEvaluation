using System;

namespace FeelFreeGames.Evaluation.UI
{
    public class InventorySlot : IInventorySlot, IInventorySlotEvents
    {
        event Action<IItem> IInventorySlotEvents.ItemSet
        {
            add => _itemSet += value;
            remove => _itemSet -= value;
        }
        
        IItem IInventorySlot.CurrentItem => _currentItem;
        bool IInventorySlot.Interactable { get; set; }


        private IItem _currentItem;
        private Action<IItem> _itemSet;

        void IInventorySlot.SetItem(IItem item)
        {
            _currentItem = item;
            _itemSet?.Invoke(item);
        }

        void IInventorySlot.ClearSlot()
        {
            _currentItem = null;
            _itemSet?.Invoke(null);
        }


    }
}