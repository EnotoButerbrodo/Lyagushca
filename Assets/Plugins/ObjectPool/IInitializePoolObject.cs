using System;

namespace EnotoButerbrodo.ObjectsPool
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