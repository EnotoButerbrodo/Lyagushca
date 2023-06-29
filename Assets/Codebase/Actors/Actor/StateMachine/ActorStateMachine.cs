using System;
using UnityEngine;

namespace Lyaguska.Actors.StateMachine
{
    public abstract class ActorStateMachine : MonoBehaviour
    {
        [SerializeField] private Actor _actor;
        public Actor Actor => _actor;

        private ActorState _currentState;

        private void Awake()
        {
            InitializeStates();
            ChangeState(GetInitialState());
            OnAwake();
        }

        protected virtual void OnAwake() { }

        protected abstract void InitializeStates();

        public void ButtonPressHandler()
        {
            _currentState.HandleButtonPress();
        }

        public void ButtonReleaseHandler()
        {
            _currentState.HandleButtonRelease();
        }

        public void ChangeState(ActorState state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        private void Update()
        {
            _currentState?.UpdateState();
        }

        protected abstract ActorState GetInitialState();
    }
}