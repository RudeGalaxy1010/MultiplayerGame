using UnityEngine;

[RequireComponent(typeof(Health), typeof(PlayerMove), typeof(Shooting))]
public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private PlayerMove _move;
    [SerializeField] private Shooting _shooting;

    private void OnEnable()
    {
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    public void Construct(PlayerInput playerInput, BulletPool bulletPool)
    {
        _health.Construct();
        _move.Construct(playerInput);
        _shooting.Construct(bulletPool);
    }

    private void OnDied()
    {
        // TODO: lose
    }
}
