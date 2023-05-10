using Lyaguska.Actors;

namespace Lyaguska.Services
{
    public class ActorDieCheckService : IActorDieCheckService
    {
        public float DeadLevelY = -5f;
        
        private Actor _actor;

        public void SetActor(Actor actor)
        {
            _actor = actor;
        }
        
        public void CheckDeath()
        {
            if((_actor.IsDead))
                return;
            
            if (_actor.transform.position.y < DeadLevelY)
            {
                _actor.Die();
            }
        }
    }
}