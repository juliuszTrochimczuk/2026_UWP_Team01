using UnityEngine;

namespace Abstraction 
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; protected set; }
        
        protected virtual void Awake()
        {
            if (Instance != null)
                Destroy(Instance.gameObject);
            Instance = CreateInstance();
        }

        protected abstract T CreateInstance();
    }
}