using Photon.Pun;
using Source.Assets;
using UnityEngine;

namespace Source.Game.Coins.Spawn
{
    public class PhotonCoinsSpawner : ICoinsSpawner
    {
        private readonly IAssetsProvider _assetsProvider;
        private readonly int _coinsCount;
        private readonly Vector2 _spawnZoneSize;

        public PhotonCoinsSpawner(IAssetsProvider assetsProvider, int coinsCount, Vector2 spawnZoneSize)
        {
            _assetsProvider = assetsProvider;
            _coinsCount = coinsCount;
            _spawnZoneSize = spawnZoneSize;
        }
        
        public void CreateCoins()
        {
            if (PhotonNetwork.IsMasterClient == false)
            {
                return;
            }

            for (int i = 0; i < _coinsCount; i++)
            {
                Vector2 randomSpawnPosition = GetRandomSpawnPosition();
                CreateCoin(randomSpawnPosition);
            }
        }

        private Vector2 GetRandomSpawnPosition()
        {
            float x = Random.Range(-_spawnZoneSize.x, _spawnZoneSize.x);
            float y = Random.Range(-_spawnZoneSize.y, _spawnZoneSize.y);

            return new Vector2(x, y);
        }

        private void CreateCoin(Vector2 at)
        {
            PhotonNetwork.Instantiate(_assetsProvider.CoinPrefab().name, at, Quaternion.identity);
        }
    }
}
