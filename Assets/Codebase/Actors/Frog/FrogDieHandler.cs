using System;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Actors
{
    public class FrogDieHandler : MonoBehaviour, IResetable
    {
        [SerializeField] private Collider2D _frogCollider;
        public event Action Dead;
        
        public bool IsDead { get; private set; }


        public void Die()
        {
            IsDead = true;
            _frogCollider.isTrigger = true;
            
            Dead?.Invoke();
        } 
        
        public void Reset()
        {
            IsDead = false;
            _frogCollider.isTrigger = false;
        }
    }
}