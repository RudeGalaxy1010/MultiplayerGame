using System;

namespace Source.Game.Coins
{
    public class Wallet : IPlayerWallet
    {
        private const string DamageLessThanZeroMessage = "Coins value can't be less or equal 0";

        public event Action<int> CoinsValueChanged;

        private int _coins;

        public int Coins => _coins;

        public void AddCoins(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException(DamageLessThanZeroMessage);
            }

            _coins += value;
            CoinsValueChanged?.Invoke(_coins);
        }
    }
}
