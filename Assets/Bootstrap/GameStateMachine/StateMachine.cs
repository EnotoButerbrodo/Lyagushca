using System;
using System.Collections.Generic;
using Lyaguska.Core;
using Zenject;

namespace Bootstrap.GameStateMachine
{
    public abstract class StateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;

        public StateMachine()
        {
            _states = InitialStates() ?? new Dictionary<Type, IExitableState>();
        }
        
        protected abstract Dictionary<Type, IExitableState> InitialStates();

        public bool HasState<TState>() where TState : class, IExitableState 
            => _states.ContainsKey(typeof(TState));

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload)
            where TState : class, IPayloadedState<TPayload>
        {
            IPayloadedState<TPayload> state = ChangeState<TState>();
            state.Enter(payload);
        }

        public void UpdateStates()
        {
            _currentState?.UpdateState();
        }
        
        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();
            TState state = GetState<TState>();
            _currentState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState 
            => _states[typeof(TState)] as TState;
    }
    

}