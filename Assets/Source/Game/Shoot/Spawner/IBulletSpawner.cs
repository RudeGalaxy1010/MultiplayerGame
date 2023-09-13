using Source.Bootstrap;
using UnityEngine;

namespace Source.Game.Shoot.Spawner
{
    public interface IBulletSpawner : IService
    {
        public Bullet Instantiate(Vector2 at);
        public void Destroy(Bullet bullet);
    }
}
