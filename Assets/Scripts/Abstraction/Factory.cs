using UnityEngine;

namespace Abstraction
{
    public abstract class Factory<T, TObject, TParam> : Singleton<T> where T : MonoBehaviour
    {
        public abstract TObject Create(TParam param);
    }
}
