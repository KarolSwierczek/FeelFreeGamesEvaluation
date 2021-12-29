using UnityEngine;
using UnityEngine.UI;

namespace FeelFreeGames.Evaluation.UI
{
    public class InventorySlotComponent : MonoBehaviour
    {
        [SerializeField] private Image _Icon;
        [SerializeField] private Image _Selection;

        private IInventorySlotEvents _entity;
        
        private void OnDestroy()
        {
            if (_entity == null)
            {
                return;
            }
            
            _entity.ItemSet -= OnItemSet;
            _entity.SlotSelected -= OnSlotSelected;
            _entity.SlotDeselected -= OnSlotDeselected;
        }

        public void SetEntity(IInventorySlotEvents entity)
        {
            _entity = entity;
            _entity.ItemSet += OnItemSet;
            _entity.SlotSelected += OnSlotSelected;
            _entity.SlotDeselected += OnSlotDeselected;
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