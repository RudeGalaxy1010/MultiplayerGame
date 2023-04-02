using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BulletSpawner))]
public class Shooting : MonoBehaviour, IPhotonDependComponent
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireRate;
    [SerializeField] private BulletSpawner _bulletSpawner;

    private PlayerInput _playerInput;
    private float _cooldownTime;
    private bool _isCoolDown;

    public void Construct(PlayerInput playerInput)
    {
        _playerInput = playerInput;
        _playerInput.FireButtonPressed += OnFireButtonPressed;
        _cooldownTime = 1f / _fireRate;
        _isCoolDown = false;
    }

    private void OnDestroy()
    {
        if (_playerInput != null)
        {
            _playerInput.FireButtonPressed -= OnFireButtonPressed;
        }
    }

    private void OnFireButtonPressed()
    {
        Fire();
    }

    private void Fire()
    {
        if (_isCoolDown == true)
        {
            return;
        }

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
