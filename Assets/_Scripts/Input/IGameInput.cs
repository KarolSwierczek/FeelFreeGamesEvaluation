using System;

namespace FeelFreeGames.Evaluation.Input
{
    public interface IGameInput : IInput
    {
        event Action NextResolution;
        event Action PreviousResolution;
    }
}