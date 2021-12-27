using System.Collections.Generic;

namespace FeelFreeGames.Evaluation.UI
{
	public class Inventory
	{
		private readonly List<IInventorySlot> _slots;
		private readonly IItem[] _availableItems;

		public Inventory(int slotCount, IItem[] availableItems)
		{
			_slots = new List<IInventorySlot>(slotCount);
			_availableItems = availableItems;
		}
	}
}