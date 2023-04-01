using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMove _move;
    [SerializeField] private Shooting _shooting;

    public void Construct(PlayerInput playerInput, BulletPool bulletPool)
    {
        _move.Construct(playerInput);
        _shooting.Construct(bulletPool);
    }
}
