using Source.Bootstrap;

namespace Source.Game.Coins.Spawn
{
    public interface ICoinsSpawner : IService
    {
        void CreateCoins();
    }
}
