using System;
using Lyaguska.Actors;
using UnityEngine;

namespace Lyaguska.Handlers
{
    public class Spikes : MonoBehaviour
    {
        //Нанести урон лягушке при соприкосновении
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Spikes");
            var actor = other.GetComponent<Actor>();
            actor.Die();
        }
    }
}