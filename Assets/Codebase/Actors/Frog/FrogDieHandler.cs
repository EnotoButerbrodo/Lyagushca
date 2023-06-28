using System;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Actors
{
    public class FrogDieHandler : MonoBehaviour, IResetable
    {
        [SerializeField] private Collider2D _frogCollider;
        [SerializeField] private FrogAnimator _animator;
        public event Action Dead;
        
        public bool IsDead { get; private set; }


        public void Die()
        {
            IsDead = true;
            _frogCollider.enabled = false;
            _animator.SetHurt();

            Dead?.Invoke();
        } 
        
        public void Reset()
        {
            IsDead = false;
            _frogCollider.enabled = true;
        }
    }
}