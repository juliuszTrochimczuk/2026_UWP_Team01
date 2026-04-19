using Abstraction;
using Core;
using Presenters;
using UI;
using UnityEngine;

namespace Towers 
{
    public class MainBase : Singleton<MainBase>
    {
        [field: SerializeField] public BaseHealth BaseHealth { get; private set; }
        [SerializeField] private HealthBar healthView;

        private HealthPresenter presenter;

        protected override MainBase CreateInstance() => this;

        void Start()
        {
            presenter = new HealthPresenter(BaseHealth, healthView);
        }

        private void OnDestroy()
        {
            presenter.Disconnect();
        }
    }
}