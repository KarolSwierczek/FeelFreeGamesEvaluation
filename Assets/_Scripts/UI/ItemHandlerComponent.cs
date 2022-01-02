using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MEC;

namespace FeelFreeGames.Evaluation.UI
{
    public class ItemHandlerComponent : MonoBehaviour
    {
        [SerializeField] private Image _ItemIcon;
        [SerializeField] private Transform _IconTransform;
        [SerializeField] private Shadow _ItemShadow;

        private IItemHandlerEvents _handlerEvents;
        private CoroutineHandle _animateHeightCoroutine;
        private CoroutineHandle _animatePositionCoroutine;

        public void SetReferences(IItemHandlerEvents handlerEvents)
        {
            _handlerEvents = handlerEvents;
            _handlerEvents.ItemPickedUp += OnItemPickedUp;
            _handlerEvents.ItemDropped += OnItemDropped;
            _handlerEvents.ItemDeleted += OnItemDeleted;
            _handlerEvents.SelectionMoved += OnSelectionMoved;
        }

        private void OnDestroy()
        {
            if (_handlerEvents == null)
            {
                return;
            }
            
            _handlerEvents.ItemPickedUp -= OnItemPickedUp;
            _handlerEvents.ItemDropped -= OnItemDropped;
            _handlerEvents.ItemDeleted -= OnItemDeleted;
            _handlerEvents.SelectionMoved -= OnSelectionMoved;
        }

        private void OnItemPickedUp(Sprite icon, ItemHandler.ItemAnimationEventArgs args)
        {
            PickUpItem(icon, args.Duration, args.Height, args.Scale, args.AnimationCurve);
        }

        private void OnItemDropped(InventorySlotComponent.OnFinishedHandlingItem onFinishedHandlingItem,
            ItemHandler.ItemAnimationEventArgs args)
        {
            DropItem(args.Duration, args.Height, args.Scale, args.AnimationCurve, () =>
            {
                onFinishedHandlingItem?.Invoke();
                SetIcon(null);
            });
        }

        private void OnItemDeleted()
        {
            SetIcon(null);
        }

        private void OnSelectionMoved(ItemHandler.SelectionAnimationEventArgs args)
        {
            MoveSelection(args.Duration, args.TargetPosition, args.AnimationCurve);
        }

        private void PickUpItem(Sprite icon, float duration, float height, float scale,
            AnimationCurve animationCurve)
        {
            Timing.KillCoroutines(_animateHeightCoroutine);
            
            SetIcon(icon);
            _animateHeightCoroutine = Timing.RunCoroutine(AnimateHeight(duration, height, scale, animationCurve));
        }
        
        private void DropItem(float duration, float height, float scale,
            AnimationCurve animationCurve, Action onAnimationFinished)
        {
            Timing.KillCoroutines(_animateHeightCoroutine);

            _animateHeightCoroutine =
                Timing.RunCoroutine(AnimateHeight(duration, height, scale, animationCurve, onAnimationFinished));
        }

        private void MoveSelection(float duration, Vector3 targetPosition, AnimationCurve animationCurve)
        {
            Timing.KillCoroutines(_animatePositionCoroutine);
            _animatePositionCoroutine = Timing.RunCoroutine(AnimatePosition(duration, targetPosition, animationCurve));
        }

        private IEnumerator<float> AnimateHeight(float duration, float height, float scale,
            AnimationCurve animationCurve, Action onAnimationFinished = null)
        {
            var timer = 0f;
            var startPosition = _IconTransform.localPosition;
            var targetPosition = Vector3.up * height;
            var startScale = _IconTransform.localScale;
            var targetScale = Vector3.one * scale;
            
            while (timer <= duration)
            {
                var animationParameter = animationCurve.Evaluate(timer / duration);
                
                _IconTransform.localPosition = Vector3.Lerp(startPosition, targetPosition, animationParameter);
                _IconTransform.localScale = Vector3.Lerp(startScale, targetScale, animationParameter);
                _ItemShadow.effectDistance = Vector2.down * _IconTransform.localPosition.y;
                
                yield return Timing.WaitForOneFrame;
                timer += Timing.DeltaTime;
            }

            _IconTransform.localPosition = targetPosition;
            _IconTransform.localScale = targetScale;
            _ItemShadow.effectDistance = Vector2.down * _IconTransform.localPosition.y;
            
            onAnimationFinished?.Invoke();
        }

        private IEnumerator<float> AnimatePosition(float duration, Vector3 targetPosition, AnimationCurve animationCurve)
        {
            var timer = 0f;
            var startPosition = transform.localPosition;
            
            while (timer <= duration)
            {
                var animationParameter = animationCurve.Evaluate(timer / duration);

                transform.localPosition = Vector3.Lerp(startPosition, targetPosition, animationParameter);
                
                yield return Timing.WaitForOneFrame;
                timer += Timing.DeltaTime;
            }

            transform.localPosition = targetPosition;
        }

        private void SetIcon(Sprite sprite)
        {
            _ItemIcon.sprite = sprite;
            _ItemIcon.enabled = sprite != null;
        }
    }
}