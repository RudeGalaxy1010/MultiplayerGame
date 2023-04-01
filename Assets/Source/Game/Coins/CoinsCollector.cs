using Photon.Pun;
using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    private const string AddCoinsRPCMethodName = "AddCoins";
    private const string CoinDestroyRPCMethodName = "Destroy";

    [SerializeField] private PhotonView _photonView;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            ApplyCoins(coin.Value);
            DestroyCoin(coin);
        }
    }

    private void ApplyCoins(int value)
    {
        _photonView.RPC(AddCoinsRPCMethodName, RpcTarget.All, value);
    }

    private void DestroyCoin(Coin coin)
    {
        coin.PhotonView.RPC(CoinDestroyRPCMethodName, RpcTarget.All);
    }
}
