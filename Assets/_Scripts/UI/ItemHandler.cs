using System;
using FeelFreeGames.Evaluation.Data;
using UnityEngine;

namespace FeelFreeGames.Evaluation.UI
{
    /// <inheritdoc cref="IItemHandler"/>
    public class ItemHandler : IItemHandler, IItemHandlerEvents
    {
        #region Event Args
        public class ItemAnimationEventArgs
        {
            public float Duration { get; }
            public float Height { get; }
            public float Scale { get; }
            public AnimationCurve AnimationCurve { get; }
            
            public ItemAnimationEventArgs( float duration, float height, float scale, AnimationCurve animationCurve)
            {
                Duration = duration;
                Height = height;
                Scale = scale;
                AnimationCurve = animationCurve;
            }
        }
        
        public class SelectionAnimationEventArgs
        {
            public float Duration { get; }
            public Vector3 TargetPosition { get; }
            public AnimationCurve AnimationCurve { get; }
            
            public SelectionAnimationEventArgs(float duration, Vector3 targetPosition, AnimationCurve animationCurve)
            {
                Duration = duration;
                AnimationCurve = animationCurve;
                TargetPosition = targetPosition;
            }
        }
        #endregion Event Args
        
        event Action<Sprite, ItemAnimationEventArgs> IItemHandlerEvents.ItemPickedUp
        {
            add => ItemPickedUp += value;
            remove => ItemPickedUp -= value;
        }

        event Action<InventorySlotComponent.OnFinishedHandlingItem, ItemAnimationEventArgs> IItemHandlerEvents.ItemDropped
        {
            add => ItemDropped += value;
            remove => ItemDropped -= value;
        }

        event Action IItemHandlerEvents.ItemDeleted
        {
            add => ItemDeleted += value;
            remove => ItemDeleted -= value;
        }

        event Action<SelectionAnimationEventArgs> IItemHandlerEvents.SelectionMoved
        {
            add => SelectionMoved += value;
            remove => SelectionMoved -= value;
        }

        private event Action<Sprite, ItemAnimationEventArgs> ItemPickedUp;
        private event Action<InventorySlotComponent.OnFinishedHandlingItem, ItemAnimationEventArgs> ItemDropped;
        private event Action ItemDeleted;
        private event Action<SelectionAnimationEventArgs> SelectionMoved;
        
        private readonly ItemHandlerSettings _settings;

        public ItemHandler(ItemHandlerSettings settings)
        {
            _settings = settings;
        }
        
        /// <inheritdoc />
        void IItemHandler.SelectSlot(Vector3 position)
        {
            SelectionMoved?.Invoke(
                new SelectionAnimationEventArgs(_settings.AnimationDuration, position, _settings.AnimationCurve));
        }

        /// <inheritdoc />
        void IItemHandler.PickUpItem(IItem item)
        {
            ItemPickedUp?.Invoke(item.Icon, 
                new ItemAnimationEventArgs(_settings.AnimationDuration, _settings.ItemPickUpHeight, 
                    _settings.ItemPickUpScale, _settings.AnimationCurve));
        }

        /// <inheritdoc />
        void IItemHandler.DropItem(InventorySlotComponent.OnFinishedHandlingItem onFinishedHandlingItem)
        {
            ItemDropped?.Invoke(onFinishedHandlingItem, 
                new ItemAnimationEventArgs(_settings.AnimationDuration, 0f, 1f, _settings.AnimationCurve));
        }

        /// <inheritdoc />
        void IItemHandler.DeleteItem()
        {
            ItemDeleted?.Invoke();
        }
    }
}