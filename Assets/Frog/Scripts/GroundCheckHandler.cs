using System;
using UnityEngine;

public class GroundCheckHandler : MonoBehaviour
{
    public event Action Landed;
    [SerializeField] private LayerMask _ground;
    [SerializeField][Range(0, 10f)] private float _distance;
    public bool IsGrounded()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, _distance, _ground))
        {
            return true;
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Landed?.Invoke();
    }



}

