using System;

namespace FeelFreeGames.Evaluation.Input
{
    public class GameInputHandler : IGameInput
    {
        event Action IGameInput.NextResolution
        {
            add => _nextResolution += value;
            remove => _nextResolution -= value;
        }

        event Action IGameInput.PreviousResolution
        {
            add => _previousResolution += value;
            remove => _previousResolution -= value;
        }

        private event Action _nextResolution;
        private event Action _previousResolution;
    }
}