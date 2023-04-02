using Photon.Pun;
using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            _wallet.AddCoins(coin.Value);
            coin.Destroy();
        }
    }
}
