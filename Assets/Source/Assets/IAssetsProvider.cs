using Source.Bootstrap;
using Source.Game.Input;
using UnityEngine;

namespace Source.Assets
{
    public interface IAssetsProvider : IService
    {
        GameObject PlayerPrefab();
        MobileInput MobileInput();
        GameObject CoinPrefab();
        GameObject BulletPrefab();
    }
}
