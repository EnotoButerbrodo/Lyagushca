using System;
using UnityEngine;

namespace Lyaguska.Handlers
{
    public class GroundCheckHandler : MonoBehaviour
    {
        public event Action Grounded;
        [SerializeField] private BoxCollider2D _collider;
        [SerializeField] private LayerMask _ground;

        private Collider2D[] _overlapResult = new Collider2D[1];
        public bool IsGrounded()
        {
            return Physics2D.OverlapBoxNonAlloc(_collider.bounds.center, _collider.bounds.size, 0, _overlapResult, _ground) != 0;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Grounded?.Invoke();
        }



    }
}