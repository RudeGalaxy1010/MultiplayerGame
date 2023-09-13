using Source.Bootstrap;
using Source.Game.Coins;

namespace Source.Game.EndGame
{
    public interface IEndGame : IService
    {
        bool IsWinnerClient(PlayerSide playerSide);
        void SetPlayerComponents(IPlayerHealth health, IPlayerWallet playerWallet);
        void OnDied();
        void CheckWin(PlayerSide playerSide);
    }
}
