using System;
using System.Collections.Generic;
using UnityEngine;

namespace Abstraction
{
    public abstract class ObjectPool<TObject, TChild> : Singleton<TChild>
        where TObject : MonoBehaviour
        where TChild : MonoBehaviour
    {
        [SerializeField] private int poolSize = 10;
        [SerializeField] private TObject prefab;

        private List<TObject> pool = new();

        private void Start()
        {
            pool = new(poolSize);
            IncreasePoolSize();
        }

        public TObject GetFromPool()
        {
            foreach (TObject @object in pool)
            {
                if (@object.gameObject.activeInHierarchy)
                    continue;

                @object.gameObject.SetActive(true);
                @object.transform.parent = null;
                return @object;
            }
            IncreasePoolSize();
            return GetFromPool();
        }

        public void ReturnToPool(TObject @object)
        {
            if (!pool.Contains(@object))
                throw new ArgumentException($"This object is out of the pool");

            @object.gameObject.SetActive(false);
            @object.gameObject.transform.position = Vector3.zero;
            @object.gameObject.transform.parent = transform;
        }

        private void IncreasePoolSize()
        {
            for (int i = 0; i < poolSize; i++)
            {
                TObject @object = Instantiate(prefab, transform);
                @object.gameObject.SetActive(false);
                pool.Add(@object);
            }
        }
    }
}
