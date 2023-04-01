using UnityEngine;

public abstract class BulletPool : MonoBehaviour
{
    [SerializeField] protected Bullet Prefab;
    [SerializeField] protected int StartCount;

    public abstract Bullet Instantiate();
    public abstract void Destroy(Bullet bullet);
}
