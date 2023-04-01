using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour, IPhotonDependComponent
{
    private readonly Vector2 _borders = new Vector2(2.31f, 4.5f);

    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private PhotonView _photonView;

    private PlayerInput _input;

    public void Construct(PlayerInput input)
    {
        _input = input;
    }

    private void Update()
    {
        if (_input == null)
        {
            return;
        }

        Vector2 targetPosition = (Vector2)transform.position + _input.Velocity;
        Vector2 nextPosition = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
        transform.position = GetClampedPosition(nextPosition);
    }

    private Vector3 GetClampedPosition(Vector3 position)
    {
        float clampedX = Mathf.Clamp(position.x, -_borders.x, _borders.x);
        float clampedY = Mathf.Clamp(position.y, -_borders.y, _borders.y);
        return new Vector3(clampedX, clampedY, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(Vector2.zero, _borders * 2f);
    }
}
