using System;
using Source.Bootstrap;

namespace Source.Game.Coins
{
    public interface IPlayerWallet : IService
    {
        event Action<int> CoinsValueChanged;
        int Coins { get; }
        void AddCoins(int value);
    }
}
