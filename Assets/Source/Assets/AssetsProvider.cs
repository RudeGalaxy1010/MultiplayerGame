using Source.Game.Input;
using UnityEngine;

namespace Source.Assets
{
    public class AssetsProvider : IAssetsProvider
    {
        private const string PlayerPrefabPath = "Player";
        private const string MobileInputPrefabPath = "MobileInputCanvas";
        private const string CoinPrefabPath = "Coin";
        private const string BulletPrefabPath = "Bullet";

        public GameObject PlayerPrefab() => Resources.Load<GameObject>(PlayerPrefabPath);
        public MobileInput MobileInput() => Resources.Load<MobileInput>(MobileInputPrefabPath);
        public GameObject CoinPrefab() => Resources.Load<GameObject>(CoinPrefabPath);
        public GameObject BulletPrefab() => Resources.Load<GameObject>(BulletPrefabPath);
    }
}
