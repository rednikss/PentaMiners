using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Libs.Patterns.ObjectPool
{
    public class MonoBehaviourPool<T> : IObjectPool<T> where T : MonoBehaviour
    {
        protected readonly T Prefab;

        protected readonly Transform Parent;
        
        private readonly Stack<T> _pool = new();

        public MonoBehaviourPool(T prefab, Transform parent, int startSize = 0)
        {
            Prefab = prefab;
            Parent = parent;
            
            for (var i = 0; i < startSize; i++) Create();
        }

        protected virtual void Create()
        {
            var newObject = Object.Instantiate(Prefab, Parent);
            
            ReturnObject(newObject);
        }

        public T Get()
        {
            if (!_pool.TryPeek(out _)) Create();
            
            return TakeObject();
        }

        public void ReturnObject(T pooledObject)
        {
            pooledObject.gameObject.SetActive(false);

            _pool.Push(pooledObject);
        }

        private T TakeObject()
        {
            var pooledObject = _pool.Pop();
            
            pooledObject.gameObject.SetActive(true);

            return pooledObject;
        }
    }
}