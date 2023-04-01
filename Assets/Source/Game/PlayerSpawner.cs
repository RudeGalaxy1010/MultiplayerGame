using Photon.Pun;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Player _prefab;
    [SerializeField] private PlayerInput _input;

    private void Start()
    {
        Player player = PhotonNetwork.Instantiate(_prefab.name, Vector2.zero, Quaternion.identity).GetComponent<Player>();
        player.Construct(_input);
    }
}
