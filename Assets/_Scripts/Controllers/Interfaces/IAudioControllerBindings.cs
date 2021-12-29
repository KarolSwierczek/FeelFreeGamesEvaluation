using FeelFreeGames.Evaluation.UI;

namespace FeelFreeGames.Evaluation.Controllers
{
    public interface IAudioControllerBindings
    {
        void BindInventoryAudio(IInventoryEvents inventoryEvents);
        void BindResolutionControllerAudio(IResolutionControllerEvents resolutionControllerEvents);
        
        void UnbindInventoryAudio(IInventoryEvents inventoryEvents);
        void UnbindResolutionControllerAudio(IResolutionControllerEvents resolutionControllerEvents);

    }
}