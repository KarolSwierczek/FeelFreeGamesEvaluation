namespace FeelFreeGames.Evaluation.UI
{
	public interface IInventorySlot
	{
		IItem CurrentItem { get; }
		bool Selectable { get; set; }

		void SetItem(IItem item);
		void ClearSlot();
		void SetSelection(bool selected);
	}
}