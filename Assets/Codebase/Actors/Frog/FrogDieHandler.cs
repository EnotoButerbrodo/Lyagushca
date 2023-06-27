using System;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Actors
{
    public class FrogDieHandler : MonoBehaviour, IResetable
    {
        [SerializeField] private Collider2D _frogCollider;
        [SerializeField] private FrogAnimator _animator;
        [SerializeField] private Rigidbody2D _rigidbody;

        [SerializeField] private float _deathForce = 5f;
        public event Action Dead;
        
        public bool IsDead { get; private set; }


        public void Die()
        {
            IsDead = true;
            _frogCollider.enabled = false;
            _animator.SetHurt();
            if(_rigidbody.velocity.y >= -2f)
                _rigidbody.AddForce(Vector2.up * _deathForce, ForceMode2D.Impulse);
            
            Dead?.Invoke();
        } 
        
        public void Reset()
        {
            IsDead = false;
            _frogCollider.enabled = true;
        }
    }
}