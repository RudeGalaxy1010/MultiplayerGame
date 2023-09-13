using System.Collections;
using Source.Bootstrap;
using Source.Game.Input;
using Source.Game.PhotonTools;
using Source.Game.Shoot.Spawner;
using UnityEngine;

namespace Source.Game.Shoot
{
    public class Shooting : IPhotonDependComponent, IShooting, IUnsubscribeOnlyHandler
    {
        private readonly IPlayerInput _playerInput;
        private readonly IBulletSpawner _bulletSpawner;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly float _cooldownTime;
        private Transform _firePoint;
        private bool _isCoolDown;

        public Shooting(IPlayerInput playerInput, IBulletSpawner bulletSpawner, ICoroutineRunner coroutineRunner, float fireRate)
        {
            _playerInput = playerInput;
            _bulletSpawner = bulletSpawner;
            _coroutineRunner = coroutineRunner;
            _playerInput.FireButtonPressed += OnFireButtonPressed;
            _cooldownTime = 1f / fireRate;
            _isCoolDown = false;
        }

        public void SetFirePoint(Transform firePoint)
        {
            _firePoint = firePoint;
        }

        private void OnFireButtonPressed()
        {
            Fire();
        }

        private void Fire()
        {
            if (_isCoolDown == true || _firePoint == null)
            {
                return;
            }

            Bullet bullet = _bulletSpawner.Instantiate(_firePoint.position);
            bullet.Construct(_firePoint.up, _bulletSpawner);
            _isCoolDown = true;
            _coroutineRunner.StartCoroutine(ProcessCooldown(_cooldownTime));
        }

        private IEnumerator ProcessCooldown(float time)
        {
            yield return new WaitForSeconds(time);
            _isCoolDown = false;
        }

        public void Unsubscribe()
        {
            if (_playerInput != null)
            {
                _playerInput.FireButtonPressed -= OnFireButtonPressed;
            }
        }
    }
}
