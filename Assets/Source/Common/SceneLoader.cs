using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private const int MenuSceneIndex = 1;
    private const int GameSceneIndex = 2;

    public void LoadMenu()
    {
        LoadSceneByIndex(MenuSceneIndex);
    }

    public void LoadGame()
    {
        LoadSceneByIndex(GameSceneIndex);
    }

    private void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
