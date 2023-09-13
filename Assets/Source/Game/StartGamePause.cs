using Photon.Pun;
using UnityEngine;

namespace Source.Game
{
    public class StartGamePause : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject _cover;

        private bool IsRoomFull => PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers;

        private void Start()
        {
            CheckCover();
        }

        private void CheckCover()
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                _cover.SetActive(!IsRoomFull);
            }
        }

        public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
        {
            CheckCover();
        }
    }
}
