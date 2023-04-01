using UnityEngine;

public class PlayerBootstrap : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _spawner;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private BulletPool _bulletPool;

    private void Start()
    {
        Player player = _spawner.CreatePlayer();
        player.Construct(_input, _bulletPool);
    }
}
