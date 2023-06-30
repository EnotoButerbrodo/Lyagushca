using System;
using Codebase.Services.JumpComboService;
using Lyaguska.Services;

namespace Codebase.Services.ScoreService
{
    public interface IScoreService : IResetable
    {
        int Score { get; }
        int ScoreBuffer { get; }
        event Action<int> ScoreChanged;
        event Action<int> ScoreBufferChanged;
        void SetJump();
        void SetLand();
    }
}