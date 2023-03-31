using UnityEngine;

public class MenuLoader : MonoBehaviour
{
    [SerializeField] private CreateConnectionToServer _createConnectionToServer;
    [SerializeField] private SceneLoader _sceneLoader;

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
