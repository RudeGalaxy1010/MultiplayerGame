using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, IPunObservable
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _fill;

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void Start()
    {
        UpdateHealth();
    }

    private void OnHealthChanged()
    {
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        _fill.fillAmount = _health.HealthPerc;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(_health.HealthPerc);
        }
        else
        {
            _fill.fillAmount = (float)stream.ReceiveNext();
        }
    }
}
