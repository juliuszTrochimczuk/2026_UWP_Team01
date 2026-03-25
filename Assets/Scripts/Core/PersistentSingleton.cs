using UnityEngine;

namespace Controllers
{
    public abstract class PersistentSingleton<T> : Singleton<T> where T : PersistentSingleton<T>
    {
        protected override void OnAwake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
