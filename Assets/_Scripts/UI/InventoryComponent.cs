using System;
using TMPro;
using UnityEngine;

namespace FeelFreeGames.Evaluation.UI
{
    public class InventoryComponent : MonoBehaviour
    {
        [SerializeField] private InventorySlotComponent[] _Slots;
        [SerializeField] private TextMeshProUGUI _ItemLabel;
        
        private IInventoryEvents _inventoryEvents;
        
        private void OnDestroy()
        {
            if (_inventoryEvents == null)
            {
                return;
            }
            
            _inventoryEvents.ItemSelected -= OnItemSelected;
        }

        public void SetReferences(IInventoryEvents inventoryEvents, IInventorySlotEvents[] slotEvents, IItemHandler itemHandler)
        {
            _inventoryEvents = inventoryEvents;
            _inventoryEvents.ItemSelected += OnItemSelected;
            
            OnSlotsCreated(slotEvents, itemHandler);
        }

        private void OnSlotsCreated(IInventorySlotEvents[] slots, IItemHandler itemHandler)
        {
            if (slots == null)
            {
                throw new ArgumentException("slots cannot be null!");
            }
            
            if (_Slots.Length < slots.Length)
            {
                throw new ArgumentException(
                    "Number of slot entities cannot be grater than the number of slot components!");
            }
            
            for (var i = 0; i < slots.Length; i++)
            {
                _Slots[i].SetReferences(slots[i], itemHandler);
            }
        }

        private void OnItemSelected(IItem item)
        {
            _ItemLabel.SetText(item == null ? string.Empty : item.Name);
        }
    }
}