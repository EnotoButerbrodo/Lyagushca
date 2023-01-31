using System;
using UnityEngine;

namespace Lyaguska.ObjectPool
{
    public interface IInitializePoolObject<T> : IPoolObject
    {
        public void Initialize(Action<T> returnAction);

        public void ReturnToPool();
    }

    public interface IPoolObject
    {
        void ReturnToPool();
    }
}