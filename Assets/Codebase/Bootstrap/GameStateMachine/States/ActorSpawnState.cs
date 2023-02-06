using EnotoButerbrodo.StateMachine;
using Lyaguska.Actors;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Bootstrap
{
    public class ActorSpawnState : State
    {
        private IActorFactory _actorFactory;
        private ICameraService _cameraService;
        private Vector2 _startPosition;

        public ActorSpawnState(StateMachine stateMachine, IActorFactory actorFactory, ICameraService cameraService, Vector2 startPosition) : base(stateMachine)
        {
            _actorFactory = actorFactory;
            _cameraService = cameraService;
            _startPosition = startPosition;
        }


        public override void Enter()
        {
            var actor = _actorFactory.SelectActor<Frog>((Vector3)_startPosition);
            _cameraService.SetTarget(actor.transform);
            
            _stateMachine.Enter<GameLoopState, Actor>(actor);
        }
    }
}