using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private int _value;

    public int Value => _value;
    public PhotonView PhotonView => _photonView;

    [PunRPC]
    public void Destroy()
    {
        if (_photonView.IsMine)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
