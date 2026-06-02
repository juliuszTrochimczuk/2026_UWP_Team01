using Abstraction;
using Towers;
using UnityEngine;
using static UnityEngine.Rendering.STP;

namespace AI.States
{
    public class AiAttackState : BaseState<Enemy>
    {
        public AiAttackState(Enemy owner) : base(owner)
        {
        }

        public override bool StateCondtions() => Owner.Movement.Progress >= 1.0f;

        public override void OnStart()
        {
            MainBase.Instance.BaseHealth.CurrentHealth -= Owner.Config.Damage;
            Owner.DisableEnemy();
        }
    }
}