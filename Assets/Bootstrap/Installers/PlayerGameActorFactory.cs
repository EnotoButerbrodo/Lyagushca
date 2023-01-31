using Lyaguska.Core;
using UnityEngine;
using Zenject;

public class PlayerGameActorFactory : MonoBehaviour, IFactory<Actor>
{
    [SerializeField] private Actor _defaultGameActor;
    public Actor Create()
    {
        return Instantiate(_defaultGameActor);
    }
}
