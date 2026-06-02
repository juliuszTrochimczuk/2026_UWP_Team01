using System;
using UnityEngine;

namespace Abstraction
{
    public abstract class BaseState<TOwner> where TOwner : MonoBehaviour
    {
        protected TOwner Owner { get; private set; }

        public BaseState(TOwner owner) => this.Owner = owner;

        public abstract bool StateCondtions();

        public virtual void OnStart() { }
        public virtual void OnUpdate() { }
        public virtual void OnEnd() { }
    }
}