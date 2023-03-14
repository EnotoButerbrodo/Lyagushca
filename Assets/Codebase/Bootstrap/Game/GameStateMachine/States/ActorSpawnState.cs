using EnotoButerbrodo.StateMachine;
using Lyaguska.Actors;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Bootstrap
{
    public class ActorSpawnState : State
    {
        private readonly ICameraService _cameraService;
        private readonly IDistanceCountService _distanceCount;
        private readonly IActorSelectService _actorSelectService;
        private readonly Vector2 _startPosition;

        public ActorSpawnState(StateMachine stateMachine
            , ICameraService cameraService
            , IDistanceCountService distanceCount
            , IActorSelectService actorSelectService
            , Vector2 startPosition) : base(stateMachine)
        {
            _cameraService = cameraService;
            _distanceCount = distanceCount;
            _actorSelectService = actorSelectService;
            _startPosition = startPosition;
        }


        public override void Enter()
        {
            var actor = _actorSelectService.SelectActor<Frog>(_startPosition);

            _cameraService.SetTarget(actor.transform);
            _cameraService.Enable();
            
            _distanceCount.SetTarget(actor.transform);
        }
    }
}