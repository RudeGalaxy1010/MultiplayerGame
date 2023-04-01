using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BulletSpawner))]
public class Shooting : MonoBehaviour, IPhotonDependComponent
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireRate;
    [SerializeField] private BulletSpawner _bulletSpawner;

    private float _cooldownTime;
    private bool _isCoolDown;

    private void Start()
    {
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
        Bullet bullet = _bulletSpawner.Instantiate(_firePoint.position);
        bullet.Construct(transform.up, _bulletSpawner);
        _isCoolDown = true;
        StartCoroutine(ProcessCooldown(_cooldownTime));
    }

    private IEnumerator ProcessCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        _isCoolDown = false;
    }
}
