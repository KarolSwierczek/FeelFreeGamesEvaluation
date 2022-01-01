using System;

namespace FeelFreeGames.Evaluation.UI
{
    public class InventorySlot : IInventorySlot, IInventorySlotEvents
    {
        event Action<IItem> IInventorySlotEvents.ItemPickedUp
        {
            add => ItemPickedUp += value;
            remove => ItemPickedUp -= value;
        }

        event Action IInventorySlotEvents.ItemDropped
        {
            add => ItemDropped += value;
            remove => ItemDropped -= value;
            
        }
        event Action<IItem> IInventorySlotEvents.ItemSet
        {
            add => ItemSet += value;
            remove => ItemSet -= value;
        }

        event Action IInventorySlotEvents.SlotSelected
        {
            add => SlotSelected += value;
            remove => SlotSelected -= value;
        }

        event Action IInventorySlotEvents.SlotDeselected
        {
            add => SlotDeselected += value;
            remove => SlotDeselected -= value;
        }

        IItem IInventorySlot.CurrentItem => _currentItem;

        
        private event Action<IItem> ItemPickedUp;
        private event Action ItemDropped;
        private event Action<IItem> ItemSet;
        private event Action SlotSelected;
        private event Action SlotDeselected;
        
        private IItem _currentItem;
        

        void IInventorySlot.SetItem(IItem item, bool triggerDroppedEvent)
        {
            _currentItem = item;
            ItemSet?.Invoke(item);

            if (triggerDroppedEvent)
            {
                ItemDropped?.Invoke();
            }
        }

        void IInventorySlot.ClearSlot(bool triggerPickedUpEvent)
        {
            var item = _currentItem;
            
            _currentItem = null;
            ItemSet?.Invoke(null);

            if (triggerPickedUpEvent)
            {
                ItemPickedUp?.Invoke(item);
            }
        }

        void IInventorySlot.SetSelection(bool selected)
        {
            if (selected)
            {
                SlotSelected?.Invoke();
            }
            else
            {
                SlotDeselected?.Invoke();
            }
        }
    }
}