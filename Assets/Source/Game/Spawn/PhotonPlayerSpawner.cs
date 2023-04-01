using Photon.Pun;
using UnityEngine;

public class PhotonPlayerSpawner : PlayerSpawner
{
    [SerializeField] private Player _prefab;

    public override Player CreatePlayer()
    {
        return PhotonNetwork.Instantiate(_prefab.name, Vector2.zero, Quaternion.identity).GetComponent<Player>();
    }
}
