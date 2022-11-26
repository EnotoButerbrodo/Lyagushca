using System;
using UnityEngine;

namespace Lyaguska.Core
{
    public class GroundCheckHandler : MonoBehaviour
    {
        public event Action Landed;
        [SerializeField] private BoxCollider2D _collider;
        [SerializeField] private LayerMask _ground;

        private Collider2D[] _overlapResult = new Collider2D[1];
        public bool IsGrounded()
        {
            if (Physics2D.OverlapBoxNonAlloc(_collider.bounds.center, _collider.bounds.size, 0, _overlapResult, _ground) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if ((_ground.value & 1 << collision.gameObject.layer) > 0)
            {
                Landed?.Invoke();
            }
        }



    }
}