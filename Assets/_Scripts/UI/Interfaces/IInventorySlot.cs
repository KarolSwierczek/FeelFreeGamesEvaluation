namespace FeelFreeGames.Evaluation.UI
{
	public interface IInventorySlot
	{
		IItem CurrentItem { get; }
		
		void SetItem(IItem item);
		void ClearSlot();
		void DropInItem(IItem item);
		void PickUpItem();
		void CancelPickUpItem(IItem item);
		void DeleteItem();
		void Select();
	}
}