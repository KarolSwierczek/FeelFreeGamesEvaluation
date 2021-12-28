using System;
using TMPro;
using UnityEngine;

namespace FeelFreeGames.Evaluation.UI
{
    public class InventoryComponent : MonoBehaviour
    {
        [SerializeField] private InventorySlotComponent[] _Slots;
        [SerializeField] private TextMeshProUGUI _ItemLabel;
        
        private IInventoryEvents _entity;
        
        private void OnDestroy()
        {
            if (_entity == null)
            {
                return;
            }
            
            _entity.SlotsCreated -= OnSlotsCreated;
            _entity.ItemSelected -= OnItemSelected;
        }

        public void SetEntity(IInventoryEvents entity)
        {
            _entity = entity;
            _entity.SlotsCreated += OnSlotsCreated;
            _entity.ItemSelected += OnItemSelected;
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
                _Slots[i].SetEntity(slots[i]);
            }
        }

        private void OnItemSelected(IItem item)
        {
            _ItemLabel.SetText(item == null ? string.Empty : item.Name);
        }
    }
}