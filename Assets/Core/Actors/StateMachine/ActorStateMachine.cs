using UnityEngine;

namespace Lyaguska.Core.Actors.StateMachine
{
    [RequireComponent(typeof(Actor))]
    public abstract class ActorStateMachine : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public Actor Actor { get; private set; }
        public Animator Animator => _animator;

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
            _currentState = state;
            _currentState.Enter();

            Debug.Log(_currentState.ToString());
        }

        protected abstract ActorState GetInitialState();
    }
}