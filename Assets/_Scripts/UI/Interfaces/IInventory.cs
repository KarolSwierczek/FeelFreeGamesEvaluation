using UnityEngine;

namespace FeelFreeGames.Evaluation.UI
{
	/// <summary>
	/// Holds inventory slots and provides access to operations on items
	/// </summary>
	public interface IInventory
	{
		/// <summary>
		/// Move slot selection in the indicated direction.
		/// </summary>
		/// <param name="direction">
		/// Direction in which the selection should be moved. Has to be within [-1, -1] and [1, 1].
		/// </param>
		/// <remarks>
		/// If the slot indicated by the <paramref name="direction"/> would be outside of the inventory,
		/// the nearest available slot is selected.
		/// </remarks>
		void MoveSelection(Vector2Int direction);

		/// <summary>
		/// Take an item out of currently selected slot and hold it.
		/// </summary>
		void PickUpItem();
		
		void DropItem();
		void CancelPickUp();
		void DeleteItem();
		
		void DrawNewItems();
	}
}