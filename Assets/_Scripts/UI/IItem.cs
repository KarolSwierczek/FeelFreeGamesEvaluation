using UnityEngine;

namespace FeelFreeGames.Evaluation.UI
{
	public interface IItem
	{
		string Name { get; }
		Sprite Icon { get; }
	}
}