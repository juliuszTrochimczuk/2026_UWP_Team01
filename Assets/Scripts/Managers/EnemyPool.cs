using Abstraction;
using AI;

namespace Managers
{
    public class EnemyPool : ObjectPool<Enemy, EnemyPool>
    {
        protected override EnemyPool CreateInstance() => this;
    }
}