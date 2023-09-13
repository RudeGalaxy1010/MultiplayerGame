using Photon.Pun;
using Source.Assets;
using Source.Bootstrap;
using Source.Game.Coins;
using Source.Game.EndGame;
using Source.Game.Shoot;
using Source.UI;
using UnityEngine;

namespace Source.Game.Spawn
{
    public class PhotonPlayerSpawner : IPlayerSpawner
    {
        private readonly Services _services;
        private readonly Transform _masterSpawnPoint;
        private readonly Transform _slaveSpawnPoint;

        public PhotonPlayerSpawner(Services services, Transform masterSpawnPoint, Transform slaveSpawnPoint)
        {
            _services = services;
            _masterSpawnPoint = masterSpawnPoint;
            _slaveSpawnPoint = slaveSpawnPoint;
        }
        
        public void CreatePlayer()
        {
            Vector2 spawnPosition = _masterSpawnPoint.position;

            if (PhotonNetwork.IsMasterClient == false)
            {
                spawnPosition = _slaveSpawnPoint.position;
            }

            var assetsProvider = _services.Single<IAssetsProvider>();
            GameObject player = PhotonNetwork.Instantiate(assetsProvider.PlayerPrefab().name, spawnPosition, Quaternion.identity);

            IPlayerHealth health = player.GetComponent<IPlayerHealth>();
            ICoinsCollector coinsCollector = player.GetComponent<ICoinsCollector>();
            IPlayerWallet wallet = _services.Single<IPlayerWallet>();

            _services.Single<IEndGame>().SetPlayerComponents(health, wallet);
            _services.Single<ICoinsCounter>().SetPlayerWallet(wallet);
            _services.Single<IShooting>().SetFirePoint(player.GetComponentInChildren<FirePoint>().transform);
            coinsCollector.SetWallet(wallet);
        }
    }
}
