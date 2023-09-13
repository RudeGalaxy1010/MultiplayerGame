using Source.Assets;
using Source.Game.Coins;
using Source.Game.Coins.Spawn;
using Source.Game.EndGame;
using Source.Game.Input;
using Source.Game.Shoot;
using Source.Game.Shoot.Spawner;
using Source.Game.Spawn;
using Source.SceneLoading;
using Source.UI;
using TMPro;
using UnityEngine;

namespace Source.Bootstrap
{
    public class MainSceneBootstrap : MonoBehaviour, ICoroutineRunner
    {
        [Header("Player")]
        [SerializeField] private Transform _masterSpawnPoint;
        [SerializeField] private Transform _slaveSpawnPoint;
        [Header("Coins")]
        [SerializeField] private int _coinsCount;
        [SerializeField] private Vector2 _coinSpawnSize;
        [SerializeField] private TMP_Text _coinsCounterText;
        [Header("Shooting")]
        [SerializeField] private float _fireRate;
        [SerializeField] private EndGame _endGame;
        [SerializeField] private EndGamePanel _endGamePanel;

        private Services _services;

        private void Start()
        {
            _services = Services.Container;

            InitServices(_services);
            
            _services.Single<IPlayerSpawner>().CreatePlayer();
            _services.Single<ICoinsSpawner>().CreateCoins();
            _endGamePanel.Construct(_services.Single<ISceneLoader>());

            Subscribe(_services);
        }

        private void OnDestroy()
        {
            Unsubscribe(_services);
        }

        private void Subscribe(Services services)
        {
            foreach (var subscribeOnlyHandler in services.SubscribeHandlers)
            {
                var subscribeHandler = (ISubscribeHandler)subscribeOnlyHandler;
                subscribeHandler.Subscribe();
            }
        }

        private void Unsubscribe(Services services)
        {
            foreach (var subscribeOnlyHandler in services.SubscribeHandlers)
            {
                var subscribersHandler = (ISubscribeHandler)subscribeOnlyHandler;
                subscribersHandler.Unsubscribe();
            }
        }

        private void InitServices(Services services)
        {
            services.RegisterSingle<ISceneLoader>(new SceneLoader());
            services.RegisterSingle<IAssetsProvider>(new AssetsProvider());
            services.RegisterSingle<IPlayerInput>(new JoystickInput(services.Single<IAssetsProvider>()));
            services.RegisterSingle<ICoinsSpawner>(new PhotonCoinsSpawner(services.Single<IAssetsProvider>(), _coinsCount, _coinSpawnSize));
            services.RegisterSingle<ICoinsCounter>(new CoinsCounter(_coinsCounterText));
            services.RegisterSingle<IBulletSpawner>(new PhotonBulletSpawner(services.Single<IAssetsProvider>()));
            services.RegisterSingle<IShooting>(new Shooting(services.Single<IPlayerInput>(), _services.Single<IBulletSpawner>(), 
                this, _fireRate));
            services.RegisterSingle<IPlayerWallet>(new Wallet());
            services.RegisterSingle<IEndGame>(_endGame);
            services.RegisterSingle<IPlayerSpawner>(new PhotonPlayerSpawner(services, _masterSpawnPoint, _slaveSpawnPoint));
        }
    }

}
