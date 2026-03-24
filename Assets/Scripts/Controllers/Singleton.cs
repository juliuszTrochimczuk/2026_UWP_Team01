using UnityEngine;

namespace Controllers 
{
    public abstract class Singleton<T> : MonoBehaviour
    {
        public static T Instance { get; protected set; }
        
        [SerializeField] protected bool isDestructable;

        private void Awake()
        {
            if (Instance != null)
                DestroyInstance();
            CreateInstance();
        }

        private void Oestroy()
        {
            if (isDestructable)
                DestroyInstance();
        }

        protected abstract void DestroyInstance();

        protected abstract void CreateInstance();
    }
}