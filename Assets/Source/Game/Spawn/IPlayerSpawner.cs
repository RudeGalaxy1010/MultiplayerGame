using Source.Bootstrap;

namespace Source.Game.Spawn
{
    public interface IPlayerSpawner : IService
    {
        void CreatePlayer();
    }
}
