using Lyaguska.Actors;
using UnityEngine;

namespace Lyaguska.Handlers
{
    public class Enemy : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var actor = other.GetComponent<Actor>();
            actor.Die();
        }
    }
}