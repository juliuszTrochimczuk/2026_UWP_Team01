using UnityEngine;

namespace Abstraction 
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance { get; protected set; }
        
        protected virtual void Awake()
        {
            if (Instance != null)
                DestroyInstance();
            Instance = CreateInstance();
        }

        private void OnDestroy()
        {
            DestroyInstance();
        }

        protected virtual void DestroyInstance() => Destroy(Instance);
        protected abstract T CreateInstance();
    }
}