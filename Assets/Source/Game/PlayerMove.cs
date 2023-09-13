using Source.Bootstrap;
using Source.Game.Input;
using Source.Game.PhotonTools;
using UnityEngine;

namespace Source.Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMove : MonoBehaviour, IPhotonDependComponent
    {
        private readonly Vector2 _borders = new Vector2(8.4f, 4.5f);

        [SerializeField] private float _moveSpeed;

        private IPlayerInput _input;

        private void Start()
        {
            _input = Services.Container.Single<IPlayerInput>();
        }

        private void Update()
        {
            if (_input == null)
            {
                return;
            }

            Move();
            Rotate();
        }

        private void Move()
        {
            Vector3 playerPosition = transform.position;
            Vector2 targetPosition = (Vector2)playerPosition + _input.Velocity;
            Vector2 nextPosition = Vector2.MoveTowards((Vector2)playerPosition, targetPosition, _moveSpeed * Time.deltaTime);
            transform.position = GetClampedPosition(nextPosition);
        }

        private void Rotate()
        {
            if (_input.Velocity == Vector2.zero)
            {
                return;
            }

            transform.rotation = Quaternion.LookRotation(Vector3.forward, (Vector3)_input.Velocity.normalized);
        }

        private Vector3 GetClampedPosition(Vector3 position)
        {
            float clampedX = Mathf.Clamp(position.x, -_borders.x, _borders.x);
            float clampedY = Mathf.Clamp(position.y, -_borders.y, _borders.y);
            return new Vector3(clampedX, clampedY);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(Vector2.zero, _borders * 2f);
        }
    }
}
