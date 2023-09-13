using UnityEngine;

namespace Source.Game.Coins
{
    public class CoinsCollector : MonoBehaviour, ICoinsCollector
    {
        private IPlayerWallet _wallet;

        public void SetWallet(IPlayerWallet wallet)
        {
            _wallet = wallet;
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Coin coin))
            {
                if (_wallet != null)
                {
                    _wallet.AddCoins(coin.Value);
                }
                
                coin.Destroy();
            }
        }
    }
}
