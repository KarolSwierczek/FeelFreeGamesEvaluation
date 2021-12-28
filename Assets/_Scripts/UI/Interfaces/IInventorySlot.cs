namespace FeelFreeGames.Evaluation.UI
{
	public interface IInventorySlot
	{
		IItem CurrentItem { get; }
		bool Interactable { get; set; }

		void SetItem(IItem item);
		void ClearSlot();
	}
}