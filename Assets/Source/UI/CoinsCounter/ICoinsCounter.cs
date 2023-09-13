using Source.Bootstrap;
using Source.Game.Coins;

namespace Source.UI
{
    public interface ICoinsCounter : IService
    {
        void SetPlayerWallet(IPlayerWallet wallet);
    }
}
