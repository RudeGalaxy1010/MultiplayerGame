using Photon.Pun;
using TMPro;
using UnityEngine;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _winnerText;
    [SerializeField] protected TMP_Text _coinsValueText;
    [SerializeField] private GameObject _panelView;
    [SerializeField] private PhotonView _photonView;

    public PhotonView PhotonView => _photonView;

    [PunRPC]
    public void Show(string winnerName, int coinsValue)
    {
        _panelView.SetActive(true);
        _winnerText.text = $"{winnerName} is the winner!";
        _coinsValueText.text = $"Coins: {coinsValue}";
    }
}
