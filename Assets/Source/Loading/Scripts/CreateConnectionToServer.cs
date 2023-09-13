using System;
using Photon.Pun;

namespace Source.Loading.Scripts
{
    public class CreateConnectionToServer : MonoBehaviourPunCallbacks
    {
        public event Action Connected;

        private void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        public override void OnConnectedToMaster()
        {
            Connected?.Invoke();
        }
    }
}
