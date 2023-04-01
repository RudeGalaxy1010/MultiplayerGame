using Photon.Pun;
using UnityEngine;

public class PhotonCoinsSpawner : CoinsSpawner
{
    private void Start()
    {
        CreateCoins();
    }

    public override void CreateCoins()
    {
        if (PhotonNetwork.IsMasterClient == false)
        {
            return;
        }

        for (int i = 0; i < CoinsCount; i++)
        {
            Coin coin = CreateCoin(Random.insideUnitCircle * SpawnRadius);
            coin.Construct(this);
        }
    }

    public override void DestroyCoin(Coin coin)
    {
        PhotonNetwork.Destroy(coin.gameObject);
    }

    private Coin CreateCoin(Vector2 at)
    {
        return PhotonNetwork.Instantiate(CoinPrefab.name, at, Quaternion.identity).GetComponent<Coin>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Vector2.zero, SpawnRadius);
    }
}
