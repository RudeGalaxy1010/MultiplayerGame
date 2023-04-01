using Photon.Pun;
using UnityEngine;

public class PhotonPlayerSpawner : PlayerSpawner
{
    [SerializeField] private Player _prefab;
    [SerializeField] private Transform _masterSpawnPoint;
    [SerializeField] private Transform _slaveSpawnPoint;

    public override Player CreatePlayer()
    {
        Vector2 spawnPosition = _masterSpawnPoint.position;

        if (PhotonNetwork.IsMasterClient == false)
        {
            spawnPosition = _slaveSpawnPoint.position;
        }

        return PhotonNetwork.Instantiate(_prefab.name, spawnPosition, Quaternion.identity).GetComponent<Player>();
    }
}
