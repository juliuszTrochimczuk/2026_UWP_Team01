using Abstraction;

namespace  Managers
{
    public class BulletPool : ObjectPool<Bullet, BulletPool>
    {
        protected override BulletPool CreateInstance() => this;
    }
}