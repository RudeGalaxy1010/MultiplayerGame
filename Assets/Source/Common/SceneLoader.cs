using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private const int MenuSceneIndex = 1;

    public void LoadMenu()
    {
        LoadSceneByIndex(MenuSceneIndex);
    }

    private void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
