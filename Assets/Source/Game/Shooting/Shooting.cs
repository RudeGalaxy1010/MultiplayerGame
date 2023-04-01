using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour, IPhotonDependComponent
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireRate;

    private BulletPool _bulletPool;
    private float _cooldownTime;
    private bool _isCoolDown;

    public void Construct(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
        _cooldownTime = 1f / _fireRate;
        _isCoolDown = false;
    }

    private void Update()
    {
        if (_isCoolDown == true)
        {
            return;
        }

        if (Input.GetKey(KeyCode.F))
        {
            Fire();
        }
    }

    private void Fire()
    {
        Bullet bullet = _bulletPool.Instantiate();
        bullet.transform.position = _firePoint.position;
        bullet.Construct(transform.up, _bulletPool);

        _isCoolDown = true;
        StartCoroutine(ProcessCooldown(_cooldownTime));
    }

    private IEnumerator ProcessCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        _isCoolDown = false;
    }
}
