using Photon.Pun;
using UnityEngine;

namespace Source.Game.Coins
{
    [RequireComponent(typeof(Collider2D))]
    public class Coin : MonoBehaviour, IPunObservable
    {
        [SerializeField] private int _value;

        public int Value => _value;

        public void Destroy()
        {
            gameObject.SetActive(false);
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(gameObject.activeInHierarchy);
            }
            else if (stream.IsReading)
            {
                gameObject.SetActive((bool)stream.ReceiveNext());
            }
        }
    }
}
