using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _spawner;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private EndGame _winAndLose;
    [SerializeField] private CoinsCounter _coinsCounter;

    private void Start()
    {
        Player player = _spawner.CreatePlayer();
        player.Construct(_input);
        Health health = player.GetComponent<Health>();
        Wallet wallet = player.GetComponent<Wallet>();
        _winAndLose.Construct(health, wallet);
        _coinsCounter.Construct(wallet);
    }
}
