using System;

namespace FeelFreeGames.Evaluation.Extensions
{
	public static class ArrayExtensions
	{
		public static T[] SelectionSample<T>(this T[] array, int itemCount)
		{
			if (itemCount > array.Length)
			{
				throw new ArgumentException("Item count cannot be greater than array length!");
			}
			
			var result = new T[itemCount];
			var itemsSelected = 0;
			var index = 0;

			while (itemsSelected < itemCount)
			{
				var itemsNeeded = itemCount - itemsSelected;
				var itemsLeft = array.Length - index;
				var selectionProbability = (float) itemsNeeded / itemsLeft;

				if (UnityEngine.Random.value <= selectionProbability)
				{
					result[itemsSelected] = array[index];
					itemsSelected++;
				}

				index++;
			}

			return result;
		}
	}
}