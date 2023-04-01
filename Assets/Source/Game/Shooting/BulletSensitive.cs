using UnityEngine;

[RequireComponent(typeof(Health), typeof(Collider2D), typeof(Rigidbody2D))]
public class BulletSensitive : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private int _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            _health.TakeDamage(_damage);
            bullet.Destroy();
        }
    }
}
