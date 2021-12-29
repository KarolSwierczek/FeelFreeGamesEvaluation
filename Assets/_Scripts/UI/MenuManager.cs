using System.Collections.Generic;
using System.Linq;
using FeelFreeGames.Evaluation.Data;
using FeelFreeGames.Evaluation.Input;
using UnityEngine;
using Zenject;

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

        private IInventoryInput _inventoryInput;
        private IGameInput _gameInput;

        private void OnEnable()
        {
            SpawnInventory(_InventorySettings);
        }

        private void OnDisable()
        {
            DespawnInventory();
        }

        [Inject]
        private void ResolveBindings(IInventoryInput inventoryInput, IGameInput gameInput)
        {
            _inventoryInput = inventoryInput;
            _gameInput = gameInput;
        }

        private void SpawnInventory(InventorySettings settings)
        {
            _inventoryComponent = Instantiate(settings.MenuPrefab, _MenuCanvas);

            var availableItems = GetItemsFromIcons(settings.ItemIcons);
            _inventory = new Inventory(settings.Dimensions, availableItems, settings.ItemDrawCount);
            
            _inventoryComponent.SetEntity(_inventory);
            _inventory.CreateSlots();
            
            BindInputToInventory(_inventoryInput, _inventory);
        }

        private void DespawnInventory()
        {
            UnindInputToInventory(_inventoryInput, _inventory);
            Destroy(_inventoryComponent);
            
            _inventoryComponent = null;
            _inventory = null;
        }

        private void BindInputToInventory(IInventoryInput input, IInventory inventory)
        {
            input.SelectRight += inventory.SelectRight;
            input.SelectLeft += inventory.SelectLeft;
            input.SelectUp += inventory.SelectUp;
            input.SelectDown += inventory.SelectDown;
            
            input.PickUpItem += inventory.PickUpItem;
            input.DropItem += inventory.DropItem;
            input.CancelPickUp += inventory.CancelPickUp;
            input.DeleteItem += inventory.DeleteItem;
            
            input.DrawNewItems += inventory.DrawNewItems;
            
            input.Enable();
        }
        
        private void UnindInputToInventory(IInventoryInput input, IInventory inventory)
        {
            input.SelectRight -= inventory.SelectRight;
            input.SelectLeft -= inventory.SelectLeft;
            input.SelectUp -= inventory.SelectUp;
            input.SelectDown -= inventory.SelectDown;
            
            input.PickUpItem -= inventory.PickUpItem;
            input.DropItem -= inventory.DropItem;
            input.CancelPickUp -= inventory.CancelPickUp;
            input.DeleteItem -= inventory.DeleteItem;
            
            input.DrawNewItems -= inventory.DrawNewItems;
            
            input.Disable();
        }

        private static IItem[] GetItemsFromIcons(IEnumerable<Sprite> icons)
        {
            return icons.Select(icon => new Item(icon.name, icon) as IItem).ToArray();
        }
    }
}