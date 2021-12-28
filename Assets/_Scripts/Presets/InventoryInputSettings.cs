using UnityEngine;

namespace FeelFreeGames.Evaluation.Data
{
    [CreateAssetMenu(fileName = "InventoryInputSettings", menuName = "Inventory Input Settings")]
    public class InventoryInputSettings : ScriptableObject
    {
        /// <summary>
        /// when a navigation button is held down, how fast should the next item be selected
        /// </summary>
        public AnimationCurve InventoryNavigationDelay => _InventoryNavigationDelay;
        
        [SerializeField] private AnimationCurve _InventoryNavigationDelay;
    }
}