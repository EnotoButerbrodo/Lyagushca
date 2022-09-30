using System;
using UnityEngine;
public class DieHandler : MonoBehaviour
{
    public event Action Dead;

    public void Die()
    {
        Dead?.Invoke();
    }

}
