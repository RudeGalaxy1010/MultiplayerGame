using Source.Bootstrap;

namespace Source.SceneLoading
{
    public interface ISceneLoader : IService
    {
        public void LoadMenu();
        public void LoadGame();
    }
}