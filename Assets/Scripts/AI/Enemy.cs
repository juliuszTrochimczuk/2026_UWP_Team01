using System.Collections.Generic;
using Abstraction;
using AI.States;
using Core;
using Managers;
using Presenters;
using UI;
using UnityEngine;
using UnityEngine.Splines;

namespace AI
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private BaseHealth healthComponent;
        [SerializeField] private HealthBar healthView;
        [field: SerializeField] public EnemyMovement Movement { get; private set; }

        [field: SerializeField] public EnemyConfig Config { get; private set; }
        [SerializeField] private AiStateId startState;

        private HealthPresenter presenter;
        public BaseStateMachine<Enemy, AiStateId> SM { get; private set; }

        private void Awake()
        {
            presenter = new HealthPresenter(healthComponent, healthView);
            healthComponent.SetHealth(Config.MaxHealth);
            SM = new(
                new Dictionary<AiStateId, BaseState<Enemy>>
                {
                    { AiStateId.Go, new AiGoState(this) },
                    { AiStateId.Attack, new AiAttackState(this) },
                    { AiStateId.Die, new AiDeathState(this) }
                },
                startState
            );
            Movement.speed = Config.Speed;
        }

        private void OnEnable()
        {
            SM.TryChangeState(startState);
            SM.OnStart();
        }

        private void Update() => SM.OnUpdate();

        private void OnDestroy() => presenter.Disconnect();

        public void Die() => SM.TryChangeState(AiStateId.Die);

        public void DisableEnemy()
        {
            WaveManager.Instance?.DecreaseWaveActiveEnemy();
            SM.OnEnd();
            EnemyPool.Instance.ReturnToPool(this);
        }
    }
}
