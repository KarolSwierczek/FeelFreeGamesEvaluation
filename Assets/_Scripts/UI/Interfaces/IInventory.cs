using UnityEngine;

namespace FeelFreeGames.Evaluation.UI
{
	public interface IInventory
	{
		void MoveSelection(Vector2Int direction);

		void PickUpItem();
		void DropItem();
		void CancelPickUp();
		void DeleteItem();
		
		void DrawNewItems();
	}
}