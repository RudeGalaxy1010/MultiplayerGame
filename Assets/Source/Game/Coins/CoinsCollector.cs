using Photon.Pun;
using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    private const string AddCoinsRPCMethodName = "AddCoins";

    [SerializeField] private PhotonView _photonView;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            ApplyCoins(coin.Value);
            coin.Destroy();
        }
    }

    private void ApplyCoins(int value)
    {
        _photonView.RPC(AddCoinsRPCMethodName, RpcTarget.All, value);
    }
}
