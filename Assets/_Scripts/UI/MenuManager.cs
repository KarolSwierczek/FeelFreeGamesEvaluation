using System.Collections.Generic;
using System.Linq;
using FeelFreeGames.Evaluation.Controllers;
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
        private IAudioControllerBindings _audioControllerBindings;

        private void OnEnable()
        {
            SpawnInventory(_InventorySettings);
        }

        private void OnDisable()
        {
            DespawnInventory();
        }

        [Inject]
        private void ResolveBindings(IInventoryInput inventoryInput, IAudioControllerBindings audioControllerBindings)
        {
            _inventoryInput = inventoryInput;
            _audioControllerBindings = audioControllerBindings;
        }

        private void SpawnInventory(InventorySettings settings)
        {
            var availableItems = GetItemsFromIcons(settings.ItemIcons);
            
            _inventory = new Inventory(settings.Dimensions, availableItems, settings.ItemDrawCount);
            var slots = _inventory.CreateSlots();
            
            _inventoryComponent = Instantiate(settings.MenuPrefab, _MenuCanvas);
            _inventoryComponent.SetReferences(_inventory, slots);

            _inventory.Initialize();
            BindInputToInventory(_inventoryInput, _inventory, _inventory);
            _audioControllerBindings.BindInventoryAudio(_inventory);
        }

        private void DespawnInventory()
        {
            _audioControllerBindings.UnbindInventoryAudio(_inventory);
            UnbindInputToInventory(_inventoryInput, _inventory, _inventory);
            Destroy(_inventoryComponent);
            
            _inventoryComponent = null;
            _inventory = null;
        }

        private static void BindInputToInventory(IInventoryInput input, IInventory inventory, IInventoryEvents inventoryEvents)
        {
            input.MoveSelection += inventory.MoveSelection;
            input.PickUpItem += inventory.PickUpItem;
            input.DropItem += inventory.DropItem;
            input.CancelPickUp += inventory.CancelPickUp;
            input.DeleteItem += inventory.DeleteItem;
            input.DrawNewItems += inventory.DrawNewItems;

            //events going back from inventory allow to offload some of the input logic to the input handler.
            //this is useful if we change the control scheme in the future
            inventoryEvents.ItemPickedUp += input.OnItemPickedUp;
            inventoryEvents.ItemDropped += input.OnItemDropped;

            input.Enable();
        }
        
        private static void UnbindInputToInventory(IInventoryInput input, IInventory inventory, IInventoryEvents inventoryEvents)
        {
            input.MoveSelection -= inventory.MoveSelection;
            input.PickUpItem -= inventory.PickUpItem;
            input.DropItem -= inventory.DropItem;
            input.CancelPickUp -= inventory.CancelPickUp;
            input.DeleteItem -= inventory.DeleteItem;
            input.DrawNewItems -= inventory.DrawNewItems;
            
            inventoryEvents.ItemPickedUp -= input.OnItemPickedUp;
            inventoryEvents.ItemDropped -= input.OnItemDropped;
            
            input.Disable();
        }
        
        

        private static IItem[] GetItemsFromIcons(IEnumerable<Sprite> icons)
        {
            return icons.Select(icon => new Item(icon.name, icon) as IItem).ToArray();
        }
    }
}