using UnityEngine;

public abstract class BulletPool : MonoBehaviour
{
    [SerializeField] protected Bullet Prefab;
    [SerializeField] protected int StartCount;

    public abstract Bullet Get();
    public abstract void Return(Bullet bullet);
}
