using System;
using _Scripts.Extensions;
using FeelFreeGames.Evaluation.Utils;
using UnityEngine;

namespace FeelFreeGames.Evaluation.UI
{
	public class Inventory : IInventory, IInventoryEvents
	{
		event Action<IInventorySlotEvents[]> IInventoryEvents.SlotsCreated
		{
			add => SlotsCreated += value;
			remove => SlotsCreated -= value;
		}

		event Action<IItem> IInventoryEvents.ItemSelected
		{
			add => ItemSelected += value;
			remove => ItemSelected -= value;
		}

		private event Action<IInventorySlotEvents[]> SlotsCreated;
		private event Action<IItem> ItemSelected;

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

		public void CreateSlots()
		{
			var slotEvents = new IInventorySlotEvents[_slotCount];
			
			for (var i = 0; i < _slotCount; i++)
			{
				var slot = new InventorySlot();
				_slots[i] = slot;
				slotEvents[i] = slot;
			}
			
			SlotsCreated?.Invoke(slotEvents);
			
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
		}

		void IInventory.DropItem()
		{
			Debug.LogError("Not implemented: DropItem");		
		}

		void IInventory.CancelPickUp()
		{
			Debug.LogError("Not implemented: CancelPickUp");		
		}

		void IInventory.DeleteItem()
		{
			Debug.LogError("Not implemented: DeleteItem");		
		}
		
		void IInventory.DrawNewItems()
		{
			DrawNewItems(_itemDrawCount);
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
		}

		private void SelectSlot(int index)
		{
			_slots[_selectedSlotIndex].SetSelection(false);
			//todo: event for selecting a slot (used for sfx etc)
			_selectedSlotIndex = index;
			_slots[_selectedSlotIndex].SetSelection(true);
			
			ItemSelected?.Invoke(_slots[_selectedSlotIndex].CurrentItem);
		}
	}
}