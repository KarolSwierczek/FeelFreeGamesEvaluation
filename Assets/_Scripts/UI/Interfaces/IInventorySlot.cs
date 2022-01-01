namespace FeelFreeGames.Evaluation.UI
{
	public interface IInventorySlot
	{
		IItem CurrentItem { get; }

		void SetItem(IItem item, bool triggerDroppedEvent = false);
		void ClearSlot(bool triggerPickedUpEvent = false);
		void SetSelection(bool selected);
	}
}