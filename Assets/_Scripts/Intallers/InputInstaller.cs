using FeelFreeGames.Evaluation.Data;
using FeelFreeGames.Evaluation.Input;
using UnityEngine;
using Zenject;

namespace FeelFreeGames.Evaluation.Installers
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private InventoryInputSettings _InventoryInputSettings;
        
        public override void InstallBindings()
        {
            var inputActions = new DefaultInputActions();
            
            Container.Bind(typeof(IInventoryInput), typeof(ITickable)).To<InventoryInputHandler>()
                .AsSingle().WithArguments(_InventoryInputSettings, inputActions);
            Container.Bind<IGameInput>().To<GameInputHandler>().AsSingle().WithArguments(inputActions);
        }
    }
}

