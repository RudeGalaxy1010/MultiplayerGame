using UnityEngine.SceneManagement;

namespace Source.SceneLoading
{
    public class SceneLoader : ISceneLoader
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
}
