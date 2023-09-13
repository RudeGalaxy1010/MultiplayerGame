using Photon.Pun;
using Source.Assets;
using UnityEngine;

namespace Source.Game.Shoot.Spawner
{
    public class PhotonBulletSpawner : IBulletSpawner
    {
        private readonly IAssetsProvider _assetsProvider;

        public PhotonBulletSpawner(IAssetsProvider assetsProvider)
        {
            _assetsProvider = assetsProvider;
        }
        
        public void Destroy(Bullet bullet)
        {
            PhotonNetwork.Destroy(bullet.gameObject);
        }

        public Bullet Instantiate(Vector2 at)
        {
            return PhotonNetwork.Instantiate(_assetsProvider.BulletPrefab().name, at, Quaternion.identity).GetComponent<Bullet>();
        }
    }
}
