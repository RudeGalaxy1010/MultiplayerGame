using Photon.Pun;
using UnityEngine;

public class PlayerColorChanger : MonoBehaviourPunCallbacks
{
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private SpriteRenderer _playerSpriteRenderer;
    [SerializeField] private Color _masterColor;
    [SerializeField] private Color _slaveColor;

    private void Start()
    {
        if (_photonView.IsMine)
        {
            _playerSpriteRenderer.color = _masterColor;
        }
        else
        {
            _playerSpriteRenderer.color = _slaveColor;
        }
    }
}
