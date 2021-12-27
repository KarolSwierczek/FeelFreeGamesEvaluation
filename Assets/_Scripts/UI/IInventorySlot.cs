namespace FeelFreeGames.Evaluation.UI
{
	public interface IInventorySlot
	{
		IItem CurrentItem { get; }

		void SetItem(IItem item);
		void ClearSlot();
	}
}