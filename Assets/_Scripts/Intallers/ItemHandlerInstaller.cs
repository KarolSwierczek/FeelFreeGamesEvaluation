using FeelFreeGames.Evaluation.Data;
using FeelFreeGames.Evaluation.UI;
using UnityEngine;
using Zenject;

namespace FeelFreeGames.Evaluation.Installers
{
    public class ItemHandlerInstaller : MonoInstaller
    {
        [SerializeField] private ItemHandlerSettings _ItemHandlerSettings;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ItemHandler>().AsSingle().WithArguments(_ItemHandlerSettings).NonLazy();
        }
    }
}