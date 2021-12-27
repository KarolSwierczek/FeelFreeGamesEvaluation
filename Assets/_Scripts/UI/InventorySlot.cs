using UnityEngine;
using UnityEngine.UI;

namespace FeelFreeGames.Evaluation.UI
{
    public class InventorySlot : MonoBehaviour, IInventorySlot
    {
        IItem IInventorySlot.CurrentItem => _currentItem;
        
        [SerializeField] private Image _Image;
        
        private IItem _currentItem;

        void IInventorySlot.SetItem(IItem item)
        {
            _currentItem = item;
            _Image.sprite = item.Icon;
        }

        void IInventorySlot.ClearSlot()
        {
            _currentItem = null;
            _Image.sprite = null;
        }
    }
}