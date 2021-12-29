using UnityEngine;
using UnityEngine.UI;

namespace FeelFreeGames.Evaluation.UI
{
    public class InventorySlotComponent : MonoBehaviour
    {
        [SerializeField] private Image _Icon;
        [SerializeField] private Image _Selection;

        private IInventorySlotEvents _slotEvents;
        
        private void OnDestroy()
        {
            if (_slotEvents == null)
            {
                return;
            }
            
            _slotEvents.ItemSet -= OnItemSet;
            _slotEvents.SlotSelected -= OnSlotSelected;
            _slotEvents.SlotDeselected -= OnSlotDeselected;
        }

        public void SetReferences(IInventorySlotEvents slotEvents)
        {
            _slotEvents = slotEvents;
            _slotEvents.ItemSet += OnItemSet;
            _slotEvents.SlotSelected += OnSlotSelected;
            _slotEvents.SlotDeselected += OnSlotDeselected;
        }

        private void OnItemSet(IItem item)
        {
            if (item == null)
            {
                _Icon.sprite = null;
                _Icon.enabled = false;
                return;
            }

            _Icon.enabled = true;
            _Icon.sprite = item.Icon;
        }

        private void OnSlotSelected()
        {
            _Selection.enabled = true;
        }
        
        private void OnSlotDeselected()
        {
            _Selection.enabled = false;
        }
    }
}