using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
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
}
