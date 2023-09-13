using Photon.Pun;
using Source.SceneLoading;

namespace Source.Menu
{
    public class GameLoader : MonoBehaviourPunCallbacks
    {
        private SceneLoader _sceneLoader;

        private void Start()
        {
            _sceneLoader = new SceneLoader();
        }

        public override void OnJoinedRoom()
        {
            _sceneLoader.LoadGame();
        }
    }
}
