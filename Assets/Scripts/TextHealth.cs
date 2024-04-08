using TMPro;
using UnityEngine;

public class TextHealth : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthValue;
    [SerializeField] private Health _health;
    [SerializeField] private HealthValueChanger _healthChanger;

    private void Start()
    {
        ChangeValue();
    }

    private void OnEnable()
    {
        _healthChanger.Change += ChangeValue;
    }

    private void OnDisable()
    {
        _healthChanger.Change -= ChangeValue;
    }

    private void ChangeValue()
    {
        _healthValue.text = $"{_health.CurrentHealth}/{_health.MaxHealth}";
    }
}