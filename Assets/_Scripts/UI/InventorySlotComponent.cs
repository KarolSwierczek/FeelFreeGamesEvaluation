using UnityEngine;
using UnityEngine.UI;

namespace FeelFreeGames.Evaluation.UI
{
    public class InventorySlotComponent : MonoBehaviour
    {
        [SerializeField] private Image _Image;

        private IInventorySlotEvents _entity;
        
        private void OnDestroy()
        {
            if (_entity == null)
            {
                return;
            }
            
            _entity.ItemSet -= OnItemSet;
        }

        public void SetEntity(IInventorySlotEvents entity)
        {
            _entity = entity;
            _entity.ItemSet += OnItemSet;
        }

        private void OnItemSet(IItem item)
        {
            if (item == null)
            {
                _Image.sprite = null;
                _Image.enabled = false;
                return;
            }

            _Image.enabled = true;
            _Image.sprite = item.Icon;
        }
    }
}