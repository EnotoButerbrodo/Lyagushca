using Lyaguska.Actors;
using UnityEngine;
using Zenject;

namespace Lyaguska.Bootstrap.Installers
{
    public class PlayerGameActorFactory : MonoBehaviour, IFactory<Actor>
    {
        [SerializeField] private Actor _defaultGameActor;

        public Actor Create()
        {
            return Instantiate(_defaultGameActor);
        }
    }
}
