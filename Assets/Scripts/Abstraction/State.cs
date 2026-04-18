using UnityEngine;

namespace Abstraction
{
    public abstract class State
    {
        protected readonly MonoBehaviour onwer;

        public State(MonoBehaviour onwer) => this.onwer = onwer;

        public abstract bool StateCondition();

        public virtual void OnStart() { }
        public virtual void OnUpdate() { }
        public virtual void OnEnd() { }
    }
}
