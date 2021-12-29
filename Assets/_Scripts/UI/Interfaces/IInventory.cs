namespace FeelFreeGames.Evaluation.UI
{
	public interface IInventory
	{
		void SelectRight();
		void SelectLeft();
		void SelectUp();
		void SelectDown();
		
		void PickUpItem();
		void DropItem();
		void CancelPickUp();
		void DeleteItem();
		
		void DrawNewItems();
	}
}