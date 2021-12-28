using System;
using FeelFreeGames.Evaluation.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace FeelFreeGames.Evaluation.Input
{
    public class InventoryInputHandler : IInventoryInput, ITickable
    {
        event Action IInventoryInput.SelectRight
        {
            add => _selectRight += value;
            remove => _selectRight -= value;
        }

        event Action IInventoryInput.SelectLeft
        {
            add => _selectLeft += value;
            remove => _selectLeft -= value;
        }

        event Action IInventoryInput.SelectUp
        {
            add => _selectUp += value;
            remove => _selectUp -= value;
        }

        event Action IInventoryInput.SelectDown
        {
            add => _selectDown += value;
            remove => _selectDown -= value;
        }

        event Action IInventoryInput.DrawNewItems
        {
            add => _drawNewItems += value;
            remove => _drawNewItems -= value;
        }

        event Action IInventoryInput.DeleteItem
        {
            add => _deleteItem += value;
            remove => _deleteItem -= value;
        }

        event Action IInventoryInput.PickUpItem
        {
            add => _pickUpItem += value;
            remove => _pickUpItem -= value;
        }

        event Action IInventoryInput.DropItem
        {
            add => _dropItem += value;
            remove => _dropItem -= value;
        }

        event Action IInventoryInput.CancelPickUp
        {
            add => _cancelPickUp += value;
            remove => _cancelPickUp -= value;
        }

        private event Action _selectRight;
        private event Action _selectLeft;
        private event Action _selectUp;
        private event Action _selectDown;
        private event Action _drawNewItems;
        private event Action _deleteItem;
        private event Action _pickUpItem;
        private event Action _dropItem;
        private event Action _cancelPickUp;

        private readonly InventoryInputSettings _settings;
        
        private bool _itemPickedUp;

        public InventoryInputHandler(InventoryInputSettings settings)
        {
            _settings = settings;
            InputSystem.onActionChange += ProcessInputActions;
        }

        public void Release()
        {
            InputSystem.onActionChange -= ProcessInputActions;
        }
        
        void IInventoryInput.OnItemPickedUp()
        {
            _itemPickedUp = true;
        }

        void IInventoryInput.OnItemDropped()
        {
            _itemPickedUp = false;
        }
        
        void ITickable.Tick()
        {
            //todo: handle holding navigation buttons 
        }

        private void ProcessInputActions(object action, InputActionChange change)
        {
            //todo:
        }


    }
}