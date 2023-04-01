using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _spawner;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private CoinsCounter _coinsCounter;

    private void Start()
    {
        Player player = _spawner.CreatePlayer();
        player.Construct(_input);
        _coinsCounter.Construct(player.GetComponent<Wallet>());
    }
}
