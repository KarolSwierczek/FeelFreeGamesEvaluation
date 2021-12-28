using System;
using _Scripts.Extensions;
using UnityEngine;

namespace FeelFreeGames.Evaluation.UI
{
	public class Inventory : IInventory, IInventoryEvents
	{
		event Action<IInventorySlotEvents[]> IInventoryEvents.SlotsCreated
		{
			add => _slotsCreated += value;
			remove => _slotsCreated -= value;
		}

		event Action<IItem> IInventoryEvents.ItemSelected
		{
			add => _itemSelected += value;
			remove => _itemSelected -= value;
		}

		private event Action<IInventorySlotEvents[]> _slotsCreated;
		private event Action<IItem> _itemSelected;

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
			
			_slotsCreated?.Invoke(slotEvents);
			
			DrawNewItems(_itemDrawCount);
		}

		void IInventory.SelectRight()
		{
			throw new System.NotImplementedException();
		}

		void IInventory.SelectLeft()
		{
			throw new System.NotImplementedException();
		}

		void IInventory.SelectUp()
		{
			throw new System.NotImplementedException();
		}

		void IInventory.SelectDown()
		{
			throw new System.NotImplementedException();
		}

		void IInventory.DrawNewItems(int itemCount)
		{
			throw new System.NotImplementedException();
		}

		IItem IInventory.PickUpItem()
		{
			throw new System.NotImplementedException();
		}

		IItem IInventory.DropItem()
		{
			throw new System.NotImplementedException();
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
	}
}