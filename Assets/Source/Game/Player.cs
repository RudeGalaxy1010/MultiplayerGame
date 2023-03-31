using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMove _move;

    public void Construct(PlayerInput playerInput)
    {
        _move.Construct(playerInput);
    }
}
