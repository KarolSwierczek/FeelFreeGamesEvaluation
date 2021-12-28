using System;

namespace FeelFreeGames.Evaluation.Input
{
    public interface IGameInput
    {
        event Action NextResolution;
        event Action PreviousResolution;
    }
}