using System;
using TMPro;
using UnityEngine;

namespace FeelFreeGames.Evaluation.UI
{
    public class InventoryComponent : MonoBehaviour
    {
        [SerializeField] private InventorySlotComponent[] _Slots;
        [SerializeField] private RectTransform _Selection;
        [SerializeField] private TextMeshProUGUI _ItemLabel;
        
        private IInventoryEvents _inventoryEvents;
        
        private void OnDestroy()
        {
            if (_inventoryEvents == null)
            {
                return;
            }
            
            _inventoryEvents.SlotsCreated -= OnSlotsCreated;
            _inventoryEvents.ItemSelected -= OnItemSelected;
        }

        public void SetReferences(IInventoryEvents inventoryEvents, IInventorySlotEvents[] slotEvents)
        {
            _inventoryEvents = inventoryEvents;
            _inventoryEvents.SlotsCreated += OnSlotsCreated;
            _inventoryEvents.ItemSelected += OnItemSelected;
            
            OnSlotsCreated(slotEvents);
        }

        private void OnSlotsCreated(IInventorySlotEvents[] slots)
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
                _Slots[i].SetReferences(slots[i]);
            }
        }

        private void OnItemSelected(IItem item)
        {
            _ItemLabel.SetText(item == null ? string.Empty : item.Name);
        }
    }
}