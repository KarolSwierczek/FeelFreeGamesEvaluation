using System;
using _Scripts.Extensions;
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
		}

		void IInventory.SelectRight()
		{
			Debug.LogError("Not implemented: SelectRight");
		}

		void IInventory.SelectLeft()
		{
			Debug.LogError("Not implemented: SelectLeft");		
		}

		void IInventory.SelectUp()
		{
			Debug.LogError("Not implemented: SelectUp");		
		}

		void IInventory.SelectDown()
		{
			Debug.LogError("Not implemented: SelectDown");		
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
	}
}