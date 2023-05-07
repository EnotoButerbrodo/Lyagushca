using EnotoButerbrodo.StateMachine;
using Lyaguska.Actors;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Bootstrap
{
    public class ActorSpawnState : State
    {
        private readonly ICameraFollowService _cameraFollowService;
        private readonly IDistanceCountService _distanceCount;
        private readonly IActorSelectService _actorSelectService;
        private readonly Vector2 _startPosition;

        public ActorSpawnState(StateMachine stateMachine
            , ICameraFollowService cameraFollowService
            , IDistanceCountService distanceCount
            , IActorSelectService actorSelectService
            , Vector2 startPosition) : base(stateMachine)
        {
            _cameraFollowService = cameraFollowService;
            _distanceCount = distanceCount;
            _actorSelectService = actorSelectService;
            _startPosition = startPosition;
        }


        public override void Enter()
        {
            var actor = _actorSelectService.SelectActor<Frog>(_startPosition);

            _cameraFollowService.SetTarget(actor.transform);
            _cameraFollowService.Enable();
            
            _distanceCount.SetTarget(actor.transform);
        }
    }
}