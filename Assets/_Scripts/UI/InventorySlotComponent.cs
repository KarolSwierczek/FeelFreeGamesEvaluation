using UnityEngine;
using UnityEngine.UI;

namespace FeelFreeGames.Evaluation.UI
{
    public class InventorySlotComponent : MonoBehaviour
    { 
        public delegate void OnFinishedHandlingItem();
        
        [SerializeField] private Image _Icon;

        private IInventorySlotEvents _slotEvents;
        private IItemHandler _itemHandler;
        
        private OnFinishedHandlingItem _onFinishedHandlingItem;
        private Sprite _desiredIcon;

        private void Awake()
        {
            _onFinishedHandlingItem = FinishedHandlingItem;
        }

        private void OnDestroy()
        {
            if (_slotEvents == null)
            {
                return;
            }
            
            _slotEvents.ItemSet -= OnItemSet;
            _slotEvents.SlotSelected -= OnSlotSelected;
            _slotEvents.ItemDropped -= OnItemDropped;
            _slotEvents.ItemPickedUp -= OnItemPickedUp;
            _slotEvents.ItemDeleted -= OnItemDeleted;
            _slotEvents.ItemPickUpCancelled -= OnItemPickUpCancelled;
        }

        public void SetReferences(IInventorySlotEvents slotEvents, IItemHandler itemHandler)
        {
            _slotEvents = slotEvents;
            _itemHandler = itemHandler;
            
            _slotEvents.ItemSet += OnItemSet;
            _slotEvents.SlotSelected += OnSlotSelected;
            _slotEvents.ItemDropped += OnItemDropped;
            _slotEvents.ItemPickedUp += OnItemPickedUp;
            _slotEvents.ItemDeleted += OnItemDeleted;
            _slotEvents.ItemPickUpCancelled += OnItemPickUpCancelled;
        }
        
        private void OnItemDropped(IItem item)
        {
            SetIcon(null);
            _desiredIcon = item.Icon;

            _itemHandler.DropItem(_onFinishedHandlingItem);
        }

        private void OnItemPickedUp(IItem item)
        {
            SetIcon(null);
            _itemHandler.PickUpItem(item);
        }

        private void OnItemDeleted()
        {
            _itemHandler.DeleteItem();
        }

        private void OnItemPickUpCancelled(IItem item)
        {
            _itemHandler.DeleteItem();
            SetIcon(item.Icon);
        }

        private void OnItemSet(IItem item)
        {
            if (item == null)
            {
                SetIcon(null);
                return;
            }

            SetIcon(item.Icon);
        }

        private void OnSlotSelected()
        {
            _itemHandler?.SelectSlot(transform.localPosition);
        }

        private void FinishedHandlingItem()
        {
            SetIcon(_desiredIcon);
            _desiredIcon = null;
        }

        private void SetIcon(Sprite sprite)
        {
            _Icon.sprite = sprite;
            _Icon.enabled = sprite != null;
        }
    }
}