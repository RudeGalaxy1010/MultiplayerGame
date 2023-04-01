using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float MaxDistance = 25f;

    [SerializeField] private float _speed;

    private Vector2? _direction;
    private BulletPool _pool;

    public void Construct(Vector2 direction, BulletPool pool)
    {
        _direction = direction;
        _pool = pool;
    }

    private void Update()
    {
        if (Vector2.Distance(Vector2.zero, transform.position) >= MaxDistance)
        {
            Destroy();
            return;
        }

        if (_direction == null)
        {
            return;
        }

        Vector2 targetPosition = (Vector2)transform.position + _direction.Value;
        Vector2 nextPosition = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
        transform.position = nextPosition;
    }

    public void Destroy()
    {
        _direction = null;
        _pool.Return(this);
    }
}
