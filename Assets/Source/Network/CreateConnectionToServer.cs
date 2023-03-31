using Photon.Pun;
using System;

public class CreateConnectionToServer : MonoBehaviourPunCallbacks
{
    public event Action Connected;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Connected?.Invoke();
    }
}
