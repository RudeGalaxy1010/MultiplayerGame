using Source.SceneLoading;
using UnityEngine;

namespace Source.Loading.Scripts
{
    public class MenuLoader : MonoBehaviour
    {
        [SerializeField] private CreateConnectionToServer _createConnectionToServer;

        private SceneLoader _sceneLoader;

        private void Start()
        {
            _sceneLoader = new SceneLoader();
        }

        private void OnEnable()
        {
            _createConnectionToServer.Connected += OnConnectionCreated;
        }

        private void OnDisable()
        {
            _createConnectionToServer.Connected -= OnConnectionCreated;
        }

        private void OnConnectionCreated()
        {
            _sceneLoader.LoadMenu();
        }
    }
}
