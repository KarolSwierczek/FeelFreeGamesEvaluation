using System;
using UnityEngine.InputSystem;

namespace FeelFreeGames.Evaluation.Input
{
    public class GameInputHandler : IGameInput, DefaultInputActions.IGameActions
    {
        event Action IGameInput.NextResolution
        {
            add => NextResolution += value;
            remove => NextResolution -= value;
        }

        event Action IGameInput.PreviousResolution
        {
            add => PreviousResolution += value;
            remove => PreviousResolution -= value;
        }

        private event Action NextResolution;
        private event Action PreviousResolution;
        
        private readonly DefaultInputActions _inputActions;
        
        public GameInputHandler(DefaultInputActions inputActions)
        {
            _inputActions = inputActions;
        }
        
        void IInput.Enable()
        {
            _inputActions.Game.SetCallbacks(this);
            _inputActions.Game.Enable();
        }

        void IInput.Disable()
        {
            _inputActions.Game.Disable();
        }

        void DefaultInputActions.IGameActions.OnNextResolution(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started)
            {
                return;
            }
            
            NextResolution?.Invoke();
        }

        void DefaultInputActions.IGameActions.OnPrevResolution(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started)
            {
                return;
            }
            
            PreviousResolution?.Invoke();
        }
    }
}