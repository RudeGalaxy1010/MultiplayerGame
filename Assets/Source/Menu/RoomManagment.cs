using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RoomManagment : MonoBehaviour
{
    private const int MaxPlayers = 2;

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
