using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lyaguska.ObjectPool
{
    public class ObjectPool<T> where T : MonoBehaviour, IPoolable<T>
    {
        public int Count => _pooledObjects.Count;
        public Type ObjectType => typeof(T);
        
        private readonly Stack<T> _pooledObjects;
        private readonly T _pooledObjectReference;
        private Transform _parent;
        
        public ObjectPool(T objectReference, int startCapacity = 8, Transform parent = null)
        {
            _pooledObjects = new Stack<T>(startCapacity);
            _pooledObjectReference = objectReference;
            _parent = parent;
            
            for (int i = 0; i < startCapacity; i++) 
            {
                PoolNewObject();
            }
        }

        public T Get()
        {
            if (Count == 0)
            {
                PoolNewObject();    
            }

            var poolObject = _pooledObjects.Pop();
            poolObject.gameObject.SetActive(true);
            
            return poolObject;
        }
        private void PoolNewObject()
        {
            T newObject = GameObject.Instantiate(_pooledObjectReference
                ,Vector3.zero
                ,Quaternion.identity
                ,_parent);
            
            
            newObject.Initialize(ReturnAction);
            _pooledObjects.Push(newObject);
            
        }

        private void ReturnAction(T poolObject) 
            => _pooledObjects.Push(poolObject);
    }
}