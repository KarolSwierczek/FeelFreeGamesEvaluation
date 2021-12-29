using FeelFreeGames.Evaluation.Data;
using UnityEngine;

namespace FeelFreeGames.Evaluation.Controllers
{
    public class AudioController : MonoBehaviour, IAudioController
    {
        [SerializeField] private AudioSource _Source;
        [SerializeField] private AudioClipSettings _Settings;
        
        void IAudioController.SetAudioClipSettings(AudioClipSettings settings)
        {
            _Settings = settings;
        }

        void IAudioController.PlayClipOfType(AudioClipType clipType)
        {
            _Source.PlayOneShot(_Settings.AudioClipDictionary[clipType]);
        }

        void IAudioController.StopPlayback()
        {
            _Source.Stop();
        }
    }
}