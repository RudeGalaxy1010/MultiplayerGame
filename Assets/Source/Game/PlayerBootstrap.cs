using UnityEngine;

public class PlayerBootstrap : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private PlayerMove _playerMove;

    private void Awake()
    {
        _playerMove.Construct(_input);
    }
}
