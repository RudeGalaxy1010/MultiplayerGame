using UnityEngine;

public abstract class BulletSpawner : MonoBehaviour
{
    [SerializeField] protected Bullet BulletPrefab;

    public abstract Bullet Instantiate(Vector2 at);
    public abstract void Destroy(Bullet bullet);
}
