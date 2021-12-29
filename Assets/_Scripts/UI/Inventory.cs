using System;
using _Scripts.Extensions;
using FeelFreeGames.Evaluation.Utils;
using UnityEngine;

namespace FeelFreeGames.Evaluation.UI
{
	public class Inventory : IInventory, IInventoryEvents
	{
		#region Events
		event Action<IItem> IInventoryEvents.ItemSelected
		{
			add => ItemSelected += value;
			remove => ItemSelected -= value;
		}

		event Action IInventoryEvents.ItemPickedUp
		{
			add => ItemPickedUp += value;
			remove => ItemPickedUp -= value;
		}

		event Action IInventoryEvents.ItemDeleted
		{
			add => ItemDeleted += value;
			remove => ItemDeleted -= value;
		}

		event Action IInventoryEvents.NewItemsDrawn
		{
			add => NewItemsDrawn += value;
			remove => NewItemsDrawn -= value;
		}

		event Action IInventoryEvents.ItemDropped
		{
			add => ItemDropped += value;
			remove => ItemDropped -= value;
		}

		event Action IInventoryEvents.ItemSwapped
		{
			add => ItemSwapped += value;
			remove => ItemSwapped -= value;
		}

		event Action IInventoryEvents.ItemPickUpCancelled
		{
			add => ItemPickUpCancelled += value;
			remove => ItemPickUpCancelled -= value;
		}
		
		private event Action<IItem> ItemSelected;
		private event Action ItemPickedUp;
		private event Action ItemDeleted;
		private event Action NewItemsDrawn;
		private event Action ItemDropped;
		private event Action ItemSwapped;
		private event Action ItemPickUpCancelled;
		#endregion Events


		private IInventorySlot SelectedSlot => _slots[_selectedSlotIndex];
		
		private int _selectedSlotIndex;

		private readonly IInventorySlot[] _slots;
		private readonly IItem[] _availableItems;
		private readonly Vector2Int _size;
		private readonly int _slotCount;
		private readonly int _itemDrawCount;

		public Inventory(Vector2Int size, IItem[] availableItems, int itemDrawCount)
		{
			_slotCount = size.x * size.y;
			_slots = new IInventorySlot[_slotCount];
			_availableItems = availableItems;
			_size = size;
			_itemDrawCount = itemDrawCount;
		}

		public IInventorySlotEvents[] CreateSlots()
		{
			var slotEvents = new IInventorySlotEvents[_slotCount];

			for (var i = 0; i < _slotCount; i++)
			{
				var slot = new InventorySlot();
				_slots[i] = slot;
				slotEvents[i] = slot;
			}
			
			return slotEvents;
		}
		
		public void Initialize()
		{
			DrawNewItems(_itemDrawCount);
			SelectSlot(0);
		}

		void IInventory.MoveSelection(Vector2Int direction)
		{
			var desiredCoord = MathUtils.IndexToCoords(_selectedSlotIndex, _size.x) + direction;
			var fits = MathUtils.ClampCoords(ref desiredCoord, _size);

			if (!fits)
			{
				return;
			}
			
			var desiredIndex = MathUtils.CoordsToIndex(desiredCoord, _size.x);

			if (_slots[desiredIndex].Selectable)
			{
				SelectSlot(desiredIndex);
				return;
			}

			//if the slot is not selectable, attempt to move to a next free slot
			desiredCoord += direction;
			fits = MathUtils.ClampCoords(ref desiredCoord, _size);
			desiredIndex = MathUtils.CoordsToIndex(desiredCoord, _size.x);
			
			if (!fits || !_slots[desiredIndex].Selectable)
			{
				return;
			}
			
			SelectSlot(desiredIndex);
		}

		void IInventory.PickUpItem()
		{
			Debug.LogError("Not implemented: PickUpItem");
			ItemPickedUp?.Invoke();
		}

		void IInventory.DropItem()
		{
			if (SelectedSlot.CurrentItem != null)
			{
				Debug.LogError("Not implemented: SwapItem");
				ItemSwapped?.Invoke();
			}
			else
			{
				Debug.LogError("Not implemented: DropItem");
				ItemDropped?.Invoke();
			}
		}

		void IInventory.CancelPickUp()
		{
			Debug.LogError("Not implemented: CancelPickUp");
			ItemPickUpCancelled?.Invoke();
		}

		void IInventory.DeleteItem()
		{
			Debug.LogError("Not implemented: DeleteItem");
			ItemDeleted?.Invoke();
		}
		
		void IInventory.DrawNewItems()
		{
			DrawNewItems(_itemDrawCount);
			NewItemsDrawn?.Invoke();
		}

		private void DrawNewItems(int itemCount)
		{
			foreach (var inventorySlot in _slots)
			{
				inventorySlot.ClearSlot();
			}

			var randomSlots = _slots.SelectionSample(itemCount);
			var randomItems = _availableItems.SelectionSample(itemCount);

			for (var i = 0; i < itemCount; i++)
			{
				randomSlots[i].SetItem(randomItems[i]);
			}
			
			ItemSelected?.Invoke(SelectedSlot.CurrentItem);
		}

		private void SelectSlot(int index)
		{
			SelectedSlot.SetSelection(false);
			_selectedSlotIndex = index;
			SelectedSlot.SetSelection(true);
			
			ItemSelected?.Invoke(SelectedSlot.CurrentItem);
		}
	}
}