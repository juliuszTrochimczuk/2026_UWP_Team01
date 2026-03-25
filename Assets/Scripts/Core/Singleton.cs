using UnityEngine;

namespace Controllers 
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance { get; protected set; }
        
        private void Awake()
        {
            if (Instance != null)
                DestroyInstance();
            CreateInstance();
            OnAwake();
        }

        private void OnDestroy()
        {
            DestroyInstance();
        }

        protected virtual void DestroyInstance() => Destroy(Instance);
        protected abstract void CreateInstance();
        protected virtual void OnAwake() { }
    }
}