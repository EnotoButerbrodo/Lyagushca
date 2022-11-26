using Lyaguska.Core;
using UnityEngine;
using Zenject;

public class PlayerGameActorFactory : MonoBehaviour, IFactory<GameActor>
{
    [SerializeField] private GameActor _defaultGameActor;
    public GameActor Create()
    {
        return Instantiate(_defaultGameActor);
    }
}
