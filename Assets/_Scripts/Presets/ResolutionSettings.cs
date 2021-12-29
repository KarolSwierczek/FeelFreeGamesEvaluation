using System;
using System.Linq;
using UnityEngine;

namespace FeelFreeGames.Evaluation.Data
{
    [CreateAssetMenu(fileName = "ResolutionSettings", menuName = "Resolution Settings")]
    public class ResolutionSettings : ScriptableObject
    {
        public int Count => _Resolutions.Length;
        public Vector2Int[] Resolutions => _Resolutions.Select(res => res.Value).ToArray();
        public int[] EditorIndices => _Resolutions.Select(res => res.EditorIndex).ToArray();
        
        [SerializeField] private Resolution[] _Resolutions;
        
        [Serializable]
        private class Resolution
        {
            public Vector2Int Value;
            public int EditorIndex;

            public Resolution(Vector2Int value, int editorIndex)
            {
                Value = value;
                EditorIndex = editorIndex;
            }
        }
    }
}