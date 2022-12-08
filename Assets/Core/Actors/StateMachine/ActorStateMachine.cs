using System.Runtime.InteropServices;
using UnityEngine;
using Zenject;

namespace Lyaguska.Core.Actors.StateMachine
{
    public class ActorStateMachine : MonoBehaviour
    {
        public Actor Actor { get; private set; }
        public ActorState IdleState { get; private set; }
        public ActorState JumpChargeState { get; private set; }
        public ActorState JumpState { get; private set; }
        public ActorState AirState { get; private set; }
        public ActorState BufferedJumpState { get; private set; }

        private ActorState _currentState;
        private IJumpForceCharger _charger;
        private Timer _timer;

        [Inject]
        public void Construct(IJumpForceCharger charger, Timer timer)
        {
            _charger = charger;
            _timer = timer;
        }


        public void SetState(ActorState state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();

            Debug.Log(_currentState.ToString());
        }

        private void Awake()
        {
            Actor = GetComponent<Actor>();

            InitializeStates();
            SetState(GetInitialState());
        }

        private void InitializeStates()
        {
            IdleState = new IdleState(this, _charger);
            JumpChargeState = new JumpChargeState(this, _charger);
            JumpState = new JumpState(this, _charger);
            AirState = new AirState(this, _charger);
            BufferedJumpState = new BufferedJumpState(this, _charger,_timer);
        }

        public void ButtonPressHandler()
        {
            _currentState.HandleButtonPress();
        }

        public void ButtonReleaseHandler()
        {
            _currentState.HandleButtonRelease();
        }

        private ActorState GetInitialState() => IdleState;
    }



}