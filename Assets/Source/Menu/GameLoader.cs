using Photon.Pun;
using UnityEngine;

public class GameLoader : MonoBehaviourPunCallbacks
{
    [SerializeField] private SceneLoader _sceneLoader;

    public override void OnJoinedRoom()
    {
        _sceneLoader.LoadGame();
    }
}
