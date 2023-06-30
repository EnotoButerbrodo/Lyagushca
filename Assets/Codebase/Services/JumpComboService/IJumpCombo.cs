using System;
using Lyaguska.Services;

namespace Codebase.Services.JumpComboService
{
    public interface IJumpCombo : IResetable
    {
        public event Action<int> ComboChanged;
        public int Combo { get; }
        public void SetJump();
        public void SetLand();
        void ClearCombo();
    }
}