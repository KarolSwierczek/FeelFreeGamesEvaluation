using UnityEngine;

namespace FeelFreeGames.Evaluation.UI
{
	public class Item : IItem
	{
		string IItem.Name => _name;
		Sprite IItem.Icon => _icon;
		
		private readonly string _name;
		private readonly Sprite _icon;

		public Item(string name, Sprite icon)
		{
			_name = name;
			_icon = icon;
		}
	}
}