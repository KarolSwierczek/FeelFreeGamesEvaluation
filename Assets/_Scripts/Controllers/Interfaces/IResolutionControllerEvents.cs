using System;

namespace FeelFreeGames.Evaluation.Controllers
{
    public interface IResolutionControllerEvents
    {
        event Action ResolutionChanged;
    }
}