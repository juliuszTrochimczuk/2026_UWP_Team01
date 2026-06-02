using Abstraction;
using UnityEngine;

namespace AI.States
{
    public class AiGoState : BaseState<Enemy>
    {
        public AiGoState(Enemy owner) : base(owner)
        {
        }

        public override bool StateCondtions() => true;

        public override void OnUpdate()
        {
            Owner.Movement.MoveEnemy();
            if (Owner.Movement.Progress >= 1.0f)
                Owner.SM.TryChangeState(AiStateId.Attack);
        }
    }
}