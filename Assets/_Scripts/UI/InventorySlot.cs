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
        bool IInventorySlot.Selectable
        {
            get => _selectable;
            set => _selectable = value;
        }


        private IItem _currentItem;
        private bool _selectable = true;
        private event Action<IItem> ItemSet;
        private event Action SlotSelected;
        private event Action SlotDeselected;


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

        void IInventorySlot.SetSelection(bool selected)
        {
            if (selected)
            {
                SlotSelected?.Invoke();
                _selectable = false;
            }
            else
            {
                SlotDeselected?.Invoke();
                _selectable = true;
            }
        }
    }
}