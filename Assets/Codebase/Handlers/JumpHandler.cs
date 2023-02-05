using System;
using Lyaguska.Services;
using UnityEngine;

namespace Lyaguska.Handlers
{
    public class JumpHandler : MonoBehaviour, IResetable
    {
        public event Action Jumped;

        public event Action<Vector2> VelocityChanged;

        [SerializeField][Range(0, 50f)] private float _jumpHeightKoeff;
        [SerializeField][Range(0, 50f)] private float _jumpRangeKoeff;

        [SerializeField] private AnimationCurve _jumpHeightCurve;
        [SerializeField] private AnimationCurve _jumpRangeCurve;
        [SerializeField] private Rigidbody2D _rigidbody;


        public void Jump(float jumpPercent)
        {
            Vector2 vericalDirection = _jumpHeightCurve.Evaluate(jumpPercent) * _jumpHeightKoeff * Vector2.up;
            Vector2 horizontalDirection = _jumpRangeCurve.Evaluate(jumpPercent) * _jumpRangeKoeff * Vector2.right;

            _rigidbody.AddForce(vericalDirection + horizontalDirection, ForceMode2D.Impulse);
            Jumped?.Invoke();

        }

        private void FixedUpdate()
        {
            VelocityChanged?.Invoke(_rigidbody.velocity);
        }

        public void Reset()
        {
            _rigidbody.velocity = Vector2.zero;
            VelocityChanged?.Invoke(_rigidbody.velocity);

        }
    }
}