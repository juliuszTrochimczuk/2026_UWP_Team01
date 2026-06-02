using Abstraction;
using Managers;

namespace AI.States
{
    public class AiDeathState : BaseState<Enemy>
    {
        public AiDeathState(Enemy owner) : base(owner)
        {
        }

        public override bool StateCondtions() => true;

        public override void OnStart()
        {
            CoinsManager.Instance?.AddCoins(Owner.Config.RewardOnDeath);
            Owner.DisableEnemy();
        }
    }
}