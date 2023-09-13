using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Source.Menu
{
    public class RoomManagement : MonoBehaviour
    {
        private const int MaxPlayers = 2;

        private void Start()
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                PhotonNetwork.LeaveRoom();
            }
        }

        public void CreateRoom(string nickName, string roomName)
        {
            PhotonNetwork.NickName = nickName;
            RoomOptions roomOptions = new RoomOptions() { MaxPlayers = MaxPlayers };
            PhotonNetwork.CreateRoom(roomName, roomOptions);
        }

        public void JoinRoom(string nickName, string roomName)
        {
            PhotonNetwork.NickName = nickName;
            PhotonNetwork.JoinRoom(roomName);
        }
    }
}
