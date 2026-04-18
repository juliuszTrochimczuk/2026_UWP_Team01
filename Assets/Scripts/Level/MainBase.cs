using UnityEngine;
using Abstraction;
using Controllers;

namespace Towers 
{
    public class MainBase : Singleton<MainBase>
    {
        [field: SerializeField] public BaseHealth BaseHealth { get; private set; }

        protected override MainBase CreateInstance() => this;
    }
}