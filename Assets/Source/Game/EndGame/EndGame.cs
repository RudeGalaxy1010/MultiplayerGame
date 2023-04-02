using Photon.Pun;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private const string CheckWinMethodName = "CheckWin";
    private const string EndGamePanelShowMethodName = "Show";

    [SerializeField] private PhotonView _photonView;
    [SerializeField] private EndGamePanel _endGamePanel;

    private Health _health;
    private Wallet _wallet;

    public bool IsWinnerClient(PlayerSide playerSide) =>
        (playerSide == PlayerSide.Master && PhotonNetwork.IsMasterClient == false)
        || (playerSide == PlayerSide.Slave && PhotonNetwork.IsMasterClient == true);

    public void Construct(Health health, Wallet wallet)
    {
        _wallet = wallet;
        _health = health;
        _health.Died += OnDied;
    }

    private void OnDestroy()
    {
        if (_health != null)
        {
            _health.Died -= OnDied;
        }
    }

    private void OnDied()
    {
        PlayerSide playerSide = PhotonNetwork.IsMasterClient ? PlayerSide.Master : PlayerSide.Slave;
        _photonView.RPC(CheckWinMethodName, RpcTarget.All, playerSide);
    }

    [PunRPC]
    private void CheckWin(PlayerSide playerSide)
    {
        if (IsWinnerClient(playerSide) == false)
        {
            return;
        }

        string winnerName = PhotonNetwork.NickName;
        int coinsValue = _wallet.Coins;

        _endGamePanel.PhotonView.RPC(EndGamePanelShowMethodName, RpcTarget.All, winnerName, coinsValue);
    }
}
