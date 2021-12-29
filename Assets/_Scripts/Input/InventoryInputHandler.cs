using System;
using FeelFreeGames.Evaluation.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace FeelFreeGames.Evaluation.Input
{
    public class InventoryInputHandler : IInventoryInput, DefaultInputActions.IInventoryActions, ITickable
    {
        event Action IInventoryInput.SelectRight
        {
            add => SelectRight += value;
            remove => SelectRight -= value;
        }

        event Action IInventoryInput.SelectLeft
        {
            add => SelectLeft += value;
            remove => SelectLeft -= value;
        }

        event Action IInventoryInput.SelectUp
        {
            add => SelectUp += value;
            remove => SelectUp -= value;
        }

        event Action IInventoryInput.SelectDown
        {
            add => SelectDown += value;
            remove => SelectDown -= value;
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

        private event Action SelectRight;
        private event Action SelectLeft;
        private event Action SelectUp;
        private event Action SelectDown;
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
                TriggerNavigationEvents(_currentNavigationDirection);
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

        private void TriggerNavigationEvents(Vector2 direction)
        {
            if (direction.x > float.Epsilon)
            {
                SelectRight?.Invoke();
            }
            else if (direction.x < -float.Epsilon)
            {
                SelectLeft?.Invoke();
            }
            
            if (direction.y > float.Epsilon)
            {
                SelectUp?.Invoke();
            }
            else if (direction.y < -float.Epsilon)
            {
                SelectDown?.Invoke();
            }
        }
    }
}