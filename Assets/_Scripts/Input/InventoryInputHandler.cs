using System;
using FeelFreeGames.Evaluation.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace FeelFreeGames.Evaluation.Input
{
    public class InventoryInputHandler : IInventoryInput, DefaultInputActions.IInventoryActions, ITickable
    {
        event Action<Vector2Int> IInventoryInput.MoveSelection
        {
            add => MoveSelection += value;
            remove => MoveSelection -= value;
        }

        event Action IInventoryInput.DrawNewItems
        {
            add => DrawNewItems += value;
            remove => DrawNewItems -= value;
        }

        event Action IInventoryInput.DeleteItem
        {
            add => DeleteItem += value;
            remove => DeleteItem -= value;
        }

        event Action IInventoryInput.PickUpItem
        {
            add => PickUpItem += value;
            remove => PickUpItem -= value;
        }

        event Action IInventoryInput.DropItem
        {
            add => DropItem += value;
            remove => DropItem -= value;
        }

        event Action IInventoryInput.CancelPickUp
        {
            add => CancelPickUp += value;
            remove => CancelPickUp -= value;
        }

        private event Action<Vector2Int> MoveSelection;
        private event Action DrawNewItems;
        private event Action DeleteItem;
        private event Action PickUpItem;
        private event Action DropItem;
        private event Action CancelPickUp;

        private readonly InventoryInputSettings _settings;
        private readonly DefaultInputActions _inputActions;
        
        private bool _itemPickedUp;
        private bool _navigationHeld;
        private float _timer;
        private float _coolDown;
        private Vector2 _currentNavigationDirection;

        public InventoryInputHandler(InventoryInputSettings settings, DefaultInputActions inputActions)
        {
            _settings = settings;
            _inputActions = inputActions;
        }

        void IInput.Enable()
        {
            _inputActions.Inventory.SetCallbacks(this);
            _inputActions.Inventory.Enable();
        }

        void IInput.Disable()
        {
            _inputActions.Inventory.Disable();
        }
        
        void IInventoryInput.OnItemPickedUp()
        {
            _itemPickedUp = true;
        }

        void IInventoryInput.OnItemDropped()
        {
            _itemPickedUp = false;
        }

        void DefaultInputActions.IInventoryActions.OnNavigate(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    OnNavigationActionStarted(context.ReadValue<Vector2>());
                    break;
                case InputActionPhase.Performed:
                    OnNavigationActionPerformed(context.ReadValue<Vector2>());
                    break;
                case InputActionPhase.Canceled:
                    OnNavigationActionCancelled();
                    break;
                case InputActionPhase.Disabled:
                case InputActionPhase.Waiting:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void DefaultInputActions.IInventoryActions.OnPickUpOrDrop(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started)
            {
                return;
            }
            
            if (_itemPickedUp)
            {
                DropItem?.Invoke();
            }
            else
            {
                PickUpItem?.Invoke();
            }
        }

        void DefaultInputActions.IInventoryActions.OnDrawItemsOrDelete(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started)
            {
                return;
            }
            
            if (_itemPickedUp)
            {
                DeleteItem?.Invoke();
            }
            else
            {
                DrawNewItems?.Invoke();
            }
        }

        void DefaultInputActions.IInventoryActions.OnCancel(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started)
            {
                return;
            }
            
            if (_itemPickedUp)
            {
                CancelPickUp?.Invoke();
            }
        }

        void ITickable.Tick()
        {
            if (!_navigationHeld)
            {
                return;
            }

            if (_coolDown <= 0)
            {
                TriggerNavigationEvent(_currentNavigationDirection);
                _coolDown = _settings.InventoryNavigationDelay.Evaluate(_timer);
            }

            _timer += Time.deltaTime;
            _coolDown -= Time.deltaTime;
        }

        private void OnNavigationActionStarted(Vector2 direction)
        {
            _currentNavigationDirection = direction;
            _navigationHeld = true;
            _timer = 0f;
            _coolDown = 0f;
        }

        private void OnNavigationActionPerformed(Vector2 direction)
        {
            _currentNavigationDirection = direction;
        }

        private void OnNavigationActionCancelled()
        {
            _currentNavigationDirection = Vector2.zero;
            _navigationHeld = false;
        }

        private void TriggerNavigationEvent(Vector2 direction)
        {
            var discreetDirection = Vector2Int.zero;
            
            if (direction.x > float.Epsilon)
            {
                discreetDirection.x = 1;
            }
            else if (direction.x < -float.Epsilon)
            {
                discreetDirection.x = -1;
            }
            
            if (direction.y > float.Epsilon)
            {
                discreetDirection.y = -1;
            }
            else if (direction.y < -float.Epsilon)
            {
                discreetDirection.y = 1;
            }
            
            MoveSelection?.Invoke(discreetDirection);
        }
    }
}