using System;
using UnityEngine;

namespace Lyaguska.Actors.StateMachine
{
    [RequireComponent(typeof(Actor))]
    public abstract class ActorStateMachine : MonoBehaviour
    {
        public Actor Actor { get; private set; }

        private ActorState _currentState;

        private void Awake()
        {
            Actor = GetComponent<Actor>();
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
            Debug.Log($"Exit {_currentState}");
            _currentState = state;
            _currentState.Enter();
            Debug.Log($"Enter {_currentState}");
        }

        private void Update()
        {
            _currentState?.UpdateState();
        }

        protected abstract ActorState GetInitialState();
    }
}