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

        event Action<IItem> IInventorySlotEvents.ItemDropped
        {
            add => ItemDropped += value;
            remove => ItemDropped -= value;
        }

        event Action<IItem> IInventorySlotEvents.ItemPickUpCancelled
        {
            add => ItemPickUpCancelled += value;
            remove => ItemPickUpCancelled -= value;
        }

        event Action<IItem> IInventorySlotEvents.ItemSet
        {
            add => ItemSet += value;
            remove => ItemSet -= value;
        }

        event Action IInventorySlotEvents.ItemDeleted
        {
            add => ItemDeleted += value;
            remove => ItemDeleted -= value;
        }

        event Action IInventorySlotEvents.SlotSelected
        {
            add => SlotSelected += value;
            remove => SlotSelected -= value;
        }

        IItem IInventorySlot.CurrentItem => _currentItem;

        
        private event Action<IItem> ItemPickedUp;
        private event Action<IItem> ItemDropped;
        private event Action<IItem> ItemPickUpCancelled;
        private event Action<IItem> ItemSet;
        private event Action ItemDeleted;
        private event Action SlotSelected;

        private IItem _currentItem;


        void IInventorySlot.DropInItem(IItem item)
        {
            _currentItem = item;
            ItemDropped?.Invoke(item);
        }

        void IInventorySlot.PickUpItem()
        {
            ItemPickedUp?.Invoke(_currentItem);
            _currentItem = null;
        }

        void IInventorySlot.DeleteItem()
        {
            ItemDeleted?.Invoke();
        }

        void IInventorySlot.SetItem(IItem item)
        {
            _currentItem = item;
            ItemSet?.Invoke(item);
        }
        
        void IInventorySlot.CancelPickUpItem(IItem item)
        {
            _currentItem = item;
            ItemPickUpCancelled?.Invoke(item);
        }

        void IInventorySlot.ClearSlot()
        {
            _currentItem = null;
            ItemSet?.Invoke(null);
        }

        void IInventorySlot.Select()
        {
            SlotSelected?.Invoke();
        }
    }
}