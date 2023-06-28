using System;
using Lyaguska.Handlers;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Actors
{
    public class FrogDieHandler : MonoBehaviour, IResetable
    {
        [SerializeField] private Collider2D _frogCollider;
        [SerializeField] private FrogAnimator _animator;
        [SerializeField] private FrogSoundHandler _frogSound;
        public event Action Dead;
        
        public bool IsDead { get; private set; }


        public void Die()
        {
            IsDead = true;
            _frogCollider.enabled = false;
            _animator.SetHurt();
            _frogSound.PlayDead();

            Dead?.Invoke();
        } 
        
        public void Reset()
        {
            IsDead = false;
            _frogCollider.enabled = true;
        }
    }
}