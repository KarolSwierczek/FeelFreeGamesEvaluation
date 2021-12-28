namespace FeelFreeGames.Evaluation.UI
{
	public interface IInventory
	{
		void SelectRight();
		void SelectLeft();
		void SelectUp();
		void SelectDown();

		void DrawNewItems(int itemCount);
		IItem PickUpItem();
		IItem DropItem();
		
		//todo: complete and make Inventory implement this
	}
}