using Photon.Pun;
using Source.Game.Coins;
using UnityEngine;

namespace Source.Game.EndGame
{
    public class EndGame : MonoBehaviour, IEndGame
    {
        private const string CheckWinMethodName = "CheckWin";
        private const string EndGamePanelShowMethodName = "Show";
        
        [SerializeField] private PhotonView _photonView;

        private IPlayerHealth _health;
        private IPlayerWallet _playerWallet;

        public bool IsWinnerClient(PlayerSide playerSide) =>
            (playerSide == PlayerSide.Master && PhotonNetwork.IsMasterClient == false)
            || (playerSide == PlayerSide.Slave && PhotonNetwork.IsMasterClient == true);

        public void SetPlayerComponents(IPlayerHealth health, IPlayerWallet playerWallet)
        {
            _playerWallet = playerWallet;
            _health = health;
            _health.Died += OnDied;
        }

        public void OnDied()
        {
            PlayerSide playerSide = PhotonNetwork.IsMasterClient ? PlayerSide.Master : PlayerSide.Slave;
            _photonView.RPC(CheckWinMethodName, RpcTarget.All, playerSide);
        }

        [PunRPC]
        public void CheckWin(PlayerSide playerSide)
        {
            if (IsWinnerClient(playerSide) == false)
            {
                return;
            }

            string winnerName = PhotonNetwork.NickName;
            int coinsValue = _playerWallet.Coins;

            _photonView.RPC(EndGamePanelShowMethodName, RpcTarget.All, winnerName, coinsValue);
        }

        private void OnDestroy()
        {
            if (_health != null)
            {
                _health.Died -= OnDied;
            }
        }
    }
}
