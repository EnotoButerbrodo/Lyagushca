using System;
using UnityEngine;

namespace Lyaguska.ObjectPool
{
    public interface IPoolable<T> where T : MonoBehaviour
    {
        public void Initialize(Action<T> returnAction);

        public void ReturnToPool();
    }
}