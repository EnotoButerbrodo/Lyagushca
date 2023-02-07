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
        private IDistanceCountService _distanceCount;
        private StaticData _staticData;
        private Vector2 _startPosition;

        public ActorSpawnState(StateMachine stateMachine
            , IActorFactory actorFactory
            , ICameraService cameraService
            , IDistanceCountService distanceCount
            , StaticData staticData
            , Vector2 startPosition) : base(stateMachine)
        {
            _actorFactory = actorFactory;
            _cameraService = cameraService;
            _distanceCount = distanceCount;
            _staticData = staticData;
            _startPosition = startPosition;
        }


        public override void Enter()
        {
            var actor = _actorFactory.Get<Frog>((Vector3)_startPosition);
            _staticData.CurrentActor = actor;
            _cameraService.SetTarget(actor.transform);
            _distanceCount.SetTarget(actor.transform);
            _stateMachine.Enter<GameLoopState>();
        }
    }
}