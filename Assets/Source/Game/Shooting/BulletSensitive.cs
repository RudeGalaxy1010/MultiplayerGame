using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(Collider2D), typeof(Rigidbody2D))]
public class BulletSensitive : MonoBehaviour
{
    private const string TakeDamageRPCMethodName = "TakeDamage";

    [SerializeField] private Health _health;
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            ApplyDamage();
            bullet.Destroy();
        }
    }

    private void ApplyDamage()
    {
        _photonView.RPC(TakeDamageRPCMethodName, RpcTarget.All, _damage);
    }
}
