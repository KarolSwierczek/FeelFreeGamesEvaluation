using FeelFreeGames.Evaluation.UI;
using UnityEngine;

namespace FeelFreeGames.Evaluation.Data
{
    [CreateAssetMenu(fileName = "InventorySettings", menuName = "Inventory Settings")]
    public class InventorySettings : ScriptableObject
    {
        public InventoryComponent MenuPrefab => _MenuPrefab;
        public Vector2Int Dimensions => _Dimensions;
        public Sprite[] ItemIcons => _ItemIcons;
        public int ItemDrawCount => _ItemDrawCount;

        [SerializeField] private InventoryComponent _MenuPrefab;
        [SerializeField] private Vector2Int _Dimensions;
        [SerializeField] private Sprite[] _ItemIcons;
        [SerializeField] private int _ItemDrawCount;
    }
}