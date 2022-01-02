using UnityEngine;

namespace FeelFreeGames.Evaluation.Data
{
    [CreateAssetMenu(fileName = "ItemHandlerSettings", menuName = "Item Handler Settings")]
    public class ItemHandlerSettings : ScriptableObject
    {
        public float AnimationDuration => _AnimationDuration;
        public AnimationCurve AnimationCurve => _AnimationCurve;
        public float ItemPickUpHeight => _ItemPickUpHeight;
        public float ItemPickUpScale => _ItemPickUpScale;
        
        [SerializeField] private float _AnimationDuration;
        [SerializeField] private AnimationCurve _AnimationCurve;
        [SerializeField] private float _ItemPickUpHeight;
        [SerializeField] private float _ItemPickUpScale;
    }
}