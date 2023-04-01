using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    [SerializeField] private int _value;

    private CoinsSpawner _coinsSpawner;

    public int Value => _value;

    public void Construct(CoinsSpawner coinsSpawner)
    {
        _coinsSpawner = coinsSpawner;
    }

    public void Destroy()
    {
        _coinsSpawner.DestroyCoin(this);
    }
}
