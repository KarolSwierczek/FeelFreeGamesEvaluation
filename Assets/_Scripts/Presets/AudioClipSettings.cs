using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FeelFreeGames.Evaluation.Data
{
    [CreateAssetMenu(fileName = "AudioClipSettings", menuName = "Audio Clip Settings")]
    public class AudioClipSettings : ScriptableObject
    {
        public Dictionary<AudioClipType, AudioClip> AudioClipDictionary => GetAudioClipDictionary();
        
        [SerializeField] private Clip[] _Clips;

        private Dictionary<AudioClipType, AudioClip> GetAudioClipDictionary()
        {
            return _Clips.ToDictionary(clip => clip.Type, clip => clip.AudioClip);
        }
        
        [Serializable]
        private class Clip
        {
            public AudioClip AudioClip;
            public AudioClipType Type;
        }
    }
}