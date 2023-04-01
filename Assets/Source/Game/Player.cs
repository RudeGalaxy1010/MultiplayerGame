using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(PlayerMove), typeof(Shooting))]
public class Player : MonoBehaviourPun
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

    public void Construct(PlayerInput playerInput)
    {
        _move.Construct(playerInput);
    }

    private void OnDied()
    {
        // TODO: lose
    }
}
