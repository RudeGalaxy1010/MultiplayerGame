using UnityEngine;

public class PlayerBootstrap : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _spawner;
    [SerializeField] private PlayerInput _input;

    private void Start()
    {
        Player player = _spawner.CreatePlayer();
        player.Construct(_input);
    }
}
