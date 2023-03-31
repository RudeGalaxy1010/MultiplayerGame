using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    private const float _borderOffset = 0.5f;

    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private PhotonView _photonView;

    private Vector2 _borders;
    private PlayerInput _input;

    public void Construct(PlayerInput input)
    {
        _input = input;
    }

    private void Awake()
    {
        if (_photonView.IsMine == false)
        {
            enabled = false;
        }

        _borders = GetBorders();
    }

    private void Update()
    {
        Vector3 targetPosition = transform.position + (Vector3)_input.Velocity;
        Vector3 nextPosition = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
        transform.position = GetClampedPosition(nextPosition);
    }

    private Vector3 GetClampedPosition(Vector3 position)
    {
        float clampedX = Mathf.Clamp(position.x, -_borders.x, _borders.x);
        float clampedY = Mathf.Clamp(position.y, -_borders.y, _borders.y);
        return new Vector3(clampedX, clampedY, 0);
    }

    private Vector2 GetBorders()
    {
        Vector3 screenSpace = new Vector3(Screen.width, Screen.height, 0);
        Vector3 offset = Vector3.one * _borderOffset;
        return Camera.main.ScreenToWorldPoint(screenSpace) - offset;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(Vector2.zero, _borders * 2f);
    }
}
