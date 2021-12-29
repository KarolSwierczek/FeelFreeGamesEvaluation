using FeelFreeGames.Evaluation.Data;

namespace FeelFreeGames.Evaluation.Controllers
{
    public interface IAudioController
    {
        void SetAudioClipSettings(AudioClipSettings settings);
        void PlayClipOfType(AudioClipType clipType);
        void StopPlayback();
    }
}