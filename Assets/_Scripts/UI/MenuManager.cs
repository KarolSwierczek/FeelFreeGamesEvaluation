using System.Collections.Generic;
using System.Linq;
using FeelFreeGames.Evaluation.Data;
using UnityEngine;

namespace FeelFreeGames.Evaluation.UI
{
    /// <summary>
    /// Class responsible for spawning/despawning (and in the future loading/saving, opening/closing)
    /// the inventory (and other menus)
    /// </summary>
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private Transform _MenuCanvas;
        [SerializeField] private InventorySettings _InventorySettings;
        
        private Inventory _inventory;
        private InventoryComponent _inventoryComponent;

        private void OnEnable()
        {
            SpawnInventory(_InventorySettings);
        }

        private void OnDisable()
        {
            DespawnInventory();
        }

        private void SpawnInventory(InventorySettings settings)
        {
            _inventoryComponent = Instantiate(settings.MenuPrefab, _MenuCanvas);

            var availableItems = GetItemsFromIcons(settings.ItemIcons);
            _inventory = new Inventory(settings.Dimensions, availableItems, settings.ItemDrawCount);
            
            _inventoryComponent.SetEntity(_inventory);
            _inventory.CreateSlots();
        }

        private void DespawnInventory()
        {
            Destroy(_inventoryComponent);
            
            _inventoryComponent = null;
            _inventory = null;
        }

        private static IItem[] GetItemsFromIcons(IEnumerable<Sprite> icons)
        {
            return icons.Select(icon => new Item(icon.name, icon) as IItem).ToArray();
        }
    }
}