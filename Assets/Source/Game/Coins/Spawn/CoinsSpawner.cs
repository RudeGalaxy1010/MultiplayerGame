using UnityEngine;

public abstract class CoinsSpawner : MonoBehaviour
{
    [SerializeField] protected Coin CoinPrefab;
    [SerializeField] protected int CoinsCount;
    [SerializeField] protected float SpawnRadius;

    public abstract void CreateCoins();
    public abstract void DestroyCoin(Coin coin);
}
