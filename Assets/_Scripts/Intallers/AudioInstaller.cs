using FeelFreeGames.Evaluation.Controllers;
using UnityEngine;
using Zenject;

namespace FeelFreeGames.Evaluation.Installers
{
    public class AudioInstaller : MonoInstaller
    {
        [SerializeField] private AudioController _AudioController;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AudioController>().FromInstance(_AudioController).AsSingle();
            Container.BindInterfacesTo<AudioControllerBindings>().AsSingle().NonLazy();
        }
    }
}